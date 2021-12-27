using System;
using System.Linq;

namespace Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isYes = true;
            AutoShow autoShow = AutoShow.GetInstance();
            string temp;
            string? enteredString;
            string[] parameters;
            do
            {
                Console.WriteLine("Enter information about the car in the form: brand, model, quantity, cost.");
                enteredString = Console.ReadLine();
                parameters = TransformInput(enteredString);
                try
                {
                    autoShow.Autos.Add(new Car(parameters[0], parameters[1], int.Parse(parameters[2]), double.Parse(parameters[3])));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
              
                try
                {
                    Console.WriteLine("Do you want to add another car?\n1. Yes\n2. No");
                    if (InputCheckout(2, Console.ReadLine()) == 2)
                    {
                        isYes = false;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

            }
            while (isYes);

            isYes = true;
            int numberOfCommand = 0;
            Invoker invoker = new Invoker();
            do
            {
                Console.WriteLine("Input number of command:\n1.Count types\n2.Count all\n3.Average price\n4.Average price type\n5.Exit");

                try
                {
                    numberOfCommand = InputCheckout(5, Console.ReadLine());
                    ChooseCommandFromMenu(numberOfCommand, autoShow, invoker);
                }
                catch(ArgumentNullException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                if (numberOfCommand == 5) break;
            }
            while (isYes);

            Console.WriteLine("qw");
        }

        static void ChooseCommandFromMenu(int numberOfCommand, AutoShow autoShow, Invoker invoker)
        {
            switch (numberOfCommand)
            {
                case 1:
                    invoker.SetCommand(new CCountTypes(autoShow));
                    invoker.DoCommand();
                    break;
                case 2:
                    invoker.SetCommand(new CCountAll(autoShow));
                    invoker.DoCommand();
                    break;
                case 3:
                    invoker.SetCommand(new CAveragePrice(autoShow));
                    invoker.DoCommand();
                    break;
                case 4:
                    Console.WriteLine("Input type:");
                    invoker.SetCommand(new CAveragePriceOfType(autoShow, Console.ReadLine()));
                    invoker.DoCommand();
                    break;
            }
        }

        static int InputCheckout(int number, string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException($"Input number from 1 to {number}!");
            }

            for (int i = 1; i <= number; i++)
            {
                if (int.TryParse(input, out int a) && input == i.ToString())
                {
                    return i;
                }
            }

            throw new ArgumentException($"Input number from 1 to {number}!");
        }

        static string[] TransformInput(string enteredString)
        {
            if (enteredString.Split(", ").Length != 4 || String.IsNullOrEmpty(enteredString))
            {
                throw new ArgumentException("Number of parameters must be 4!");
            }

            foreach (string str in enteredString.Split(", "))
            {
                if (String.IsNullOrEmpty(str))
                {
                    throw new ArgumentException("Parameter can't be empty!");
                }
            }

            if (!int.TryParse(enteredString.Split(", ")[2], out int n) || !double.TryParse(enteredString.Split(", ")[3], out double a))
            {
                throw new InvalidCastException("Amount and price must be numbers!");
            }

            string[] parameters = enteredString.Split(", ");

            return parameters;
        }
    }
}
