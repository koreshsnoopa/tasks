using System;
namespace Commands
{
    public class CAveragePriceOfType : ICommand
    {
        AutoShow autoShow;
        string brand;

        public CAveragePriceOfType(AutoShow autoShow, string brand)
        {
            this.autoShow = autoShow;
            this.brand = brand;
        }

        public void Excecute()
        {
            Console.WriteLine($"Average price of type is {autoShow.GetAveragePriceOfType(brand)}.");
        }
    }
}
