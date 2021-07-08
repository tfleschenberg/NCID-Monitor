using System;
using System.Collections.Generic;

namespace NCID_Monitor
{
    public static class Functions
    {
        public static string RemoveHashs(this string text)
        {
            return text.Replace("#", String.Empty);
        }

        public static string getPhoneID(string PhoneID)
        {
            try { return Config.phoneIDDictionary[PhoneID]; }
            catch (KeyNotFoundException) { return PhoneID; }
        }

        public static string getPhoneName(string PhoneNumber)
        {
            try { return Config.phoneNameDictionary[PhoneNumber]; }
            catch (KeyNotFoundException) { return PhoneNumber; }
        }

        public static void changePhoneDeviceName(string DeviceNumber, string DeviceName)
        {
            if (Config.phoneIDDictionary.ContainsKey(DeviceNumber))
            {
                Config.phoneIDDictionary[DeviceNumber] = DeviceName;
            }
            else
            {
                Config.phoneIDDictionary.Add(DeviceNumber, DeviceName);
            }
        }

        public static void changePhoneName(string PhoneNumber, string PhoneName)
        {
            if (Config.phoneNameDictionary.ContainsKey(PhoneNumber))
            {
                Config.phoneNameDictionary[PhoneNumber] = PhoneName;
            }
            else
            {
                Config.phoneNameDictionary.Add(PhoneNumber, PhoneName);
            }
        }
    }

    public enum CallDirection
    {
        In,
        Out
    }
}
