using System;
namespace carPark
{
    public class Car : Transport
    {
        public string Color { get; set; }
        public ElectricEngine engine;


        public Car(string color, ElectricEngine engine, Chassis chassis, Transmission transmission) : base(transmission, chassis, engine)
        {
            Color = color;
            this.engine = engine;
        }

        public override string ToString()
        {
            return $"\nCar:\n{transmission}\n{chassis}\n{engine}\nColor:\n{Color}";
        }
    }
}
