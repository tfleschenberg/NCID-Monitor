using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace NCID_Monitor
{
    public static class Config
    {
        //public static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "NCID Monitor");
        public static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NCID-Monitor");
        private static readonly string filename = Path.Combine(path, "configData.xml");

        public static bool createlogfiles;
        public static string language;
        public static int tooltipdelay;
        public static string hostname;
        public static int port;
        public static Dictionary<string, string> phoneIDDictionary;
        public static Dictionary<string, string> phoneNameDictionary;

        static Config()
        {
            language = "default";

            createlogfiles = true;

            tooltipdelay = 3;

            hostname = "fritz.box";
            port = 1012;

            phoneIDDictionary = new Dictionary<string, string>();
            phoneNameDictionary = new Dictionary<string, string>();

            phoneIDDictionary.Add("0", "FON1");
            phoneIDDictionary.Add("01", "FON1");
            phoneIDDictionary.Add("02", "FON2");
            phoneIDDictionary.Add("03", "FON3");
            phoneIDDictionary.Add("10", "DECT1");
            phoneIDDictionary.Add("11", "DECT2");
            phoneIDDictionary.Add("12", "DECT3");
            phoneIDDictionary.Add("13", "DECT4");
            phoneIDDictionary.Add("14", "DECT5");
            phoneIDDictionary.Add("15", "DECT6");
            phoneIDDictionary.Add("20", "IPFON1");
            phoneIDDictionary.Add("21", "IPFON2");
            phoneIDDictionary.Add("22", "IPFON3");
            phoneIDDictionary.Add("23", "IPFON4");
            phoneIDDictionary.Add("24", "IPFON5");
            phoneIDDictionary.Add("25", "IPFON6");
            phoneIDDictionary.Add("26", "IPFON7");
            phoneIDDictionary.Add("27", "IPFON8");
            phoneIDDictionary.Add("28", "IPFON9");
            phoneIDDictionary.Add("29", "IPFON10");

            phoneNameDictionary.Add("030399760", "AVM GmbH");
        }

        public static void Load()
        {
            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load(filename);

                XmlNode configNode = xmlDocument.DocumentElement.SelectSingleNode("configuration");

                if (configNode != null)
                {
                    XML.XMLToString(configNode, "language", ref language);
                    XML.XMLToBool(configNode, "createlogfiles", ref createlogfiles);
                    XML.XMLToInt(configNode, "tooltipdelay", ref tooltipdelay);
                    XML.XMLToString(configNode, "hostname", ref hostname);
                    XML.XMLToInt(configNode, "port", ref port);
                    XML.XMLToDictionary(configNode, "phoneIDDictionary", ref phoneIDDictionary);
                    XML.XMLToDictionary(configNode, "phoneNameDictionary", ref phoneNameDictionary);
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    MessageBox.Show(String.Format(Language.GetString("text_file_not_readable"), filename).Replace(@"\n", Environment.NewLine), Language.GetString("text_file_not_found"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Save();
                }
            }
        }

        public static void Save()
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);

            XmlElement rootElement = xmlDocument.CreateElement("NCID-Monitor");
            xmlDocument.AppendChild(rootElement);

            XmlElement configElement = xmlDocument.CreateElement("configuration");
            xmlDocument.DocumentElement.AppendChild(configElement);

            XML.StringToXML(configElement, "language", language);
            XML.BoolToXML(configElement, "createlogfiles", createlogfiles);
            XML.IntToXML(configElement, "tooltipdelay", tooltipdelay);
            XML.StringToXML(configElement, "hostname", hostname);
            XML.IntToXML(configElement, "port", port);
            XML.DictionaryToXML(configElement, "phoneIDDictionary", phoneIDDictionary);
            XML.DictionaryToXML(configElement, "phoneNameDictionary", phoneNameDictionary);

            Directory.CreateDirectory(Path.GetDirectoryName(filename));

            xmlDocument.Save(filename);
        }
    }
}
