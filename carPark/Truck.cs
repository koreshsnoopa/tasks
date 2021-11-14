using System;
namespace carPark
{
    public class Truck : Transport
    {
        public double TrunkVolume { get; set; }
        public ReciprocatingEngine engine = new ReciprocatingEngine();

        public Truck(int numberOfWheels, string numberOfChassis, double permissibleLoad, string typeOfTransmission, int numberOfGears,
            string manufacturer, double trunkVolume, string serialNumber,
            double power, double volume) : base(numberOfWheels, numberOfChassis, permissibleLoad, typeOfTransmission, numberOfGears, manufacturer)
        {
            TrunkVolume = trunkVolume;
            engine.Power = power;
            engine.Volume = volume;
            engine.SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"\nTruck:\n{transmission}\n{chassis}\n{engine}\nTrunk volume:\n{TrunkVolume}";
        }
    }
}
