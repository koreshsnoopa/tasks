using System;
namespace flying
{
    public class Bird : Flyable, IFlyable
    {
        public const double MaxFlightTime = 4;

        public static Random rand = new Random();
        public int Speed { get; set; }

        public Bird(double x, double y, double z) : base(x, y, z)
        {
            Speed = rand.Next(0, 51);
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

        public double GetFlyTime(Cordinate3D coordinateFlyTo)
        {
            return GetFlightDistance(coordinateFlyTo) / Speed;
        }
    }
}
