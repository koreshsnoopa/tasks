using System;
using System.Collections.Generic;
namespace exceptions_task
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                List<Transport> autos = new List<Transport>();


                Car car1 = new Car("Black", new ElectricEngine("285740927", 270, 1.5), new Chassis(4, "IQPBH83650D185963", 700),
                     new Transmission("Automatic", 2, "Honda"), 1);

                Bus bus1 = new Bus(new ReciprocatingEngine("836501174", 310, 2.1), "53c", new Transmission("Manual", 6, "MAN"),
                        new Chassis(6, "KTNAE4695F856306", 1300), 2);

                Scooter scooter1 = new Scooter(2, new ElectricEngine("574595752", 200, 1.1), new Chassis(2, "KDIRB37503R592773", 200),
                        new Transmission("Automatic", 2, "KEEWAY"), 3);

                Truck truck1 = new Truck(56, new ReciprocatingEngine("736497501", 300, 2), new Chassis(4, "JDNVI9823T746354", 10000),
                        new Transmission("Manual", 6, "Hyundai"), 4);

                autos.AddAuto(car1);
                autos.AddAuto(bus1);
                autos.AddAuto(scooter1);
                autos.AddAuto(truck1);

                autos.UpdateAuto(2, new Car("Black", new ElectricEngine("285740927", 270, 1.5), new Chassis(4, "IQPBH83650D185963", 700),
                     new Transmission("Automatic", 2, "Honda"), 9));

                autos.RemoveAuto(4);

                List<Transport> temp = autos.GetAutoByParameter("Color", "Black");
                Console.WriteLine(temp.Count);
            }
            catch (InitializationException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (AddException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (UpdateAutoException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (RemoveAutoException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (GetAutoByParameterException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

    }
}
