using System;
namespace carPark
{
    public class Car : Transport
    {
        public string Color { get; private set; }
        public ElectricEngine engine = new ElectricEngine();


        public Car(int numberOfWheels, string numberOfChassis, double permissibleLoad,
            string typeOfTransmission, int numberOfGears, string manufacturer, string color,
            string serialNumber, double power, double volume) : base(numberOfWheels, numberOfChassis, permissibleLoad,
             typeOfTransmission, numberOfGears, manufacturer)
        {
            Color = color;
            engine.Power = power;
            engine.Volume = volume;
            engine.SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"\nCar:\n{transmission}\n{chassis}\n{engine}\nColor:\n{Color}";
        }
    }
}
