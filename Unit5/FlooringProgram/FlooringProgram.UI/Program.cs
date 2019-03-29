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
            try
            {
                MainMenu menu = new MainMenu();
                menu.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
        }
    }
}
