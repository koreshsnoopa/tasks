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
            do
            {
                try
                {
                    AddAuto(autoShow);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.WriteLine("Do you want to add another car?\n1. Yes\n2. No");
                temp = Console.ReadLine();

                if (int.TryParse(temp, out int n))
                {
                    isYes = temp == "1";
                }
            }
            while (isYes);

            Console.WriteLine(autoShow.Autos.Count());
            
        }

        static void AddAuto(AutoShow autoShow)
        {
            string? enteredString;
            string[] parameters;
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
