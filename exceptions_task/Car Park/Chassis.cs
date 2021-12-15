using System;

namespace exceptions_task
{
    public class Chassis
    {
        public int NumberOfWheels { get; set; }
        public string NumberOfChassis { get; set; }
        public double PermissibleLoad { get; set; }

        public Chassis(int numberOfWheels, string numberOfChassis, double permissibleLoad)
        {
            if (numberOfWheels > 0)
            {
                NumberOfWheels = numberOfWheels;
            }
            else
            {
                throw new ArgumentException("Number of wheels must be more then 0!");
            }

            if (String.IsNullOrEmpty(numberOfChassis))
            {
                throw new ArgumentException("You need to enter number of chassis!");
            }
            else
            {
                NumberOfChassis = numberOfChassis;
            }

            if (numberOfWheels > 0)
            {
                PermissibleLoad = permissibleLoad;
            }
            else
            {
                throw new ArgumentException("Permissible load must be more then 0!");
            }
        }

        public override string ToString()
        {
            return $"\nChassis:\nNumber of wheels: {NumberOfWheels}" +
                $"\nNumber of chassis: {NumberOfChassis}\nPermissible load: {PermissibleLoad}";
        }
    }

}
