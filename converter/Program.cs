using System;

namespace converter
{
    class Program
    {
        static int minBasis = 2;
        static int maxBasis = 20;

        static void Main(string[] args)
        {
            try
            {
                InputValidation(args);
                char plusOrMinus = int.Parse(args[0]) >= 0 ? ' ' : '-';
                int number = Math.Abs(int.Parse(args[0]));

                int basis = int.Parse(args[1]);

                Console.WriteLine($"Result: {plusOrMinus} {Converter(number, basis)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        static string Converter(int number, int basis)
        {
            int size = number > 0 ? (int)Math.Log(number, basis) + 1 : 1;

            char[] res = new char[size];

            int i = 0;

            do
            {
                if (i + 1 == res.Length)
                {
                    res[i] = number % basis < 10 ? (char)(48 + number) : (char)(55 + number); // 48 and 55 is ASCII
                    break;
                }

                res[i] = number % basis < 10 ? (char)(48 + number % basis) : (char)(55 + number % basis); // 48 and 55 is ASCII
                number /= basis;
                i++;
            }
            while (number != 0);

            Array.Reverse(res);

            return new string(res);
        }

        static void InputValidation(string[] args)
        {
            if (args.Length != 2 || args == null)
            {
                throw new IndexOutOfRangeException("You need to input only 2 agruments: number and base of another system!");
            }

            if (!int.TryParse(args[0], out int n) || !int.TryParse(args[1], out int a))
            {
                throw new InvalidCastException("You can input only numbers: number and base of another system!");
            }

            if (int.Parse(args[1]) > 20 || int.Parse(args[1]) < 2)
            {
                throw new ArgumentException($"Base of another system can only be greater than {minBasis} and less than or equal to {maxBasis}!");
            }

        }

    }
}
