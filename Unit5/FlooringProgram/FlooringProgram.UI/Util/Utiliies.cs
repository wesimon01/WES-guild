using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Util
{
    public static class Utilities
    {
        public static DateTime GetDateFromUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n Enter an order date (MM/DD/YYYY) : ");
                string input = Console.ReadLine();
                DateTime date;

                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    return date;

                Console.WriteLine(" That was not a valid date.  Press any key to try again...");
                Console.ReadKey();
            } while (true);
        }

    }
}
