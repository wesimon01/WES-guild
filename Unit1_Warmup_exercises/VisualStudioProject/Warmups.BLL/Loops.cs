using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Loops
    {
        /* Given a string and a non-negative int n, return a 
           larger string that is n copies of the original string. 
        */
        //StringTimes
        public string StringTimes(string str, int n)
        {
            string result = "";

            for (int i = 1; i <= n; i++)
            {
                result += str;
            }

            return result;
        }

        public string FrontTimes(string str, int n)
        {
            string answer = "";
            string fail = "number must be positive";
            if (n > 0)
            {
                if (str.Length >= 3)
                {
                    string Repeat = str.Substring(0, 3);
                    StringBuilder Repeat1 = new StringBuilder();
                    for (int i = 0; i < n; i++)
                    {
                        Repeat1.Append(Repeat);
                    }
                    answer = Repeat1.ToString();
                }

                if (str.Length > 0 && str.Length <= 2)
                {
                    string Repeat = str.Substring(0, n);
                    StringBuilder Repeat2 = new StringBuilder();
                    for (int i = 0; i < n; i++)
                    {
                        Repeat2.Append(Repeat);
                    }
                    answer = Repeat2.ToString();
                }
                return answer;
            }
            return fail;
    }

        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 <= str.Length - 1) // make sure not out of bounds of array
                {
                    if (str.Substring(i, 2).Equals("xx"))
                        count++;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {
            int firstXindex = 0;
            int n = str.Length - 1;
            for (int i = 0; i < n; i++)
            {
                if (str.Substring(i, 1).Equals("x"))
                {
                    firstXindex = i;
                    break;
                }
            }
                if (str.Substring(firstXindex + 1, 1).Equals("x") == true)
                {
                    return true;
                }
                return false;                           
            }

        public string EveryOther(string str)
        {
            int n = 2;
            StringBuilder EveryOther = new StringBuilder();
            for (int i = 0; i < str.Length; i+=n)
            {
                string charAtIndex = str.Substring(i, 1);
                EveryOther.Append(charAtIndex);

            }
            string answer = EveryOther.ToString();
            return answer;
        }

        public string StringSplosion(string str)
        {
            StringBuilder Splosion = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                string StringPiece = str.Substring(0, i+1);
                Splosion.Append(StringPiece);
            }
            string answer = Splosion.ToString();
            return answer;
        }

        public int CountLast2(string str)
        {
            int XXcount = 0;
            for (int i = 0; i < str.Length - 2; i++)
            {
                char str1 = str[i];
                char str2 = str[i + 1];
                if ((str1 == 'x') && (str2 == 'x'))
                {
                    XXcount++;
                }
            }
            return XXcount++;
        }

        public int Count9(int[] numbers)
        {
            int count9 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                    count9++;
            }
            return count9;
        }

        public bool ArrayFront9(int[] numbers)
        {
            int searchLength = 4;
            for (int i = 0; i < searchLength; i++)
                if(numbers[i] == 9)
                {
                    return true;    
                }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 2 <= numbers.Length - 1) //make sure not out of bounds of array
                {
                    if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                        return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int counter = 0;
            int n = b.Length-1;
            for (int i = 0; i < n; i++)
            {
                string Sub2A = a.Substring(i, 2);
                string Sub2B = b.Substring(i, 2);
                if (Sub2A == Sub2B)
                {
                    counter++;
                }
            }
            return counter;
        }

        public string StringX(string str)
        {
            string noXstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != 'x')
                {
                    noXstr += str[i];
                }
                if ((str[i] == 'x' && i == 0) || (str[i] == 'x' && i == str.Length - 1))
                {
                    noXstr += str[i];
                }
            }          
            return noXstr;
        }

        public string AltPairs(string str)
        {
            string char1;
            string char2;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i += 4)
            {
                char1 = str.Substring(i, 1);
                builder.Append(char1);

                if (i + 1 == str.Length)
                    break;

                char2 = str.Substring(i+1, 1);
                builder.Append(char2);
            }
            string answer = builder.ToString();
            return answer;
        }

        public string DoNotYak(string str)
        {
            int length = str.Length;
            int i = 0;
            char ch;
            StringBuilder builder = new StringBuilder(length);
            while (i < length)
            {
                ch = str[i];
                if (i + 2 < length && ch == 'y' && str[i+2] == 'k')
                    i += 3;
                else
                {
                    builder.Append(ch);
                    i++;
                }
            }
            return builder.ToString();
        }

        public int Array667(int[] numbers)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 1 < numbers.Length)
                {
                    if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                        counter++;
                    continue;
                }
                break;
            }
            return counter;
        }

        public bool NoTriples(int[] numbers)
        {
            int tripleCount = 0;

            for (int i = 0; i < numbers.Length; i++) {
                if (i + 2 < numbers.Length)
                {
                    if (numbers[i] == numbers[i + 1] && numbers[i + 2] == numbers[i + 1])
                        tripleCount++;
                    continue;
                }
                break;
            }
            if (tripleCount == 0)
                return true;

            return false;
        }

        public bool Pattern51(int[] numbers)
        {         
            int i = 0;
            while (i + 2 < numbers.Length)
            {

                if ((numbers[i] + 5 == numbers[i + 1]) && (numbers[i + 2] == numbers[i] - 1))
                {
                      return true;      
                }                 
                i++;
            }
            return false;
        }
    }
}
    

