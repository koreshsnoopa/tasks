using System;
namespace flying
{

    public class Plane : Flyable, IFlyable
    {
        public const double Speed = 200;
        public const double MaxSpeed = 900;
        public const int DistanceToChangeSpeed = 10;
        public const int SpeedChangeBy = 10;

        public Plane(double x, double y, double z) : base (x, y, z)
        {
        }

        /// <summary>
        /// Method changing the current position to position to fly.
        /// Plane can't fly far rhen 8000 km without refueling that is why if flight distance more than 8000 km method trows Argument exeption
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        public void FlyTo(Cordinate3D coordinateFlyTo)
        {
            if (GetFlightDistance(coordinateFlyTo) > 8000)
            {
                throw new ArgumentException("Plane can't fly far then 8000 km without refueling!");
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
            double time = 0.0;
            double speed = Speed;
            double distance = GetFlightDistance(coordinateFlyTo);

            while (speed < MaxSpeed && distance >= DistanceToChangeSpeed)
            {
                time += DistanceToChangeSpeed / speed;
                speed += SpeedChangeBy;
                distance -= DistanceToChangeSpeed;
            }

            if (distance != 0.0)
            {
                time += distance / speed;
            }
            return time;
        }
    }
}
