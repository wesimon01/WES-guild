using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class LogicTests
    {
        //greatparty test
        [TestCase(30, false, false)]
        [TestCase(50, false, true)]
        [TestCase(70, true, true)]
        public void GreatPartyTest(int cigars, bool isWeekend, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.GreatParty(cigars, isWeekend);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //CanHazTable(5, 10) → 2
        //CanHazTable(5, 2) → 0
        //CanHazTable(5, 5) → 1
        [TestCase(5, 10, 2)]
        [TestCase(5, 2, 0)]
        [TestCase(5, 5, 1)]
        public void CanHazTable(int a, int b, int expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            int actual = obj.CanHazTable(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //PlayOutside(70, false) → true
        //PlayOutside(95, false) → false
        //PlayOutside(95, true) → true
        [TestCase(70, false, true)]
        [TestCase(95, false, false)]
        [TestCase(95, true, true)]
        public void PlayOutside(int a, bool b, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.PlayOutside(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //CaughtSpeeding(60, false) → 0
        //CaughtSpeeding(65, false) → 1
        //CaughtSpeeding(65, true) → 0
        [TestCase(60, false, 0)]
        [TestCase(65, false, 1)]
        [TestCase(65, true, 0)]
        public void CaughtSpeeding(int a, bool b, int expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            int actual = obj.CaughtSpeeding(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }
        
        //SkipSum(3, 4) → 7
        //SkipSum(9, 4) → 20
        //SkipSum(10, 11) → 21
        [TestCase(3, 4, 7)]
        [TestCase(9, 4, 20)]
        [TestCase(10, 11, 21)]
        public void SkipSum(int a, int b, int expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            int actual = obj.SkipSum(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //AlarmClock(1, false) → "7:00"
        //AlarmClock(5, false) → "7:00"
        //AlarmClock(0, false) → "10:00"
        [TestCase(1, false, "7:00")]
        [TestCase(5, false, "7:00")]
        [TestCase(0, false, "10:00")]
        public void AlarmClock(int a, bool b, string expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            string actual = obj.AlarmClock(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //LoveSix(6, 4) → true
        //LoveSix(4, 5) → false
        //LoveSix(1, 5) → true
        [TestCase(6, 4, true)]
        [TestCase(4, 5, false)]
        [TestCase(1, 5, true)]
        public void LoveSix(int a, int b, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.LoveSix(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //InRange(5, false) → true
        //InRange(11, false) → false
        //InRange(11, true) → true
        [TestCase(5, false, true)]
        [TestCase(11, false, false)]
        [TestCase(11, true, true)]
        public void InRange(int a, bool b, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.InRange(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //SpecialEleven(22) → true
        //SpecialEleven(23) → true
        //SpecialEleven(24) → false
        [TestCase(22, true)]
        [TestCase(23, true)]
        [TestCase(24, false)]
        public void SpecialEleven(int a, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.SpecialEleven(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Mod20(20) → false
        //Mod20(21) → true
        //Mod20(22) → true
        [TestCase(20, false)]
        [TestCase(21, true)]
        [TestCase(22, true)]
        public void Mod20(int a, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.Mod20(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Mod35(3) → true
        //Mod35(10) → true
        //Mod35(15) → false
        [TestCase(3, true)]
        [TestCase(10, true)]
        [TestCase(15, false)]
        public void Mod35(int a, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.Mod35(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //AnswerCell(false, false, false) → true
        //AnswerCell(false, false, true) → false
        //AnswerCell(true, false, false) → false
        [TestCase(false, false, false, true)]
        [TestCase(false, false, true, false)]
        [TestCase(true, false, false, false)]
        public void AnswerCell(bool a, bool b, bool c, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.AnswerCell(a, b, c);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //TwoIsOne(1, 2, 3) → true
        //TwoIsOne(3, 1, 2) → true
        //TwoIsOne(3, 2, 2) → false
        [TestCase(1, 2, 3, true)]
        [TestCase(3, 1, 2, true)]
        [TestCase(3, 2, 2, false)]
        public void TwoIsOne(int a, int b, int c, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.TwoIsOne(a, b, c);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //AreInOrder(1, 2, 4, false) → true
        //AreInOrder(1, 2, 1, false) → false
        //AreInOrder(1, 1, 2, true) → true
        [TestCase(1, 2, 4, false, true)]
        [TestCase(1, 2, 1, false, false)]
        [TestCase(1, 1, 2, true, true)]
        public void AreInOrder(int a, int b, int c, bool d, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.AreInOrder(a, b, c, d);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //InOrderEqual(2, 5, 11, false) → true
        //InOrderEqual(5, 7, 6, false) → false
        //InOrderEqual(5, 5, 7, true) → true
        [TestCase(2, 5, 11, false, true)]
        [TestCase(5, 7, 6, false, false)]
        [TestCase(5, 5, 7, true, true)]
        public void InOrderEqual(int a, int b, int c, bool d, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.InOrderEqual(a, b, c, d);

            // assert
            Assert.AreEqual(expected, actual);
        }
        
        //LastDigit(23, 19, 13) → true
        //LastDigit(23, 19, 12) → false
        //LastDigit(23, 19, 3) → true
        [TestCase(23, 19, 13, true)]
        [TestCase(23, 19, 12, false)]
        [TestCase(23, 19, 3, true)]
        public void LastDigit(int a, int b, int c, bool expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            bool actual = obj.LastDigit(a, b, c);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //RollDice(2, 3, true) → 5
        //RollDice(3, 3, true) → 7
        //RollDice(3, 3, false) → 6
        [TestCase(2, 3, true, 5)]
        [TestCase(3, 3, true, 7)]
        [TestCase(3, 3, false, 6)]
        public void RollDice(int a, int b, bool c, int expected)
        {
            // arrange
            Logic obj = new Logic();

            // act
            int actual = obj.RollDice(a, b, c);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
