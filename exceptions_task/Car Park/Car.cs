using System;
namespace exceptions_task
{
    public class Car : Transport
    {
        public string Color { get; set; }


        public Car(string color, ElectricEngine engine, Chassis chassis, Transmission transmission) : base(transmission, chassis, engine)
        {
            if (String.IsNullOrEmpty(color))
            {
                throw new ArgumentNullException("You need to input car color!");
            }
            else
            {
                Color = color;
            }
        }

        public override string ToString()
        {
            return $"\nCar:\n{transmission}\n{chassis}\n{engine}\nColor:\n{Color}";
        }
    }
}
