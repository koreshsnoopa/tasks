using System;
namespace flying
{
    public class Dron : Flyable, IFlyable
    {
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
            if (GetFlightDistance(coordinateFlyTo) > 1000)
            {
                throw new ArgumentException("Dron can't fly far then 1000 km!");
            }

                currentPosition.x = coordinateFlyTo.x;
                currentPosition.y = coordinateFlyTo.y;
                currentPosition.z = coordinateFlyTo.z;
                Console.WriteLine("Your flying is sucssesful!");
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

        /// <summary>
        /// Method counting distance between current position and position to fly
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        /// <returns> Distance between current position and position to fly </returns>
        public static double GetFlightDistance(Cordinate3D coordinateFlyTo)
        {
            return Math.Sqrt(Math.Pow(coordinateFlyTo.x - currentPosition.x, 2) + Math.Pow(coordinateFlyTo.y - currentPosition.y, 2)
                + Math.Pow(coordinateFlyTo.z - currentPosition.z, 2));
        }
    }
}
