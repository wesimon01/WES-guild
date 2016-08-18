using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class StringCalculatorKataTests
    {
        [TestCase("10,2", 12)]
        [TestCase("100,52", 152)]
        public void TestCalculator(string nums, int expected)
        {
            StringCalculatorKata kata = new StringCalculatorKata();

            int actualResult = kata.Add(nums);

            Assert.AreEqual(expected, actualResult);
        }
    }
}
