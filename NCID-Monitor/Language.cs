using System;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace NCID_Monitor
{
    static class Language
    {
        private static ResourceManager resourceManager;

        static Language()
        {
            Load(Thread.CurrentThread.CurrentUICulture.ToString());
            if (resourceManager == null) Load("en-US");
        }

        public static void Load(string language)
        {
            switch (language)
            {
                case "de-DE":
                case "de":
                    resourceManager = new ResourceManager("NCID_Monitor.Properties.GermanResources", Assembly.GetExecutingAssembly());
                    break;
                case "en-US":
                case "en":
                    resourceManager = new ResourceManager("NCID_Monitor.Properties.EnglishResources", Assembly.GetExecutingAssembly());
                    break;
                default:
                    // nothing - keep Thread.CurrentThread.CurrentUICulture
                    break;
            }
        }

        public static string GetString(string name)
        {
            string value = resourceManager.GetString(name);

            if (String.IsNullOrEmpty(value)) return name;

            return value;
        }

        public static void GetText(this Control control)
        {
            
            switch (control.GetType().ToString())
            {
                case "System.Windows.Forms.Button":
                case "System.Windows.Forms.CheckBox":
                case "System.Windows.Forms.Label":
                case "System.Windows.Forms.TabPage":
                    control.Text = GetString(control.Name);
                    break;

                default:
                    //Console.WriteLine(control.GetType().ToString());
                    break;
            }
        }
    }
}
