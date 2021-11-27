using System;
namespace collections
{
    public class Chassis
    {
        public int NumberOfWheels { get; set; }
        public string NumberOfChassis { get; set; }
        public double PermissibleLoad { get; set; }

        public Chassis(int numberOfWheels, string numberOfChassis, double permissibleLoad)
        {
            NumberOfWheels = numberOfWheels;
            NumberOfChassis = numberOfChassis;
            PermissibleLoad = permissibleLoad;
        }

        public override string ToString()
        {
            return $"\nChassis:\nNumber of wheels: {NumberOfWheels}" +
                $"\nNumber of chassis: {NumberOfChassis}\nPermissible load: {PermissibleLoad}";
        }
    }
}
