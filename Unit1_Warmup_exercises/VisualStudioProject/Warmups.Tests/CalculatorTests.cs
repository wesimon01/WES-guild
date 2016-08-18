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
    class CalculatorTests
    {

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("5,5,5", 15)]
        [TestCase("5\n5,5", 15)]
        public void AddTest(string numbers, int expected)
        {
            Calculator calc = new Calculator();

            int actual = calc.Add(numbers);

            // assert
            Assert.AreEqual(expected, actual);

        }


    }
}
