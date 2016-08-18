using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loggertest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //// Write info message to log
            //SimpleLog.Info("Test logging started.");

            //// Write warning message to log
            //SimpleLog.Warning("This is a warning.");

            //// Write error message to log
            //SimpleLog.Error("This is an error.");

            SimpleLog.Check();
            SimpleLog.Log("this is the foo");
            SimpleLog.ShowLogFile();



        }
    }
}
