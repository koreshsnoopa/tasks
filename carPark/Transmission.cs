using System;

namespace carPark
{
    public class Transmission
    {
        public string TypeOfTransmission { get; set; }
        public int NumberOfGears { get; set; }
        public string Manufacturer { get; set; }

        public Transmission(string typeOfTransmission, int numberOfGears, string manufacturer)
        {

            if (String.IsNullOrEmpty(typeOfTransmission))
            {
                throw new ArgumentException("You need to enter type of transmission!");
            }
            else
            {
                TypeOfTransmission = typeOfTransmission;
            }

            if (numberOfGears > 0)
            {
                NumberOfGears = numberOfGears;
            }
            else
            {
                throw new ArgumentException("Number of gears must be more then 0!");
            }

            if (String.IsNullOrEmpty(manufacturer))
            {
                throw new ArgumentException("You need to enter manufacturer!");
            }
            else
            {
                Manufacturer = manufacturer;
            }
        }

        public override string ToString()
        {
            return $"\nTransmission:\nType of transmission: {TypeOfTransmission}" +
                $"\nNumber of gears: {NumberOfGears}\nManufacturer: {Manufacturer}";
        }
    }

}
