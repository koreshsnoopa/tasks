using System;
namespace flying
{
    public abstract class Flyable
    {
        public static Cordinate3D currentPosition = new Cordinate3D();

        public Flyable(double x, double y, double z)
        {
            currentPosition.x = x;
            currentPosition.y = y;
            currentPosition.z = z;
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
