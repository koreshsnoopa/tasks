namespace carPark
{
    public class ReciprocatingEngine : Engine
    {
        public ReciprocatingEngine(string serialNumber, double power, double volume) : base(serialNumber, power, volume)
        {
        }

        public override string ToString()
        {
            return $"\nEngine:\nSerial number: {SerialNumber}" +
                $"\nPower: {Power}\nVolume: {Volume}\nType: Reciprocating engine";
        }
    }
}

