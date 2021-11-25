using System;

namespace subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                lenghthOfMaxUnequalSubsequence(args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
            }

            Console.WriteLine($"Length of max subsequence unequal signs: {lenghthOfMaxUnequalSubsequence(args)}");
        }

        static int lenghthOfMaxUnequalSubsequence(string[] args)
        {
            if (args.Length != 1 || args == null)
            {
                throw new ArgumentException("You can input only one string!");
            }

            string str = args[0];
            int max = 0;
            int temp = 1;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
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
