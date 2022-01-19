using System;
using System.Collections.Generic;

namespace Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isYes = true;
            AutoShow autoShow = AutoShow.GetInstance();
            string? enteredString;
            string[] parameters;
            do
            {
                try
                {
                    Console.WriteLine("Do you want to add a car?\n1. Yes\n2. No");
                    if (InputCheckout(2, Console.ReadLine()) == 2)
                    {
                        isYes = false;
                        break;
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.WriteLine("Enter information about the car in the form: brand, model, quantity, cost.");
                enteredString = Console.ReadLine();

                try
                {
                    parameters = TransformInput(enteredString);
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            while (isYes);

            if (autoShow.Autos.Count != 0) isYes = true;

            int numberOfCommand = 0;
            Invoker invoker = new Invoker();
            var Commands = new Queue<ICommand>();

            while (isYes)
            {
                Console.WriteLine("Input number of command:\n1.Count types\n2.Count all\n3.Average price\n4.Average price type\n5.Execute\n6.Exit");

                try
                {
                    numberOfCommand = InputCheckout(6, Console.ReadLine());

                    if (numberOfCommand == 5)
                    {
                        while (Commands.Count != 0)
                        {
                            invoker.SetCommand(Commands.Dequeue());
                            invoker.DoCommand();
                        }
                        continue;
                    }

                    Commands.Enqueue(ChooseCommandFromMenu(numberOfCommand, autoShow, invoker));

                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                if (numberOfCommand == 6) isYes = false;
            }
            
        }

        static ICommand ChooseCommandFromMenu(int numberOfCommand, AutoShow autoShow, Invoker invoker)
        {
            switch (numberOfCommand)
            {
                case 1:
                    return new CCountTypes(autoShow);
                case 2:
                    return new CCountAll(autoShow);
                case 3:
                    return new CAveragePrice(autoShow);
                case 4:
                    Console.WriteLine("Input type:");
                    return new CAveragePriceOfType(autoShow, Console.ReadLine());
            }

            return null;
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
