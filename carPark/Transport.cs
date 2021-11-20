using System;
namespace carPark
{
    public abstract class Transport
    {
        public Transmission transmission = new Transmission();
        public Chassis chassis = new Chassis();

        public Transport(Transmission transmission, Chassis chassis)
        {
            this.transmission = transmission;
            this.chassis = chassis;
        }

    }
}
