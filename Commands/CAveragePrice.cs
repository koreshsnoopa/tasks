using System;
namespace Commands
{
    public class CAveragePrice : ICommand
    {
        AutoShow autoShow;

        public CAveragePrice(AutoShow autoShow)
        {
            this.autoShow = autoShow;
        }

        public void Excecute()
        {
            Console.WriteLine($"Average price of autos in show is {autoShow.GetAveragePrice()}.");
        }
    }
}
