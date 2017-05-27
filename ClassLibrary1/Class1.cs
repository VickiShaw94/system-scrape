using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{

    public class Class1
    {

        /// <summary>
        /// Exports log flags for EvtExportLogs
        /// </summary>
        [Flags]
        private enum EventExportLogFlags
        {
            ChannelPath = 1,
            LogFilePath = 2,
            TolerateQueryErrors = 0x1000
        };

        /// <summary>
        /// Exports specified event log
        /// </summary>
        /// <param name="sessionHandle"> Null pointer </param>
        /// <param name="path"> specify which event log</param>
        /// <param name="query"> what type of events in the log </param>
        /// <param name="targetPath"> where do you want to save it to </param>
        /// <param name="flags"> default spe</param>
        /// <returns></returns>
        [DllImport(@"wevtapi.dll",
            CallingConvention = CallingConvention.Winapi,
            CharSet = CharSet.Auto,
            SetLastError = true)]
        private static extern bool EvtExportLog(
            IntPtr sessionHandle,
            string path,
            string query,
            string targetPath,
            [MarshalAs(UnmanagedType.I4)] EventExportLogFlags flags);

        /// <summary>
        /// Method returns machine serial number in string
        /// </summary>
        /// <returns> string of serial number </returns> 
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
                        return (string)data.Value;
                }

            }
            return null;
        }

        /// <summary>
        /// Executes external process to call MsInfo32.exe, saves the information to
        /// txt file with serial number name
        /// </summary>
        private static void extractMsInfo32()
        {
            Process extProcess = new Process();
            extProcess.StartInfo.FileName = "msinfo32.exe";
            extProcess.StartInfo.Arguments = "/report " + @".\" + retrieveSerial() + ".txt";
            extProcess.Start();
        }

        /// <summary>
        /// method gets startup programs to text file
        /// </summary>
        private static void getStartups()
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript("wmic startup > " + @".\" + retrieveSerial() + "_startup.txt");
                ps.Invoke();
            }

        }
        public static void Main()
        {
            EvtExportLog(IntPtr.Zero, "System", "*", @".\sys.evtx", EventExportLogFlags.ChannelPath);
            extractMsInfo32();
            getStartups();
        }
    }
}
