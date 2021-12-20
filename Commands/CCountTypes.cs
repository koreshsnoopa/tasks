using System;
namespace Commands
{
    public class CCountTypes : ICommand
    {
        AutoShow autoShow;
        
        public CCountTypes(AutoShow autoShow)
        {
            this.autoShow = autoShow;
        }

        public void Excecute()
        {
            Console.WriteLine($"Amount of auto types in show is {autoShow.CountTypes()}.");
        }
    }
}
