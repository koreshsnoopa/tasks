using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transport> transports = new List<Transport> {
                new Car("Black", new ElectricEngine("285740927", 270, 1.5), new Chassis(4, "IQPBH83650D185963", 700),
                         new Transmission("Automatic", 2, "Honda")),
                new Bus(new ReciprocatingEngine("836501174", 310, 2.1), "53c", new Transmission("Manual", 6, "MAN"),
                        new Chassis(6, "KTNAE4695F856306", 1300)),
                new Scooter(2, new ElectricEngine("574595752", 200, 1.1), new Chassis(2, "KDIRB37503R592773", 200),
                        new Transmission("Automatic", 2, "KEEWAY")),
                new Truck(56, new ReciprocatingEngine("736497501", 300, 2), new Chassis(4, "JDNVI9823T746354", 10000),
                        new Transmission("Manual", 6, "Hyundai"))
            };

            
            
        }
    }
}
