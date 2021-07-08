using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NCID_Monitor
{
    public class MainContext : ApplicationContext
    {
        private static AsyncTCPSocket asyncTCPSocket;
        private static NotifyIcon notifyIcon;
        private static ContextMenu contextMenu;
        private static readonly MenuItem menuLogItem;
        private static readonly MenuItem menuSettingsItem;
        private static readonly MenuItem menuExitItem;
        private static LogForm logForm;
        private static SettingsForm settingsForm;

        private static System.Windows.Forms.Timer timer;

        static MainContext()
        {
            Config.Load();

            Application.ApplicationExit += OnApplicationExit;

            Language.Load(Config.language);

            asyncTCPSocket = new AsyncTCPSocket();
            asyncTCPSocket.onReceived += OnReceived;

            logForm = new LogForm();
            settingsForm = new SettingsForm();

            notifyIcon = new NotifyIcon();
            contextMenu = new ContextMenu();
            
            menuLogItem = new MenuItem(Language.GetString("menuLogItem"), menuLogItem_Click);
            menuSettingsItem = new MenuItem(Language.GetString("menuSettingsItem"), menuSettingsItem_Click);
            menuExitItem = new MenuItem(Language.GetString("menuExitItem"), menuExitItem_Click);

            contextMenu.MenuItems.Add(menuLogItem);
            contextMenu.MenuItems.Add(menuSettingsItem);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(menuExitItem);
            
            notifyIcon.MouseClick += NotifyIcon_MouseClick;

            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Icon = global::NCID_Monitor.Properties.Resources.Icojam_Blue_Bits_Phone;
            notifyIcon.Text = Program.AppName + " - " + Language.GetString("text_waiting");
            notifyIcon.Visible = true;

            timer = new System.Windows.Forms.Timer();

            timer.Tick += new EventHandler(OnTimerTick);

            asyncTCPSocket.Connect(Config.hostname, Config.port);
            
            notifyIcon.Text = Program.AppName + " - " + Language.GetString("text_connected");
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Config.Save();
        }

        private static void OnReceived(object sender, string message)
        {
            logForm.AddMessage(message);
        }

        public static void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Console.WriteLine("Resume");
                    asyncTCPSocket.Disconnect(true);
                    break;
                case PowerModes.Suspend:
                    Console.WriteLine("Suspend");
                    notifyIcon.Text = Program.AppName + " - " + Language.GetString("text_waiting");
                    asyncTCPSocket.Connect(Config.hostname, Config.port);
                    notifyIcon.Text = Program.AppName + " - " + Language.GetString("text_connected");
                    break;
            }
        }

        public static void ShowBalloonTip(string text)
        {
            timer.Stop();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                notifyIcon.ShowBalloonTip(Config.tooltipdelay, String.Empty, text, ToolTipIcon.None);
            }
            else
            {
                notifyIcon.ShowBalloonTip(Config.tooltipdelay, Program.AppName, text, ToolTipIcon.None);
            }
            timer.Interval = 1000 * Config.tooltipdelay;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            notifyIcon.Visible = false;
            notifyIcon.Visible = true;
        }

        private static void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // hack to remove active balloontip 
                notifyIcon.Visible = true;
                menuLogItem_Click(sender, e);
            }
        }

        private static void menuLogItem_Click(object sender, EventArgs e)
        {
            settingsForm.Hide();
            logForm.Show();
            logForm.Focus();
        }

        private static void menuSettingsItem_Click(object sender, EventArgs e)
        {
            logForm.Hide();
            settingsForm.Show();
            settingsForm.Focus();
        }

        public static void menuExitItem_Click(object sender, EventArgs e)
        {
            Exit(false);
        }

        public static void Exit(bool restart)
        {
            notifyIcon.Visible = false;
            asyncTCPSocket.Close();
            logForm.Close();
            logForm.Dispose();
            settingsForm.Close();
            settingsForm.Dispose();
            if (restart)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
