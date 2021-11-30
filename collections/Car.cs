using System;
namespace collections
{
    [Serializable]
    public class Car : Transport
    {
        public string Color { get; set; }

        public Car()
        {
        }

        public Car(string color, ElectricEngine engine, Chassis chassis, Transmission transmission) :
            base(transmission, chassis, engine)
        {
            Color = color;
        }

        public override string ToString()
        {
            return $"\nCar:\n{transmission}\n{chassis}\n{engine}\nColor:\n{Color}";
        }
    }
}
