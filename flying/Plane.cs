using System;
namespace flying
{

    public class Plane : Flyable, IFlyable
    {
        private const double Speed = 200; // Starting speed in km/h
        private const double MaxSpeed = 900; // Maximum speed in km/h
        private const double MaxFlightDistance = 8000; // Maximum flight distance in km
        private const double MinFlightDistance = 6; // Minimum flight distance in km
        private const int DistanceToChangeSpeed = 10; // Distance through which the speed changes in km
        private const int SpeedChangeBy = 10; // How much the speed changes in km/h

        public Plane(Cordinate3D currentPosition) : base(currentPosition)
        {
        }

        /// <summary>
        /// Method changing the current position to position to fly.
        /// Plane can't fly far rhen 8000 km without refueling that is why if flight distance more than 8000 km or less
        ///  then 6 km method trows Argument exeption
        /// </summary>
        /// <param name="coordinateFlyTo"></param>
        public void FlyTo(Cordinate3D coordinateFlyTo)
        {
            if (GetFlightDistance(coordinateFlyTo) > MaxFlightDistance)
            {
                throw new ArgumentException($"Plane can't fly far then {MaxFlightDistance} km without refueling!");
            }

            if (GetFlightDistance(coordinateFlyTo) > MinFlightDistance)
            {
                throw new ArgumentException($"Plane can't fly less then {MinFlightDistance} km without refueling!");
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
            int speedChangeCount = (int)((MaxSpeed - Speed) / SpeedChangeBy);

            if (GetFlightDistance(coordinateFlyTo) > speedChangeCount * DistanceToChangeSpeed)
            {
                return (GetFlightDistance(coordinateFlyTo) - speedChangeCount * DistanceToChangeSpeed) / MaxSpeed
                    + GetSum(speedChangeCount);
            }

            speedChangeCount = (int)(GetFlightDistance(coordinateFlyTo) / DistanceToChangeSpeed);

            return GetSum(speedChangeCount);
        }

        /// <summary>
        /// Method counting sum of time that plane flying with unequal speeds
        /// </summary>
        /// <param name="n"></param>
        /// <returns> sum </returns>
        private double GetSum(int n)
        {
            double sum = 0.0;

            for (int i = 0; i <= n; i++)
            {
                sum += DistanceToChangeSpeed / (Speed + i * SpeedChangeBy);
            }

            return sum;
        }
    }
}
