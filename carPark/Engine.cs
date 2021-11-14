namespace carPark
{
    public abstract class Engine
    {
        public string SerialNumber { get; set; }
        public double Power { get; set; }
        public double Volume { get; set; }

        public Engine(string serialNumber, double power, double volume)
        {
            SerialNumber = serialNumber;
            Power = power;
            Volume = volume;
        }

        public Engine()
        {
        }
    }

}
