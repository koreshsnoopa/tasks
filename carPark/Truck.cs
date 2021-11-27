using System;
namespace carPark
{
    public class Truck : Transport
    {
        public double TrunkVolume { get; set; }

        public Truck(double trunkVolume, ReciprocatingEngine engine, Chassis chassis, Transmission transmission)
            : base(transmission, chassis, engine)
        {
            TrunkVolume = trunkVolume;
        }

        public override string ToString()
        {
            return $"\nTruck:\n{transmission}\n{chassis}\n{engine}\nTrunk volume:\n{TrunkVolume}";
        }
    }
}
