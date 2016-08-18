using NUnit.Framework;
using Warmups.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Warmups.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        //FirstLast6
        [TestCase(new int[] { 1, 2, 6 }, true)]
        [TestCase(new int[] { 6, 1, 2, 3 }, true)]
        [TestCase(new int[] { 13, 6, 1, 2, 3 }, false)]
        public void FirstLast6Test(int[] numbers, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.FirstLast6(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //SameFirstLast({ 1, 2, 3}) -> false
        //SameFirstLast({ 1, 2, 3, 1}) -> true
        //SameFirstLast({ 1, 2, 1}) -> true        
        [TestCase(new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { 1, 2, 3, 1 }, true)]
        [TestCase(new int[] { 1, 2, 1 }, true)]
        public void SameFirstLast(int[] numbers, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.SameFirstLast(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //MakePi(3) -> {3, 1, 4}
        [TestCase(3, new int[] { 3, 1, 4 })]
        public void MakePi(int n, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.MakePi(n);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //CommonEnd({ 1, 2, 3}, {7, 3}) -> true
        //CommonEnd({ 1, 2, 3}, {7, 3, 2}) -> false
        //CommonEnd({ 1, 2, 3}, {1, 3}) -> true     
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 7, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 7, 3, 2 }, false)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3 }, true)]

        public void commonEnd(int[] numbers1, int[] numbers2, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.commonEnd(numbers1, numbers2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Sum({ 1, 2, 3}) -> 6
        //Sum({ 5, 11, 2}) -> 18
        //Sum({ 7, 0, 0}) -> 7
        [TestCase(new int[] { 1, 2, 3 }, 6)]
        [TestCase(new int[] { 5, 11, 2 }, 18)]
        [TestCase(new int[] { 7, 0, 0 }, 7)]

        public void Sum(int[] numbers, int expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int actual = obj.Sum(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //RotateLeft({ 1, 2, 3}) -> {2, 3, 1}
        //RotateLeft({ 5, 11, 9}) -> {11, 9, 5}
        //RotateLeft({ 7, 0, 0}) -> {0, 0, 7}
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, 1 })]
        [TestCase(new int[] { 5, 11, 9 }, new int[] { 11, 9, 5 })]
        [TestCase(new int[] { 7, 0, 0 }, new int[] { 0, 0, 7 })]

        public void RotateLeftArray(int[] numbers, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.RotateLeftArray(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Reverse
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 5, 4 })]
        [TestCase(new int[] { 7, 8, 9 }, new int[] { 9, 8, 7 })]
        public void Reverse(int[] numbers, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.Reverse(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //HigherWins({ 1, 2, 3}) -> {3, 3, 3}
        //HigherWins({ 11, 5, 9}) -> {11, 11, 11}
        //HigherWins({ 2, 11, 3}) -> {3, 3, 3}
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 3, 3 })]
        [TestCase(new int[] { 11, 5, 9 }, new int[] { 11, 11, 11 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 6 })]
        public void HigherWins(int[] numbers, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.HigherWins(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //GetMiddle({ 1, 2, 3}, {4, 5, 6}) -> {2, 5}
        //GetMiddle({ 7, 7, 7}, {3, 8, 0}) -> {7, 8}
        //GetMiddle({ 5, 2, 9}, {1, 4, 5}) -> {2, 4}
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 2, 5 })]
        [TestCase(new int[] { 7, 7, 7 }, new int[] { 3, 8, 0 }, new int[] { 7, 8 })]
        [TestCase(new int[] { 5, 2, 9 }, new int[] { 1, 4, 5 }, new int[] { 2, 4 })]
        public void GetMiddle(int[] numbers1, int[] numbers2, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.GetMiddle(numbers1, numbers2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //HasEven({ 2, 5}) -> true
        //HasEven({ 4, 3}) -> true
        //HasEven({ 7, 5}) -> false
        [TestCase(new int[] { 2, 5 }, true)]
        [TestCase(new int[] { 4, 3 }, true)]
        [TestCase(new int[] { 7, 5 }, false)]
        public void HasEven(int[] numbers, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.HasEven(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //KeepLast({ 4, 5, 6}) -> {0, 0, 0, 0, 0, 6}
        //KeepLast({ 1, 2}) -> {0, 0, 0, 2}
        //KeepLast({3}) -> {0, 3}
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 0, 0, 0, 0, 0, 6 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 0, 0, 0, 2 })]
        [TestCase(new int[] { 3 }, new int[] { 0, 3 })]
        public void KeepLast(int[] numbers, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.KeepLast(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Double23({ 2, 2, 3}) -> true
        //Double23({ 3, 4, 5, 3}) -> true
        //Double23({ 2, 3, 2, 2}) -> false
        [TestCase(new int[] { 2, 2, 3 }, true)]
        [TestCase(new int[] { 3, 4, 5, 3 }, true)]
        [TestCase(new int[] { 2, 3, 2, 2 }, false)]
        public void Double23(int[] numbers, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.Double23(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Fix23({ 1, 2, 3}) ->{1, 2, 0}
        //Fix23({ 2, 3, 5}) -> {2, 0, 5}
        //Fix23({ 1, 2, 1}) -> {1, 2, 1}
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 0 })]
        [TestCase(new int[] { 2, 3, 5 }, new int[] { 2, 0, 5 })]
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 1, 2, 1 })]
        public void Fix23(int[] numbers, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.Fix23(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Unlucky1({ 1, 3, 4, 5}) -> true
        //Unlucky1({ 2, 1, 3, 4, 5}) -> true
        //Unlucky1({ 1, 1, 1}) -> false
        [TestCase(new int[] { 1, 3, 4, 5 }, true)]
        [TestCase(new int[] { 2, 1, 3, 4, 5 }, true)]
        [TestCase(new int[] { 1, 1, 1 }, false)]
        public void Unlucky1(int[] numbers, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.Unlucky1(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Make2({ 4, 5}, {1, 2, 3}) -> {4, 5}
        //Make2({ 4}, {1, 2, 3}) -> {4, 1}
        //Make2({ }, {1, 2}) -> {1, 2}
        [TestCase(new int[] { 4, 5 }, new int[] { 1, 2, 3 }, new int[] { 4, 5 })]
        [TestCase(new int[] { 4 }, new int[] { 1, 2, 3 }, new int[] { 4, 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2 }, new int[] { 1, 2 })]
        public void make2(int[] numbers1, int[] numbers2, int[] expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            int[] actual = obj.make2(numbers1, numbers2);

            // assert
            Assert.AreEqual(expected, actual);
        }


    }
}
