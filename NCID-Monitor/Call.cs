using System;
using System.Drawing;

namespace NCID_Monitor
{
    public class Call
    {
        public Call(string CallTime, string Line, string PhoneID, string LocalNR, string RemoteNR)
        {
            this.CallDirection = CallDirection.Out;
            this.Icon = Properties.Resources.CallOUT;
            this.CallTime = CallTime;
            this.Line = Line;
            this.PhoneID = PhoneID;
            this.LocalNR = LocalNR;
            this.RemoteNR = RemoteNR;
            this.Duration = String.Empty;
        }

        public Call(string CallTime, string Line, string LocalNR, string RemoteNR)
        {
            this.CallDirection = CallDirection.In;
            this.Icon = Properties.Resources.CallIN;
            this.CallTime = CallTime;
            this.Line = Line;
            this.PhoneID = String.Empty;
            this.LocalNR = LocalNR;
            this.RemoteNR = RemoteNR;
            this.Duration = String.Empty;
        }

        public CallDirection CallDirection { get; }

        public Icon Icon { get; set; }

        public string CallTime { get; }

        public string Line { get; }

        public string PhoneID { get; set; }

        public string LocalNR { get; }

        public string RemoteNR { get; }

        public string Duration { get; set; }
    }
}
