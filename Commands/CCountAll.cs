using System;
namespace Commands
{
    public class CCountAll : ICommand
    {
        AutoShow autoShow;

        public CCountAll(AutoShow autoShow)
        {
            this.autoShow = autoShow;
        }

        public void Excecute()
        {
            Console.WriteLine($"Amount of autos in show is {autoShow.CountAutos()}.");
        }
    }
}
