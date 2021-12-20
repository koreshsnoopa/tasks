using System;
namespace Commands
{
    public class CExit : ICommand
    {
        public CExit()
        {
        }

        public void Excecute()
        {
           Environment.Exit(0);
        }
    }
}
