using System;
namespace collections
{
    public class Scooter : Transport
    {
        public int NumberOfSeats { get; set; }
        public ElectricEngine engine;

        public Scooter(int numberOfSeats, ElectricEngine engine, Chassis chassis, Transmission transmission)
            : base(transmission, chassis, engine)
        {
            NumberOfSeats = numberOfSeats;
            this.engine = engine;
        }

        public override string ToString()
        {
            return $"\nScooter:\n{transmission}\n{chassis}\n{engine}\nNumber of seats:\n{NumberOfSeats}";
        }
    }
}
