using System;
namespace flying
{
    public class Bird : Flyable, IFlyable
    {
        //public static double Speed = 50;

        public Bird(double x, double y, double z) : base(x, y, z)
        {
        }

        public void FlyTo(Cordinate3D coordinateFlyTo)
        {
            throw new NotImplementedException();
        }

        public double GetFlyTime(Cordinate3D coordinateFlyTo)
        {
            throw new NotImplementedException();
        }
    }
}
