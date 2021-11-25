using System;
namespace flying
{
    public abstract class Flyable
    {
        public Cordinate3D currentPosition = new Cordinate3D();

        protected Flyable(Cordinate3D currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        /// <summary>
        /// Method counting distance between current position and position to fly
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        /// <returns> Distance between current position and position to fly </returns>
        protected double GetFlightDistance(Cordinate3D coordinateFlyTo)
        {
            return Math.Sqrt(Math.Pow(coordinateFlyTo.x - currentPosition.x, 2) + Math.Pow(coordinateFlyTo.y - currentPosition.y, 2)
                + Math.Pow(coordinateFlyTo.z - currentPosition.z, 2));
        }
    }
}
