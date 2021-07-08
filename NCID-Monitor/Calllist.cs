using System;
using System.Collections.Generic;

namespace NCID_Monitor
{
    public static class Calllist
    {
        public static List<Call> calllist = new List<Call>();

        private static void Call(string datetime, string type, string line, string phoneid, string localnr, string remotenr, string sipid)
        {
            calllist.Add(new Call(datetime, line, phoneid, localnr, remotenr));
        }

        private static void Ring(string datetime, string type, string line, string remotenr, string localnr, string sipid)
        {
            calllist.Add(new Call(datetime, line, localnr, remotenr));
        }

        private static void Connect(string datetime, string type, string line, string phoneid, string remotenr)
        {
            for (int i = calllist.ToArray().Length - 1; i >= 0; i--)
            {
                if (calllist[i].Line == line)
                {
                    if (calllist[i].RemoteNR == remotenr)
                    {
                        if (calllist[i].Duration == String.Empty)
                        {
                            calllist[i].Icon = Properties.Resources.CallACTIVE;
                            calllist[i].PhoneID = phoneid;
                            calllist[i].Duration = Language.GetString("text_active");
                            break;
                        }
                    }
                }
            }
        }

        private static void Disconnect(string datetime, string type, string line, string duration)
        {
            for (int i = calllist.ToArray().Length - 1; i >= 0; i--)
            {
                if (calllist[i].Line == line)
                {
                    if ((calllist[i].Duration == String.Empty) || (calllist[i].Duration == Language.GetString("text_active")))
                    {
                        if (duration.Equals("0"))
                        {
                            calllist[i].Icon = Properties.Resources.CallMISSED;
                        }
                        else
                        {
                            if (calllist[i].CallDirection == CallDirection.In)
                            {
                                calllist[i].Icon = Properties.Resources.CallIN;
                            }
                            else
                            {
                                calllist[i].Icon = Properties.Resources.CallOUT;
                            }
                        }
                        uint duration_hours = Convert.ToUInt32(duration) / 3600;
                        uint duration_minutes = Convert.ToUInt32(duration) / 60 - 60 * duration_hours;
                        uint duration_seconds = Convert.ToUInt32(duration) - 60 * duration_minutes - 3600 * duration_hours;
                        calllist[i].Duration = String.Format("{0:00}:{1:00}:{2:00}", duration_hours, duration_minutes, duration_seconds);
                        //calllist[i].Duration = duration + " s";
                        break;
                    }
                }
            }
        }

        public static void processMessage(string message)
        {
            string[] fields = message.Split(';');

            switch (fields[1])
            {
                case "CALL":
                    if (fields.Length != 8) return;
                    MainContext.ShowBalloonTip("CALL - " + Functions.getPhoneID(fields[3]) + " -> " + Functions.getPhoneName(fields[5]));
                    Call(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6]);
                    break;

                case "RING":
                    if (fields.Length != 7) return;
                    MainContext.ShowBalloonTip("RING - " + Functions.getPhoneName(fields[4]) + " -> " + Functions.getPhoneName(fields[3]));
                    Ring(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]);
                    break;

                case "CONNECT":
                    if (fields.Length != 6) return;
                    MainContext.ShowBalloonTip("CONNECT - " + Functions.getPhoneID(fields[3]) + " <-> " + Functions.getPhoneName(fields[4]));
                    Connect(fields[0], fields[1], fields[2], fields[3], fields[4]);
                    break;

                case "DISCONNECT":
                    if (fields.Length != 5) return;
                    MainContext.ShowBalloonTip("DISCONNECT - " + fields[3] + " s");
                    Disconnect(fields[0], fields[1], fields[2], fields[3]);
                    break;

                default:
                    break;
            }
        }
    }
}
