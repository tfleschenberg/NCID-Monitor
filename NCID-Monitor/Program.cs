using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace NCID_Monitor
{
    static class Program
    {
        private static string[] Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion.Split('.');
        public static readonly string AppName = "NCID Monitor v" + Version[0] + "." + Version[1] + "." + Version[2];
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures.3", true);
            AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures.2", true);
            AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures", true);

            SystemEvents.PowerModeChanged += MainContext.OnPowerModeChanged;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainContext());
        }
    }
}
