using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ClassLibrary1
{

    public class Class1
    {

        public static void Main()
        {

            string directoryPath = Directory.GetCurrentDirectory();
            string[] lines = { Directory.GetCurrentDirectory()};
            string place =  "C:\\Users\\vs\\Documents\\systemLogs\\";

            Process sysInfoCaptureExternalProcess = new Process();

            sysInfoCaptureExternalProcess.StartInfo.UseShellExecute = false;
            sysInfoCaptureExternalProcess.StartInfo.FileName = "msinfo32.exe";
            sysInfoCaptureExternalProcess.StartInfo.Arguments = "/report.txt";
            sysInfoCaptureExternalProcess.StartInfo.WorkingDirectory = directoryPath;
            sysInfoCaptureExternalProcess.Start();
            sysInfoCaptureExternalProcess.WaitForExit();
            
            //string place = Directory.GetCurrentDirectory();
            System.IO.File.WriteAllLines(place + "writeLines.txt", lines);

        }

        
    }
}
