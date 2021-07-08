using System;
using System.Collections.Generic;
using System.Xml;

namespace NCID_Monitor
{
    public static class XML
    {
        public static void XMLToBool(XmlNode parentNode, string name, ref bool value)
        {
            XmlNode xmlNode = parentNode.SelectSingleNode("bool[@name='" + name + "']");
            bool tempvalue;

            if (xmlNode != null)
            {
                if (Boolean.TryParse(xmlNode.InnerText, out tempvalue))
                {
                    value = tempvalue;
                }
            }
        }

        public static void BoolToXML(XmlElement parentElement, string name, bool value)
        {
            XmlElement xmlElement = parentElement.OwnerDocument.CreateElement("bool");
            xmlElement.SetAttribute("name", name);
            xmlElement.InnerText = value.ToString();
            parentElement.AppendChild(xmlElement);
        }

        public static void XMLToInt(XmlNode parentNode, string name, ref int value)
        {
            XmlNode xmlNode = parentNode.SelectSingleNode("int[@name='" + name + "']");
            int tempvalue;

            if (xmlNode != null)
            {
                if (Int32.TryParse(xmlNode.InnerText, out tempvalue))
                {
                    value = tempvalue;
                }
            }
        }

        public static void IntToXML(XmlElement parentElement, string name, int value)
        {
            XmlElement xmlElement = parentElement.OwnerDocument.CreateElement("int");
            xmlElement.SetAttribute("name", name);
            xmlElement.InnerText = value.ToString();
            parentElement.AppendChild(xmlElement);
        }

        public static void XMLToString(XmlNode parentNode, string name, ref string value)
        {
            XmlNode xmlNode = parentNode.SelectSingleNode("string[@name='" + name + "']");

            if (xmlNode != null)
            {
                value = xmlNode.InnerText;
            }
        }

        public static void StringToXML(XmlElement parentElement, string name, string value)
        {
            XmlElement xmlElement = parentElement.OwnerDocument.CreateElement("string");
            xmlElement.SetAttribute("name", name);
            xmlElement.InnerText = value;
            parentElement.AppendChild(xmlElement);
        }

        public static void XMLToDictionary(XmlNode parentNode, string name, ref Dictionary<string, string> dictionary)
        {
            XmlNode xmlNode = parentNode.SelectSingleNode("dictionary[@name='" + name + "']");

            if (xmlNode != null)
            {
                XmlNodeList xmlNodeList = xmlNode.SelectNodes("item");

                if (xmlNodeList.Count > 0)
                {
                    dictionary.Clear();

                    foreach (XmlNode Node in xmlNodeList)
                    {
                        //if (dictionary.Contains(Node.Attributes["key"].Value)) dictionary.Remove(Node.Attributes["key"].Value);
                        dictionary.Add(Node.Attributes["key"].Value, Node.InnerText);
                    }
                }
            }
        }

        public static void DictionaryToXML(XmlElement parentElement, string dictionary, Dictionary<string, string> dict)
        {
            XmlElement xmlElement = parentElement.OwnerDocument.CreateElement("dictionary");

            xmlElement.SetAttribute("name", dictionary);

            foreach (var key in dict.Keys)
            {
                XmlElement xmlItemElement = parentElement.OwnerDocument.CreateElement("item");
                xmlItemElement.SetAttribute("key", key.ToString());
                xmlItemElement.InnerText = dict[key].ToString();
                xmlElement.AppendChild(xmlItemElement);
            }

            parentElement.AppendChild(xmlElement);
        }
    }
}
