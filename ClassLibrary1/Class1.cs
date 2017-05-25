using System;
using System.Diagnostics;
using System.IO;
using System.Management;

namespace ClassLibrary1
{

    public class Class1
    {

        private static string retrieveSerial()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");

            ManagementObjectCollection info = searcher.Get();
            foreach (ManagementObject obj in info)
            {
                foreach (PropertyData data in obj.Properties)
                {
                    if (data.Name == "SerialNumber")
                        return (string) data.Value;
                }
         
            }
            return null;
        }

        private static void extractMsInfo32()
        {
            Process extProcess = new Process();
            string serialID = retrieveSerial();
            extProcess.StartInfo.FileName = "msinfo32.exe";
            extProcess.StartInfo.Arguments = "/report " + @".\" + serialID + ".txt";
            extProcess.Start();
        }

        private static void writeWinEventLog(string fileName)
        {
            string path = @".\" + fileName;
            EventLog evtLog = new EventLog("System"); evtLog.MachineName = "."; // dot is local machine 

            //create file if doesn't currently exist
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            
            foreach (EventLogEntry evtEntry in evtLog.Entries)
            {
                //pipe output to text file
                //txtfile.writeLine(evtEntry.Message);
                //System.IO.File. WriteAllText(@".\" + fileName, evtEntry.Message);
                using (StreamWriter file = new StreamWriter(@".\" + fileName, true))
                {
                    file.WriteLine(evtEntry.Message);
                }

            }
            evtLog.Close();
        }

        public static void Main()
        {
            writeWinEventLog("try1.txt");
            extractMsInfo32();
        }
    }
}
