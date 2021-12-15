using System;
namespace exceptions_task
{
    public class Bus : Transport
    {
        public string RouteNumber { get; set; }


        public Bus(ReciprocatingEngine engine, string routeNumber, Transmission transmission, Chassis chassis)
            : base(transmission, chassis, engine)
        {
            if (String.IsNullOrEmpty(routeNumber))
            {
                throw new ArgumentNullException("You need to input route number!");
            }
            else
            {
                RouteNumber = routeNumber;
            }
        }

        public override string ToString()
        {
            return $"\nBus:\n{transmission}\n{chassis}\n{engine}\nRoute number:\n{RouteNumber}";
        }
    }
}
