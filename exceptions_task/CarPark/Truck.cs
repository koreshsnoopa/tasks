using System;
namespace exceptions_task
{
    public class Truck : Transport
    {
        public double TrunkVolume { get; set; }

        public Truck(double trunkVolume, ReciprocatingEngine engine, Chassis chassis, Transmission transmission, int Id)
            : base(transmission, chassis, engine, Id)
        {
            if (trunkVolume > 0)
            {
                TrunkVolume = trunkVolume;
            }
            else
            {
                throw new InitializationException("Volume of trunk must be more then 0!");
            }
        }

        public override string ToString()
        {
            return $"\nTruck:\n{base.ToString()}\n{transmission}\n{chassis}\n{engine}\nTrunk volume:\n{TrunkVolume}";
        }
    }
}
