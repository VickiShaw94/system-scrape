using System;
using System.Diagnostics;
using System.Management;

namespace ClassLibrary1
{

    public class Class1
    {

        private static void retrieveSerial()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");

            ManagementObjectCollection info = searcher.Get();
            foreach (ManagementObject obj in info)
            {
                foreach (PropertyData data in obj.Properties)
                    System.Diagnostics.Debug.WriteLine("{0} = {1}", data.Name, data.Value);
                //System.Diagnostics.Debug.WriteLine();
         
            }

            searcher.Dispose();
        }
        public static void Main()
        {
            retrieveSerial();
            Process extProcess = new Process();
            string sysID = Environment.MachineName;
            //string serialID = retrieveSerial();
            extProcess.StartInfo.FileName = "msinfo32.exe";
            extProcess.StartInfo.Arguments = "/report " + @".\" + sysID + ".txt";
            extProcess.Start();
        }
    }
}
