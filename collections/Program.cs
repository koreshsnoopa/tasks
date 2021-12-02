using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

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

            var transWithBigEngine = transports.Where(x => x.engine.Volume > 1.5).ToList();

            try
            {
                CreateAndFillXML(transWithBigEngine, "TransportsWithBigEngine2");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            XDocument xdoc = new XDocument(new XElement("TruckAndBusEngines",
            transports.Where(x => x.GetType() == typeof(Truck) || x.GetType() == typeof(Bus))
            .ToList().Select(t =>
             new XElement("TypeOfTransport", t.GetType().Name.ToString(),
             new XElement("TypeOfEngine", t.engine.EngineType),
             new XElement("EnginePower", t.engine.Power),
             new XElement("SerialNumber", t.engine.SerialNumber)))));

             xdoc.Save("TnBEngines.xml");

            var groupedTransport = transports.GroupBy(x => x.transmission.TypeOfTransmission)
            .Select(g => new HelpGroup() { GroupName = g.Key, Transports = g.ToList() })
            .ToList();

            try
            {
                CreateAndFillXML(transWithBigEngine, "GroupedTransport");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CreateAndFillXML(Object list, string name)
        {
            if (list == null || String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name of file or list is empty!");
            }
            XmlSerializer formatter = new XmlSerializer(list.GetType());

            using (FileStream fs = new FileStream($"{name}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}
