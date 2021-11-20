using System;
namespace carPark
{
    public class Scooter : Transport
    {
        public int NumberOfSeats { get; set; }
        public ElectricEngine engine = new ElectricEngine();

        public Scooter(int numberOfSeats, ElectricEngine engine, Chassis chassis, Transmission transmission)
            : base(transmission, chassis)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"\nScooter:\n{transmission}\n{chassis}\n{engine}\nNumber of seats:\n{NumberOfSeats}";
        }
    }
}
