using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NCID_Monitor
{
    public static class Extensions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_CHANGEUISTATE = 0x127;
        private const int UIS_SET = 1;
        private const int UISF_HIDEFOCUS = 0x1;

        private static int MakeLong(int wLow, int wHigh)
        {
            int low = (int)IntLoWord(wLow);
            short high = IntLoWord(wHigh);
            int product = 0x10000 * (int)high;
            int mkLong = (int)(low | product);
            return mkLong;
        }

        private static short IntLoWord(int word)
        {
            return (short)(word & short.MaxValue);
        }

        // remove autofocus on first item in listbox/listview
        // code from https://www.hofmann-robert.info/computer/2017/02/08/removefocusrectangle.html
        public static void RemoveFocusRectangle(this Control control)
        {
            try
            {
                SendMessage(control.Handle, WM_CHANGEUISTATE, MakeLong(UIS_SET, UISF_HIDEFOCUS), 0);
            }
            catch (DllNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
