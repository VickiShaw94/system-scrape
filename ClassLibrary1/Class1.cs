using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{

    public class Class1
    {
        public static void Main()
        {
            Process externalProcess = new Process();
            externalProcess.StartInfo.FileName = "msinfo32.exe";
            externalProcess.StartInfo.Arguments = "/report " + @".\sysInfo.txt";
            externalProcess.Start();
        }
    }
}
