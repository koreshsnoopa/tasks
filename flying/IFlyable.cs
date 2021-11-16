using System;
namespace flying
{
    public interface IFlyable
    {

        public void FlyTo(Cordinate3D coordinateFlyTo);
        public double GetFlyTime(Cordinate3D coordinateFlyTo);

    }
}
