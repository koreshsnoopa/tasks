using System;
namespace exceptions_task
{
    public class Bus : Transport
    {
        public string RouteNumber { get; set; }


        public Bus(ReciprocatingEngine engine, string routeNumber, Transmission transmission, Chassis chassis, int Id)
            : base(transmission, chassis, engine, Id)
        {
            if (String.IsNullOrEmpty(routeNumber))
            {
                throw new InitializationException("You need to input route number!");
            }
            else
            {
                RouteNumber = routeNumber;
            }
        }

        public override string ToString()
        {
            return $"\nBus:\n{base.ToString()}\n{transmission}\n{chassis}\n{engine}\nRoute number:\n{RouteNumber}";
        }
    }
}
