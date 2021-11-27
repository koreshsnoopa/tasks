using System;
namespace carPark
{
    public class Bus : Transport
    {
        public string RouteNumber { get; set; }


        public Bus(ReciprocatingEngine engine, string routeNumber, Transmission transmission, Chassis chassis)
            : base(transmission, chassis, engine)
        {
            RouteNumber = routeNumber;
        }

        public override string ToString()
        {
            return $"\nBus:\n{transmission}\n{chassis}\n{engine}\nRoute number:\n{RouteNumber}";
        }
    }
}
