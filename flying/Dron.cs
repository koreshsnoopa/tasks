using System;
namespace flying
{
    public class Dron : Flyable, IFlyable
    {
        private const int MaxFlightDistance = 1000; // Maximum flight distance in km
        private const int MaxSpeed = 200; // Maximum speed in km/h
        private const int StopTime = 1; // Stop time in minutes
        private const int Interval = 10; // Interval of stops in minutes

        public static double Speed { get; private set; }

        public Dron(double x, double y, double z, double speed) : base(x, y, z)
        {
            if (speed == 0 || speed > MaxSpeed)
            {
                throw new ArgumentException($"Speed must be less then {MaxSpeed} km/h and morethen 0 km/h!");
            }
            Speed = speed;
        }

        /// <summary>
        /// Method changing the current position to position to fly.
        /// Dron can't fly far then 1000 km that is why if flight distance more than 1000 km method trows Argument exeption
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        public void FlyTo(Cordinate3D coordinateFlyTo)
        {
            if (GetFlightDistance(coordinateFlyTo) > MaxFlightDistance)
            {
                throw new ArgumentException($"Dron can't fly far then {MaxFlightDistance} km!");
            }

                currentPosition.x = coordinateFlyTo.x;
                currentPosition.y = coordinateFlyTo.y;
                currentPosition.z = coordinateFlyTo.z;
        }

        /// <summary>
        /// Method counting flight time between current position and position to fly
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        /// <returns> Flight time </returns>
        public double GetFlyTime(Cordinate3D coordinateFlyTo)
        {
            double time = GetFlightDistance(coordinateFlyTo) / Speed;

            return (int)(time / (Interval / 60) * (StopTime / 60)) + time; // /60 to convert minutes to hours
        }
    }
}
