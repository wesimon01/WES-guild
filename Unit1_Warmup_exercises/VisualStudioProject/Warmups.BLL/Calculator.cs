using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;
            if (numbers.Length == 1)
                return int.Parse(numbers);
            if (numbers.Length > 1) //"1,2"
            {
                string[] items = numbers.Split(',','\n');
                int result = 0;
                foreach (string item in items)
                {
                    result += int.Parse(item);
                }
                return result;

            }
            return 0;
        }
    }
}
