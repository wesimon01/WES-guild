using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace FlooringProgram.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Execute();
        }
    }
}
