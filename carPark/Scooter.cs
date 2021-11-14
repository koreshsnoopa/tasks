using System;
namespace carPark
{
    public class Scooter : Transport
    {
        public int NumberOfSeats { get; set; }
        public ElectricEngine engine = new ElectricEngine();

        public Scooter(int numberOfWheels, string numberOfChassis,
            double permissibleLoad, string typeOfTransmission, int numberOfGears,
            string manufacturer, int numberOfSeats, string serialNumber, double power, double volume) : base(numberOfWheels, numberOfChassis,
                permissibleLoad, typeOfTransmission, numberOfGears, manufacturer)
        {
            NumberOfSeats = numberOfSeats;
            engine.Power = power;
            engine.Volume = volume;
            engine.SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"\nScooter:\n{transmission}\n{chassis}\n{engine}\nNumber of seats:\n{NumberOfSeats}";
        }
    }
}
