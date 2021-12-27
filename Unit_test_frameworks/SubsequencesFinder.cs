using System;

namespace Unit_test_frameworks
{
    public class SubsequencesFinder
    {
        string FirstString;
        public SubsequencesFinder(string FirstString)
        {
            if(string.IsNullOrEmpty(FirstString))
            {
                throw new ArgumentNullException("String can't be empty!");
            }
            this.FirstString = FirstString;
        }

        public int FindlenghthOfMaxUnequalSubsequence()
        {
            int max = 0;
            int temp = 1;

            for (int i = 0; i < FirstString.Length - 1; i++)
            {
                if (FirstString[i] != FirstString[i + 1])
                {
                    temp++;
                    if (temp > max)
                    {
                        max = temp;
                    }
                    continue;
                }

                temp = 1;
            }
            return max;
        }

        public int FindlenghthOfMaxEqualSubsequenceLatinLetters()
        {
            int max = 0;
            int temp = 1;
            string str = FirstString.ToLower();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1] && str[i] >= 97 && str[i] <= 122)
                {
                    temp++;
                    if (temp > max)
                    {
                        max = temp;
                    }
                    continue;
                }

                temp = 1;
            }
            return max;
        }

        public int FindlenghthOfMaxEqualSubsequenceNembers()
        {
            int max = 0;
            int temp = 1;
            string str = FirstString.ToLower();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1] && int.TryParse(str[i].ToString(), out int n))
                {
                    temp++;
                    if (temp > max)
                    {
                        max = temp;
                    }
                    continue;
                }

                temp = 1;
            }
            return max;
        }
    }
}
