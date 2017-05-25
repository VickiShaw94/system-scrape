﻿using System;
using System.Diagnostics;
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
        public static void Main()
        {
            retrieveSerial();
            Process extProcess = new Process();
            string sysID = Environment.MachineName;
            string serialID = retrieveSerial();
            extProcess.StartInfo.FileName = "msinfo32.exe";
            extProcess.StartInfo.Arguments = "/report " + @".\" + serialID + ".txt";
            extProcess.Start();
        }
    }
}
