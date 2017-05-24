using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ClassLibrary1
{

    public class Class2 { 

    }
    public class Class1
    {
        
        public static void Main()
        {
            Process externalProcess = new Process();

            externalProcess.StartInfo.FileName = "msinfo32.exe";
            string saveLocation =  "C:\\Users\\vs\\Documents\\systemLogs\\";
            externalProcess.StartInfo.Arguments = "/report C:\\Users\vs\\Documents\\systemLogs\\TEST.txt";

                // + saveLocation + "text.NFO";

            externalProcess.StartInfo.UseShellExecute = false;
            externalProcess.StartInfo.WorkingDirectory = saveLocation;
            externalProcess.Start();


            /*

            sysInfoCaptureExternalProcess.StartInfo.UseShellExecute = false;
            sysInfoCaptureExternalProcess.StartInfo.FileName = "msinfo32.exe";
            sysInfoCaptureExternalProcess.StartInfo.Arguments = "/report.txt";
            sysInfoCaptureExternalProcess.StartInfo.WorkingDirectory = place;
            sysInfoCaptureExternalProcess.Start();
            //string place = Directory.GetCurrentDirectory();
            System.IO.File.WriteAllLines(place + "writeLines.txt", lines);

             */   
        }

        
    }
}
