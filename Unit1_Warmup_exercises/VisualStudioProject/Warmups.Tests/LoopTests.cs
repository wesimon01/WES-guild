using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class LoopTests
    {
        //StringTimesTest
        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]
        public void StringTimesTest(string str, int n, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.StringTimes(str, n);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //FrontTimes("Chocolate", 2) -> "ChoCho"
        //FrontTimes("Chocolate", 3) -> "ChoChoCho"
        //FrontTimes("Abc", 3) -> "AbcAbcAbc"
        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("Chocolate", 3, "ChoChoCho")]
        [TestCase("Abc", 3, "AbcAbcAbc")]
        public void FrontTimes(string str, int a, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.FrontTimes(str, a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //CountXX("abcxx") -> 1
        //CountXX("xxx") -> 2
        //CountXX("xxxx") -> 3
        [TestCase("abcxx", 1)]
        [TestCase("xxx", 2)]
        [TestCase("xxxx", 3)]
        public void CountXX(string str, int expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            int actual = obj.CountXX(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //DoubleX("axxbb") -> true
        //DoubleX("axaxxax") -> false
        //DoubleX("xxxxx") -> true
        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxxx", true)]
        public void DoubleX(string str, bool expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            bool actual = obj.DoubleX(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //EveryOther("Hello") -> "Hlo"
        //EveryOther("Hi") -> "H"
        //EveryOther("Heeololeo") -> "Hello"
        [TestCase("Hello", "Hlo")]
        [TestCase("Hi", "H")]
        [TestCase("Heeololeo", "Hello")]
        public void EveryOther(string str, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.EveryOther(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //StringSplosion("Code") -> "CCoCodCode"
        //StringSplosion("abc") -> "aababc"
        //StringSplosion("ab") -> "aab"
        [TestCase("Code", "CCoCodCode")]
        [TestCase("abc", "aababc")]
        [TestCase("ab", "aab")]
        public void StringSplosion(string str, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.StringSplosion(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //CountLast2("hixxhi") -> 1
        //CountLast2("xaxxaxaxx") -> 1
        //CountLast2("axxxaaxx") -> 2
        [TestCase("hixxhi", 1)]
        [TestCase("xaxxaxaxx", 1)]
        [TestCase("axxxaaxx", 2)]
        public void CountLast2(string str, int expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            int actual = obj.CountLast2(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Count9({ 1, 2, 9}) -> 1
        //Count9({ 1, 9, 9}) -> 2
        //Count9({ 1, 9, 9, 3, 9}) -> 3
        [TestCase(new int[] { 1, 2, 9 }, 1)]
        [TestCase(new int[] { 1, 9, 9 }, 2)]
        [TestCase(new int[] { 1, 9, 9, 3, 9 }, 3)]
        public void Count9(int[] a, int expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            int actual = obj.Count9(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //ArrayFront9({ 1, 2, 9, 3, 4}) -> true
        //ArrayFront9({ 1, 2, 3, 4, 9}) -> false
        //ArrayFront9({ 1, 2, 3, 4, 5}) -> false
        [TestCase(new int[] { 1, 2, 9, 3, 4 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 9 }, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, false)]
        public void ArrayFront9(int[] a, bool expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            bool actual = obj.ArrayFront9(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Array123({ 1, 1, 2, 3, 1}) -> true
        //Array123({ 1, 1, 2, 4, 1}) -> false
        //Array123({ 1, 1, 2, 1, 2, 3}) -> true
        [TestCase(new int[] { 1, 1, 2, 3, 1 }, true)]
        [TestCase(new int[] { 1, 1, 2, 4, 1 }, false)]
        [TestCase(new int[] { 1, 1, 2, 1, 2, 3 }, true)]
        public void Array123(int[] a, bool expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            bool actual = obj.Array123(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //SubStringMatch("xxcaazz", "xxbaaz") -> 3
        //SubStringMatch("abc", "abc") -> 2
        //SubStringMatch("abc", "axc") -> 0
        [TestCase("xxcaazz", "xxbaaz", 3)]
        [TestCase("abc", "abc", 2)]
        [TestCase("abc", "axc", 0)]
        public void SubStringMatch(string a, string b, int expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            int actual = obj.SubStringMatch(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //StringX("xxHxix") -> "xHix"
        //StringX("abxxxcd") -> "abcd"
        //StringX("xabxxxcdx") -> "xabcdx"
        [TestCase("xxHxix", "xHix")]
        [TestCase("abxxxcd", "abcd")]
        [TestCase("xabxxxcdx", "xabcdx")]
        public void StringX(string str, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.StringX(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //AltPairs("kitten") -> "kien"
        //AltPairs("Chocolate") -> "Chole"
        //AltPairs("CodingHorror") -> "Congrr"
        [TestCase("kitten", "kien")]
        [TestCase("Chocolate", "Chole")]
        [TestCase("CodingHorror", "Congrr")]
        public void AltPairs(string str, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.AltPairs(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //DoNotYak("yakpak") -> "pak"
        //DoNotYak("pakyak") -> "pak"
        //DoNotYak("yak123ya") -> "123ya"
        [TestCase("yakpak", "pak")]
        [TestCase("pakyak", "pak")]
        [TestCase("yak123ya", "123ya")]
        public void DoNotYak(string str, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.DoNotYak(str);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Array667({ 6, 6, 2}) -> 1
        //Array667({ 6, 6, 2, 6}) -> 1
        //Array667({ 6, 7, 2, 6}) -> 1
        [TestCase(new int[] {6, 6, 2}, 1)]
        [TestCase(new int[] {6, 6, 2, 6}, 1)]
        [TestCase(new int[] {6,7,2,6}, 1)]
        public void Array667(int[] a, int expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            int actual = obj.Array667(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //NoTriples({ 1, 1, 2, 2, 1}) -> true
        //NoTriples({ 1, 1, 2, 2, 2, 1}) -> false
        //NoTriples({ 1, 1, 1, 2, 2, 2, 1}) -> false
        [TestCase(new int[] { 1, 1, 2, 2, 1 }, true)]
        [TestCase(new int[] { 1, 1, 2, 2, 2, 1 }, false)]
        [TestCase(new int[] { 1, 1, 1, 2, 2, 2, 1 }, false)]
        public void NoTriples(int[] a, bool expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            bool actual = obj.NoTriples(a);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //Pattern51({ 1, 2, 7, 1}) -> true
        //Pattern51({ 1, 2, 8, 1}) -> false
        //Pattern51({ 2, 7, 1}) -> true
        [TestCase(new int[] { 1, 2, 7, 1 }, true)]
        [TestCase(new int[] { 1, 2, 8, 1 }, false)]
        [TestCase(new int[] { 2, 7, 1 }, true)]
        public void Pattern51(int[] a, bool expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            bool actual = obj.Pattern51(a);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
