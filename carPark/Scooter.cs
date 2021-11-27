using System;
namespace carPark
{
    public class Scooter : Transport
    {
        public int NumberOfSeats { get; set; }

        public Scooter(int numberOfSeats, ElectricEngine engine, Chassis chassis, Transmission transmission)
            : base(transmission, chassis, engine)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"\nScooter:\n{transmission}\n{chassis}\n{engine}\nNumber of seats:\n{NumberOfSeats}";
        }
    }
}
