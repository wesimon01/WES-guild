using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warmups;

namespace Warmups.BLL
{
    public class Arrays
    {
        /* Given an array of ints, return true if 6 appears 
           as either the first or last element in the array. 
           The array will be length 1 or more. 
        */
        public bool FirstLast6(int[] numbers)
        {
            // 0 is always the first index and 
            // Length - 1 of an array is always the last index
            return (numbers[0] == 6 || numbers[numbers.Length - 1] == 6);
        }

        public bool SameFirstLast(int[] numbers)
        {
            int firstElement = numbers[0];
            int lastElement = numbers[numbers.Length - 1];

            if ((numbers.Length >= 1) && (firstElement == lastElement))
            {
                return true;

            }
            return false;

        }

        public int[] MakePi(int n)
        {

            double pi = Math.PI;
            string PIstr = pi.ToString().Remove(1, 1); //remove the decimal point in PI
            char[] chararray = PIstr.ToCharArray();
            int[] PInumbers = new int[n];

            for (int i = 0; i < n; i++)
            {

                PInumbers[i] = int.Parse(chararray[i].ToString());
            }
            return PInumbers;

        }

        public bool commonEnd(int[] a, int[] b) 
        {

            if ((a.Length >= 1) && (b.Length >= 1))
            {

                int aFirst = a[0];
                int aLast = a[a.Length - 1];
                int bFirst = b[0];
                int bLast = b[b.Length - 1];

                if ((aFirst == bFirst) || (aLast == bLast))
                {
                    return true;
                }
            }
            return false;
        }
        
    
        public int Sum(int[] numbers)
        {
            int n = numbers.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {

                sum += numbers[i];

            }
            return sum;
        }

        public int[] RotateLeftArray(int[] numbers)
        {
            int n = numbers.Length;
            int[] rotated = new int[numbers.Length];
            rotated[0] = numbers[1];
            for (int i = 1; i < n; i++)
            {
                if (i + 1 == n)
                {
                    break;
                }

                rotated[i] = numbers[i + 1];

            }
            rotated[numbers.Length - 1] = numbers[0];
            return rotated;
        }

        public int[] Reverse(int[] numbers)
        {
            int[] result = { numbers[2], numbers[1], numbers[0] };
            return result;
        }

        public int[] HigherWins(int[] numbers)
        {
            int arrayMax = 0;
            int n = numbers.Length;
            int[] result = new int[numbers.Length];
            for (int i = 0; i < n; i++)
            {
                if (numbers[i] > arrayMax)
                {
                    arrayMax = numbers[i];
                }
            }

            for (int i = 0; i < n; i++)
            {
                result[i] = arrayMax;
            }
            return result;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {

            if (a.Length == 3 && b.Length == 3)
            {
                int[] result = { a[1], b[1] };
                return result;
            }
            return a;
        }

        public bool HasEven(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int[] KeepLast(int[] numbers)
        {
            int n = numbers.Length;
            int doubleLength = n * 2;
            int[] result = new int[doubleLength];
            result[result.Length - 1] = numbers[numbers.Length - 1];
            return result;
        }

        public bool Double23(int[] numbers)
        {
            int CountTwos = 0;
            int CountThrees = 0;
            int n = numbers.Length;
            for (int i = 0; i < n; i++)
            {
                if (numbers[i] == 2)
                {
                    CountTwos++;
                }

                if (numbers[i] == 3)
                {
                    CountThrees++;
                }
            }
            if ((CountThrees == 2) || (CountTwos == 2))
            {
                return true;
            }
            return false;
        }

        public int[] Fix23(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                if ((numbers[i] == 3) && (numbers[i - 1] == 2))
                {
                    numbers[i] = 0;
                }

            }
            return numbers;
        }

        public bool Unlucky1(int[] numbers)
        {
            int length = numbers.Length;

            if (numbers[1] == 1 && numbers[2] == 3)
                return true;

            if (numbers[0] == 1 && numbers[1] == 3)
                return true;

            if (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3)
                return true;

            return false;

        }

        public int[] make2(int[] a, int[] b)
        {
            
            
            int[] answer = new int[2];

            if (a.Length != 0)
            {
                for (int i = 0; i < a.Length; i++)
                {

                    answer[i] = a[i];
                }
            }

            if(a.Length == 0)
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    answer[i] = b[i];
                }
            }

            if (a.Length == 1)
            {
                answer[1] = b[0];
            }

            return answer;
        }

    }

}










