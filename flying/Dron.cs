using System;
namespace flying
{
    public class Dron : Flyable, IFlyable
    {
        public const int MaxFlightDistance = 1000; // Maximum flight distance

        public static double Speed = 50;

        public Dron(double x, double y, double z) : base(x, y, z)
        {
        }

        /// <summary>
        /// Method changing the current position to position to fly.
        /// Dron can't fly far rhen 1000 km that is why if flight distance more than 1000 km method trows Argument exeption
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
            return ((int)(GetFlightDistance(coordinateFlyTo) / Speed * 6)) / 60.0 + GetFlightDistance(coordinateFlyTo) / Speed;
        }
    }
}
