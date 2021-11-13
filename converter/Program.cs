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
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine(ioore.Message);
                return;
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
                return;
            }

            int number = Convert.ToInt32(args[0]);

            int basis = Convert.ToInt32(args[1]);

            Console.WriteLine($"Result: {Converter(number, basis)}");

        }

        static string Converter(int number, int basis)
        {
            if (number == 1)
            {
                return "1";
            }

            if (number == 0)
            {
                return "0";
            }

            char[] res = new char[(int)Math.Log(number, basis) + 1];

            int i = 1;

            while (number != 1)
            {
                res[res.Length - i] = number % basis < 10 ? (char)(48 + number % basis) : (char)(55 + number % basis); // 48 and 55 is ASCII
                number /= basis;
                i++;
                if (i == res.Length)
                {
                    res[res.Length - i] = number % basis < 10 ? (char)(48 + number) : (char)(55 + number); // 48 and 55 is ASCII
                    break;
                }
            }

            return new string(res);
        }

        static void InputValidation(string[] args)
        {
            if (args.Length != 2)
            {
                throw new IndexOutOfRangeException("You need to input only 2 agruments: number and base of another system!");
            }

            if (!int.TryParse(args[0], out int n) || !int.TryParse(args[1], out int a))
            {
                throw new InvalidCastException("You can input only numbers: number and base of another system!");
            }

            if (Convert.ToInt32(args[1]) > 20 || Convert.ToInt32(args[1]) < 2)
            {
                throw new ArgumentException($"Base of another system can only be greater than {minBasis} and less than or equal to {maxBasis}!");
            }

        }

    }
}
