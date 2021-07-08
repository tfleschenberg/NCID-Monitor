using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NCID_Monitor
{
    public class AsyncTCPSocket
    {
        private Socket socket;

        public event EventHandler<string> onReceived; // event

        protected virtual void OnReceived(string message)
        {
            onReceived?.Invoke(this, message);
        }

        public AsyncTCPSocket()
        {
            // Create a TCP/IP socket.  
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        }

        public void Connect(string host, int port)
        {
            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                socket.Connect(remoteEP);

                // Start receiveing from the remote device.
                Receive(socket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Disconnect(bool reuseSocket)
        {
            if (socket.Connected)
            {
                // Release the socket.  
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(reuseSocket);
            }
        }

        public void Close()
        {
            Disconnect(true);
            socket.Close();
        }

        private void Receive(Socket socket)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = socket;

                // Begin receiving the data from the remote device.  
                socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult asyncResult)
        {
            try
            {
                // Retrieve the state object and the client socket from the asynchronous state object.  
                StateObject stateObject = (StateObject)asyncResult.AsyncState;
                Socket socket = stateObject.workSocket;

                // Read data from the remote device.  
                int bytesRead = socket.EndReceive(asyncResult);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    stateObject.sb.Append(Encoding.ASCII.GetString(stateObject.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    socket.BeginReceive(stateObject.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), stateObject);

                    if (stateObject.sb.Length > 1)
                    {
                        OnReceived(stateObject.sb.ToString());
                        stateObject.sb.Clear();
                    }
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (stateObject.sb.Length > 1)
                    {
                        OnReceived(stateObject.sb.ToString());
                    }
                }
            }
            catch //(Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket socket, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), socket);
        }

        private static void SendCallback(IAsyncResult asyncResult)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)asyncResult.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(asyncResult);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}
