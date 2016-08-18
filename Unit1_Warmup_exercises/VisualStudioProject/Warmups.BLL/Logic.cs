using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {
        /* When squirrels get together for a party, they like to have cigars. 
           A squirrel party is successful when the number of cigars is between 
           40 and 60, inclusive. Unless it is the weekend, in which case there is 
           no upper bound on the number of cigars. Return true if the party with 
           the given values is successful, or false otherwise. 
        */
        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (isWeekend)
                return cigars > 40;
            else
                return (cigars >= 40 && cigars <= 60);
        }

        public enum Table
        {
            no, maybe, yes
        };

        public int CanHazTable(int yourStyle, int dateStyle)
        {

            if (yourStyle >= 8 || dateStyle >= 8)
            {

                return (int)Table.yes;
            }

            if (yourStyle <= 2 || dateStyle <= 2)
            {

                return (int)Table.no;
            }
            return (int)Table.maybe;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if ((isSummer == true) && (temp >= 60 && temp <= 100))
            {
                return true;
            }

            if ((isSummer == false) && (temp >= 60 && temp <= 90))
            {
                return true;
            }
            return false;
        }

        public enum Ticket { noTicket, smallTicket, bigTicket };

        public int CaughtSpeeding(int speed, bool isBirthday)
        {

            int isBirthdayMod = 5;
            int Speed1 = 60, Speed2 = 81;

            if (isBirthday == true && (speed > Speed1 + isBirthdayMod))
            {
                if (speed > Speed2 + isBirthdayMod)
                    return (int)Ticket.bigTicket;

                if ((speed > Speed1 + isBirthdayMod) && (speed < Speed2 + isBirthdayMod))
                {
                    return (int)Ticket.smallTicket;
                }
                return (int)Ticket.noTicket;
            }

            if (isBirthday == false && (speed > Speed1))
            {
                if (speed > Speed2)
                    return (int)Ticket.bigTicket;

                if ((speed > Speed1) && (speed < Speed2))
                {
                    return (int)Ticket.smallTicket;
                }
                return (int)Ticket.noTicket;
            }
            return (int)Ticket.noTicket;
        }

        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum >= 10 && sum <= 19)
            {
                sum = 20;
                return sum;
            }
            return sum;
        }

        public enum Days { Sun, Mon, Tues, Weds, Thurs, Fri, Sat };

        public string AlarmClock(int day, bool vacation)
        {
            string alarmWork = "7:00";
            string sleepIn = "10:00";
            string NoAlarm = "off";

            if (vacation == true)
            {

                if ((day == (int)Days.Sun || day == (int)Days.Sat))
                {
                    return NoAlarm;
                }
                return sleepIn;

            }

            if (vacation == false)
            {

                if ((day == (int)Days.Sun || day == (int)Days.Sat))
                {
                    return sleepIn;
                }
                return alarmWork;

            }
            return NoAlarm;
        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            if ((a + b) == 6 || (Math.Abs(a - b)) == 6)
            {
                return true;
            }
            return false;
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode == false)
            {
                if (n >= 1 && n <= 10)
                {
                    return true;
                }
                return false;

            }
            if (outsideMode == true)
            {
                if (n <= 1 || n >= 10)
                {
                    return true;
                }
                return false;
            }
            return outsideMode;
        }

        public bool SpecialEleven(int n)
        {
            if (n > 0)
            {
                if (n % 11 == 0 || n % 11 == 1)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool Mod20(int n)
        {
            if (n < 0)
            {
                return false;
            }
            if (n % 20 == 1 || n % 20 == 2)
            {
                return true;
            }
            return false;
        }

        public bool Mod35(int n)
        {
            if (n > 0)
            {
                if (n % 3 == 0 && n % 5 != 0)
                    return true;
                if (n % 5 == 0 && n % 3 != 0)
                    return true;

                return false;
            }
            return false;
        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep == true)
                return false;
            if (isMorning == true)
            {
                if (isMom == true)
                    return true;

                return false;
            }
            return true;
        }

        public bool TwoIsOne(int a, int b, int c)
        {
            
        
            if (a == b + c) return true;
            if (b == a + c) return true;
            if (c == a + b) return true;
            return false;
        
        }

        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (b > a && c > b)
            {
                return true;
            }
            if (bOk == true && c > b)
            {
                return true;
            }
            return false;
        }

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk == false) { 
                if (a < b && b < c)
                {
                    return true;
                }
            return false;

        }
        if(equalOk == true){
                if(a <= b && b <= c)
                {
                    return true;
                }
            return false;
               }
            return false;
        } 

        public bool LastDigit(int a, int b, int c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                string Astring = a.ToString();
                string Aright = Astring.Substring(Astring.Length - 1, 1);
                string Bstring = b.ToString();
                string Bright = Bstring.Substring(Bstring.Length - 1, 1);
                string Cstring = c.ToString();
                string Cright = Cstring.Substring(Cstring.Length - 1, 1);

                if( Aright == Bright || Aright == Cright || Bright == Cright)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;
            if(noDoubles == true && die1 == die2)
            {
                if (die1 == 6)
                {
                    die1 = 1;
                }
                if(die2 == 6)
                {
                    die2 = 1;
                }
                sum = die1 + die2;
                sum++;
            }
            return sum;
        }


    }
}   

