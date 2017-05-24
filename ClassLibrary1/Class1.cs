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
        //instantiating class process
        public static Process externalProcess = new Process();
 
        private static void setFileName(string fileName)
        {
            externalProcess.StartInfo.FileName = fileName;
        }               

        /**
         * Sets Arguments -- string containing the arguments to pass to the target app
         * specified in setFileName property, default empty string ""
         *  
        */

        private static void setSaveLocation(string loc)
        {
            externalProcess.StartInfo.WorkingDirectory = loc;
        }

        public static void Main()
        {

            setFileName("msinfo32.exe");
            //setArguments("/report" + zzz + ".txt");
            externalProcess.StartInfo.Arguments = "/report zzz.txt";

            setSaveLocation(Directory.GetCurrentDirectory);
            externalProcess.Start();


            /*
            string place =  "C:\\Users\\vs\\Documents\\systemLogs\\";

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
