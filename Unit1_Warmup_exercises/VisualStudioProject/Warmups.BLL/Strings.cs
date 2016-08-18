using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Strings
    {
        // Given a string name, e.g. "Bob", return a greeting of the form "Hello Bob!". 
        public string SayHi(string name)
        {
            return string.Format("Hello {0}!", name);
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word)
        {
            string containerStart = container.Substring(0, 2);
            string containerEnd = container.Substring(2, 2);
            return containerStart + word + containerEnd;
        }

        public string MultipleEndings(string str)
        {
            if (str.Length >= 2)
            {
                str = str.Substring(str.Length - 2);
                return str + str + str;
            }
            else
            {
                string result = "Must be at least 2 letters long";
                return result;
            }
        }

        public string FirstHalf(string str)
        {
            int halfValue = (str.Length) / 2;
            str = str.Substring(0, halfValue);
            return str;

        }

        public string TrimOne(string str)
        {
            string NoFirstandLast = str.Substring(1, (str.Length - 2));
            return NoFirstandLast;
        }

        public string LongInMiddle(string a, string b)
        {
            string[] input = { a, b };
            if (a.Length > b.Length) {
                string LongString = a;
                string ShortString = b;
                return ShortString + LongString + ShortString;
            }

            if (b.Length > a.Length)
            {
                string LongString = b;
                string ShortString = a;
                return ShortString + LongString + ShortString;
            }
            return a + b; // LOOK###
        }

        public string Rotateleft2(string str)
        {
            return (str.Substring(2) + str.Substring(0, 2));
        }

        public string RotateRight2(string str)
        {
            int length = str.Length - 2;
            return (str.Substring(length) + str.Substring(0, length));
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                return str.Substring(0, 1);

            }

            else if (fromFront == false)
            {
                return str.Substring(str.Length - 1);


            }
            return str;
        }

        public string MiddleTwo(string str)
        {
            int MiddlePt = (str.Length / 2) - 1;
            return str.Substring(MiddlePt, 2);
        }

        public bool EndsWithLy(string str)
        {
            int length = str.Length - 2;

            if (str.Length >= 2)
            {
                return (str.Substring(length).Equals("ly"));
            }
            else {
                return false;
            }
        }

        public string FrontAndBack(string str, int n)
        {
            int length = (str.Length) - n;
            string Front = str.Substring(0, n);
            string Back = str.Substring(length);
            return Front + Back;
        }

        public string TakeTwoFromPosition(string str, int index)
        {
            if ((index <= str.Length - 2) && (index >= 0))
            {
                return str.Substring(index, 2);
            }
            return str.Substring(0, 2);

        }

        public bool HasBad(string str)
        {
            if (str.Length < 3)
            {
                return false;
            }

            if ((str.Substring(0, 3) == "bad") || (str.Substring(1, 3) == "bad"))
            {
                return true;
            }
            return false;

        }

        public string AtFirst(string str)
        {
            if (str.Length >= 2)
            {
                return str.Substring(0, 2);

            }
            else if (str.Length == 1)
            {
                return (str + "@");
            }
            else
            {
                return "@@";
            }
        }

        public string LastChars(string str1, string str2)
        {
            if (str1 == ""){
                str1 = "@";
                return str1 + str2.Substring(str2.Length - 1);
            }        
        if (str2 == ""){
            str2 = "@";
            return str1.Substring(0, 1) + str2;
        }

            return str1.Substring(0, 1) + str2.Substring(str2.Length-1);

        }

        public string ConCat(string a, string b)
        {

            if(a == "")
            {
                return a + b;
            }
            if (b == "")
            {
                return a + b;
            }
            if (a.Substring(a.Length-1) == b.Substring(0, 1))
            {
                return a + b.Substring(1);
            }

            return a + b;
        }

        public string SwapLast(string str)
        {
                if (str.Length >= 2) {
                string nextToLastChar = str.Substring(str.Length - 2, 1);
                string lastChar = str.Substring(str.Length - 1, 1);
                return str.Substring(0, str.Length - 2) + lastChar + nextToLastChar;
                    
                    }
            return str;
        }
        public bool FrontAgain(string str)
        {
            if(str.Substring(0,2) == str.Substring(str.Length - 2))
            {

                return true;
            }
            return false;
        }

        public string MinCat(string a, string b)
        {
            if(a.Length > b.Length)
            {
                return a.Substring(a.Length-b.Length) + b;
            }
                
            if(a.Length < b.Length)
            {

                return a + b.Substring(b.Length - a.Length);
            }

                    return a + b;
        }

        public string TweakFront(string str)
        {
            if ((str.Substring(0, 1) == "a") && (str.Substring(1, 1) == "b"))

                return str;

            if ((str.Substring(0, 1) == "a") && (str.Substring(1, 1) != "b")) {

                return str.Substring(0,1) + str.Substring(2);
            }

            if ((str.Substring(1,1) == "b") && (str.Substring(0,1) != "a"))
            {
                return str.Substring(1);
            }

            return str.Substring(2);
        }

        public string StripX(string str)
        {
            if ((str.Substring(0, 1) == "x") && (str.Substring(str.Length - 1) == "x"))
            {
                return str.Substring(1, str.Length - 2);
            }

            if ((str.Substring(0, 1) == "x") && (str.Substring(str.Length - 1) != "x"))
            {
                return str.Substring(1);
            }

            if ((str.Substring(0, 1) != "x") && (str.Substring(str.Length - 1) == "x")){
                return str.Substring(0, str.Length - 1);
            }

            return str;
                    }
    }
}

