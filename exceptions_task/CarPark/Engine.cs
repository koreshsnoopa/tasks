using System;

namespace exceptions_task
{
    public abstract class Engine
    {
        public string SerialNumber { get; set; }
        public double Power { get; set; }
        public double Volume { get; set; }
        public string EngineType { get; protected set; }

        public Engine(string serialNumber, double power, double volume)
        {

            if (String.IsNullOrEmpty(serialNumber))
            {
                throw new InitializationException("You need to enter serial number of engine!");
            }
            else
            {
                SerialNumber = serialNumber;
            }

            if (power > 0)
            {
                Power = power;
            }
            else
            {
                throw new InitializationException("Power of engine must be more then 0!");
            }

            if (volume > 0)
            {
                Volume = volume;
            }
            else
            {
                throw new InitializationException("Volume of engine must be more then 0!");
            }
        }

        public Engine()
        {
        }
    }

}
