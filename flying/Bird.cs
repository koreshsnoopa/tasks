using System;
namespace flying
{
    public class Bird : Flyable, IFlyable
    {
        public const double MaxFlightTime = 4;
        public const int MaxSpeed = 20;
        public const int MinSpeed = 0;

        public int Speed { get; set; }

        public Bird(double x, double y, double z) : base(x, y, z)
        {
            Speed = SpeedGenerator();
        }

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

        private int SpeedGenerator()
        {
            Random rand = new Random();
            return rand.Next(MinSpeed, MaxSpeed + 1);
        }

        public double GetFlyTime(Cordinate3D coordinateFlyTo)
        {
            return GetFlightDistance(coordinateFlyTo) / Speed;
        }
    }
}
