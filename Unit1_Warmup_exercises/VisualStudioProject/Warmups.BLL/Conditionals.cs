using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Conditionals
    {
        /* We have two children, a and b, and the parameters aSmile and 
           bSmile indicate if each is smiling. We are in trouble if they 
           are both smiling or if neither of them is smiling. Return true 
           if we are in trouble. 
        */

        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile && bSmile)
                return true;

            if (!aSmile && !bSmile)
                return true;

            return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if ((isWeekday == false) || (isVacation == true))
            {
                return true;
            }
            return false;

        }

        public int SumDouble(int a, int b)
        {
            if ( a == b){
                return (a + b) * 2;
            }
            return a + b;
        }

        public int Diff21(int n)
        {
            if (n > 21){
                return Math.Abs(n - 21) * 2;
            }
            return Math.Abs(n - 21);


        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if ((isTalking == true) && ((hour < 7) || (hour > 20)))
            {
                return true;
            }
            return false;

        }

        public bool Makes10(int a, int b)
        {
            if ((a == 10) || (b == 10) || ((a + b) == 10))
            {
                return true;

            }
            return false;
        }

        public bool NearHundred(int n)
        {
            if ((Math.Abs(200 - n) <= 10) || (Math.Abs(100 - n) <= 10))
            {
            return true;
            }
            return false;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if ((a<0 || b < 0) && (a>0 || b>0))
            {
                return true;
            }
            if((negative == true) && (a<0 && b < 0))
            {

                return true;
            }
            return false;
        }

        public string NotString(string s)
        {
            if (s.Length <= 2)
            {
                return "not" + " " + s;
            }
            if (s.Substring(0, 3) == "not")
            {
                return s;
            }
            return "not" + " " + s;
        }

        public string MissingChar(string str, int n)
        {
            string front = str.Substring(0, n);

            string back = str.Substring(n + 1);

            return front + back;
        }

        public string FrontBack(string str)
        {
            if (str.Length >= 2)
            {
                string Front = str.Substring(0,1);

                string Back = str.Substring(str.Length - 1);
                return Back + str.Substring(1, str.Length - 2) + Front;
            }
            return str;
        }

        public string Front3(string str)
        {
            
            if (str.Length >= 3)
            {
                str = str.Substring(0, 3);
                return str + str + str;
            }
            return str+str+str;
        }

        public string BackAround(string str)
        {
            if (str.Length > 1)
            {
                string lastChar = str.Substring(str.Length - 1, 1);
                return lastChar + str + lastChar;
                
            }
            return str + str + str;
        }

        public bool Multiple3or5(int number)
        {
            if ((number % 3 == 0) || (number % 5 == 0))
            {
            return true;
            }
            return false;

        }

        public bool StartHi(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            if (str.Length == 2 && str[0] == 'h' && str[1] == 'i')
                return true;

            if (str[0] == 'h' && str[1] == 'i' && str[2] != ' ')
                return false;

            if (str[0] == 'h' && str[1] == 'i')
                return true;
           
            return false;
        }

        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 > 100 && temp2 < 0) || (temp1 < 0 && temp2 > 100)){
                return true;
            }
            return false;
        }

        public bool Between10and20(int a, int b)
        {
            if ((a<=20 && a>=10) || (b<= 20 && b>= 10)){
                return true;
            }
            return false;
        }

        public bool HasTeen(int a, int b, int c)
        {
            if ((a <= 19 && a >= 13) || (b <= 19 && b >= 13) || (c <= 19 && c >= 13))
            {
                return true;
            }
            return false;
        }

        public bool SoAlone(int a, int b)
        {
            if ((a <= 19 && a >= 13) && (b <= 19 && b >= 13))
            {
                return false;
            }
            else if ((a <= 19 && a >= 13) || (b <= 19 && b >= 13))
            {
                return true;
            }
            return false;
        }

        public string RemoveDel(string str)
        {
            if (str.Substring(1,3) == "del")
            {
                return str.Substring(0, 1) + str.Substring(4);
            }
            return str;
        }

        public bool IxStart(string str)
        {
            if (str.Substring(1,2) == "ix")
            {
                return true;
            }
            return false;
        }

        public string StartOz(string str)
        {
            if ((str.Length >= 2) && (str.Substring(0, 2) == "oz"))
            {
                return str.Substring(0, 2);
            }

            else if ((str.Length >= 2) && (str.Substring(0, 1) != "o") && (str.Substring(1, 1) == "z"))
            {
                return str.Substring(1, 1);
            }
            else if ((str.Length >= 2) && (str.Substring(0, 1) == "o") && (str.Substring(1, 1) != "z"))
            {
                return str.Substring(0, 1);
            }
            else if (str.Length < 2)
            {
                return "string needs to be at least 2 char";
            }
            else
            {
                return "only o and z are kept for the first two char";
            }
}

        public int Max(int a, int b, int c)
        {
            int max = 0;

            if (a > b)
            {
                max = a;   
            }
            else
            {
                max = b;    
            }

            if (c > max)
            {
                max = c;
                return max;
            }
            return max;
        }

        public int Closer(int a, int b)
        {
            int DistanceAto10 = Math.Abs(a - 10);
            int DistanceBto10 = Math.Abs(b - 10);

            if (DistanceAto10 > DistanceBto10)
            {
                return b;
            }
            if (DistanceAto10 < DistanceBto10)
            {
                return a;
            }
            return 0;
        }

        public bool GotE(string str)
        {
            int Ecount = 0;
            for (int i = 0; i < str.Length; i++)
                if (str.Substring(i, 1) == "e")
                {
                    Ecount += 1;
                }
            if ((Ecount <= 3) && (Ecount >= 1))
            {
                return true;
            }
            return false;    
        }

        public string EndUp(string str)
        {
            if (str.Length >= 3)
            {
                return str.Substring(0, str.Length-3) + str.Substring(str.Length-3).ToUpper();

            }
            return str.ToUpper();
        }

        public string EveryNth(string str, int n)
        {
            StringBuilder everyNth = new StringBuilder();
            if (str != "")
            {
                for (int i = 0 ; i < str.Length; i++)
                {
                    if ((i % n) == 0)
                    {
                        everyNth.Append(str.Substring(i, 1));             
                    }                   
                }
                string answer = everyNth.ToString();
                return answer;
            }
            return "string is empty";
       }

    }
    }

