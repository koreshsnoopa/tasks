using NUnit.Framework;
using Unit_test_frameworks;

namespace SubsequencesFinderTests
{
    public class Tests
    {
        [Test]
        public void GetlenghthOfMaxUnequalSubseqTest1()
        {
            string input = "a";
            var subsequencesFinder = new SubsequencesFinder(input);

            int result = subsequencesFinder.GetlenghthOfMaxUnequalSubseq();
            int expected = 1;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxUnequalSubseqTest2()
        {
            string input = "abcddddda44b45666666a6";
            var subsequencesFinder = new SubsequencesFinder(input);

            int result = subsequencesFinder.GetlenghthOfMaxUnequalSubseq();
            int expected = 5;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxUnequalSubseqTest3()
        {
            string input = string.Empty;

            Assert.Throws<System.ArgumentException>(()
                => new SubsequencesFinder(input).GetlenghthOfMaxUnequalSubseq());
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqLatinLettersTest1()
        {
            string input = "abcddddda44b45666666a6";
            var subsequencesFinder = new SubsequencesFinder(input);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqLatinLetters();
            int expected = 5;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqLatinLettersTest2()
        {
            string input = "a";
            var subsequencesFinder = new SubsequencesFinder(input);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqLatinLetters();
            int expected = 0;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqLatinLettersTest3()
        {
            string input = string.Empty;

            Assert.Throws<System.ArgumentException>(()
                => new SubsequencesFinder(input).GetlenghthOfMaxEqualSubseqLatinLetters());
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqNembersTest1()
        {
            string input = "a";
            var subsequencesFinder = new SubsequencesFinder(input);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqNembers();
            int expected = 0;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqNembersTest2()
        {
            string input = "abcddddda44b45666666a6";
            var subsequencesFinder = new SubsequencesFinder(input);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqNembers();
            int expected = 6;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqNembersTest3()
        {
            string input = string.Empty;

            Assert.Throws<System.ArgumentException>(()
                => new SubsequencesFinder(input).GetlenghthOfMaxEqualSubseqNembers());
        }

    }
}
