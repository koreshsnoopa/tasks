using System;
namespace exceptions_task
{
    public class Car : Transport
    {
        public string Color { get; set; }


        public Car(string color, ElectricEngine engine, Chassis chassis, Transmission transmission, int Id)
            : base(transmission, chassis, engine, Id)
        {
            if (String.IsNullOrEmpty(color))
            {
                throw new InitializationException("You need to input car color!");
            }
            else
            {
                Color = color;
            }
        }

        public override string ToString()
        {
            return $"\nCar:\n{base.ToString()}\n{transmission}\n{chassis}\n{engine}\nColor:\n{Color}";
        }
    }
}
