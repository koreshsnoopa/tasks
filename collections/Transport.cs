using System;
using System.Xml.Serialization;

namespace collections
{
    [XmlInclude(typeof(Car)), XmlInclude(typeof(Bus)),
        XmlInclude(typeof(Scooter)), XmlInclude(typeof(Truck))]
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
