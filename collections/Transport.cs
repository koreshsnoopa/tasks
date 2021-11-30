using System;
namespace collections
{
    [Serializable]
    public abstract class Transport
    {
        public Transmission transmission;
        public Chassis chassis;
        public Engine engine;

        public Transport()
        {
        }

        public Transport(Transmission transmission, Chassis chassis, Engine engine)
        {
            this.transmission = transmission;
            this.chassis = chassis;
            this.engine = engine;
        }

    }
}
