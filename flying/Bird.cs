using System;
namespace flying
{
    public class Bird : Flyable, IFlyable
    {
        public const double MaxFlightTime = 4; // Maximum flight time
        public const int MaxSpeed = 20; // Maximum speed
        public const int MinSpeed = 0; // Minimum speed

        public int Speed { get; set; }

        public Bird(double x, double y, double z) : base(x, y, z)
        {
            Speed = SpeedGenerator();
        }

        /// <summary>
        /// Method changing the current position to position to fly.
        /// Bird can't fly longer then 4 hours that is why if flight time more than max flight time method trows Argument exeption
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        public void FlyTo(Cordinate3D coordinateFlyTo)
        {
            if (GetFlyTime(coordinateFlyTo) > MaxFlightTime)
            {
                throw new ArgumentException($"Bird can't fly longer then {MaxFlightTime} hours!");
            }

            currentPosition.x = coordinateFlyTo.x;
            currentPosition.y = coordinateFlyTo.y;
            currentPosition.z = coordinateFlyTo.z;
        }

        /// <summary>
        /// Method generate speed between min and max value of it.
        /// </summary>
        /// <returns> Speed </returns>
        private int SpeedGenerator()
        {
            Random rand = new Random();
            return rand.Next(MinSpeed, MaxSpeed + 1);
        }

        /// <summary>
        /// Mathod counting flight time.
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        /// <returns> Flight time </returns>
        public double GetFlyTime(Cordinate3D coordinateFlyTo)
        {
            return GetFlightDistance(coordinateFlyTo) / Speed;
        }
    }
}
