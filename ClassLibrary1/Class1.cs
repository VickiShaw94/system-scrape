using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class Class1
    {

        public static void Main()
        {
            string[] lines = { Directory.GetCurrentDirectory()};
            string place =  "C:\\Users\\vs\\Documents\\systemLogs\\";

            //string place = Directory.GetCurrentDirectory();
            System.IO.File.WriteAllLines(place + "writeLines.txt", lines);

        }
    }
}
