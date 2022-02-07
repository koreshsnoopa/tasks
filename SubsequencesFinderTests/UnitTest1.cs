using NUnit.Framework;
using Unit_test_frameworks;

namespace SubsequencesFinderTests
{
    public class Tests
    {
        string OneLetter = "a";
        string NumbersWithLetters = "abcddddda44b45666666a6";
        string EmptyString = string.Empty;

        [Test]
        public void GetlenghthOfMaxUnequalSubseqOneLetter()
        {
            var subsequencesFinder = new SubsequencesFinder(OneLetter);

            int result = subsequencesFinder.GetlenghthOfMaxUnequalSubseq();
            int expected = 1;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxUnequalSubseqTestNumbersWithLetters()
        {
            var subsequencesFinder = new SubsequencesFinder(NumbersWithLetters);

            int result = subsequencesFinder.GetlenghthOfMaxUnequalSubseq();
            int expected = 5;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxUnequalSubseqTestEmptyString()
        {
            Assert.Throws<System.ArgumentException>(()
                => new SubsequencesFinder(EmptyString).GetlenghthOfMaxUnequalSubseq());
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqLatinLettersNumbersWithLetters()
        {
            var subsequencesFinder = new SubsequencesFinder(NumbersWithLetters);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqLatinLetters();
            int expected = 5;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqLatinLettersOneLetter()
        {
            var subsequencesFinder = new SubsequencesFinder(OneLetter);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqLatinLetters();
            int expected = 0;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqLatinLettersEmptyString()
        {
            Assert.Throws<System.ArgumentException>(()
                => new SubsequencesFinder(EmptyString).GetlenghthOfMaxEqualSubseqLatinLetters());
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqNembersOneLetter()
        {
            var subsequencesFinder = new SubsequencesFinder(OneLetter);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqNembers();
            int expected = 0;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqNembersNumbersWithLetters()
        {
            var subsequencesFinder = new SubsequencesFinder(NumbersWithLetters);

            int result = subsequencesFinder.GetlenghthOfMaxEqualSubseqNembers();
            int expected = 6;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetlenghthOfMaxEqualSubseqNembersEmptyString()
        {
            Assert.Throws<System.ArgumentException>(()
                => new SubsequencesFinder(EmptyString).GetlenghthOfMaxEqualSubseqNembers());
        }

    }
}
