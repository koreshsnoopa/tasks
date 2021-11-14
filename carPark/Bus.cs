using System;
namespace carPark
{
    public class Bus : Transport
    {
        public string RouteNumber { get; set; }
        public ReciprocatingEngine engine = new ReciprocatingEngine();


        public Bus(int numberOfWheels, string numberOfChassis, double permissibleLoad, string typeOfTransmission, int numberOfGears,
           string manufacturer, string routeNumber, string serialNumber,
           double power, double volume) : base(numberOfWheels, numberOfChassis, permissibleLoad, typeOfTransmission, numberOfGears, manufacturer)
        {
            RouteNumber = routeNumber;
            engine.Power = power;
            engine.Volume = volume;
            engine.SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"\nBus:\n{transmission}\n{chassis}\n{engine}\nRoute number:\n{RouteNumber}";
        }
    }
}
