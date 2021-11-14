namespace carPark
{
    public class Transmission
    {
        public string TypeOfTransmission { get; set; }
        public int NumberOfGears { get; set; }
        public string Manufacturer { get; set; }

        public Transmission()
        {
        }

        public Transmission(string typeOfTransmission, int numberOfGears, string manufacturer)
        {
            TypeOfTransmission = typeOfTransmission;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return $"\nTransmission:\nType of transmission: {TypeOfTransmission}" +
                $"\nNumber of gears: {NumberOfGears}\nManufacturer: {Manufacturer}";
        }
    }

}
