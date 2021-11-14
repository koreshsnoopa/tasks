using System;
namespace carPark
{
    public abstract class Transport
    {
        public Transmission transmission = new Transmission();
        public Chassis chassis = new Chassis();

        public Transport(int numberOfWheels, string numberOfChassis, double permissibleLoad,
            string typeOfTransmission, int numberOfGears, string manufacturer)
        {
            transmission.TypeOfTransmission = typeOfTransmission;
            transmission.NumberOfGears = numberOfGears;
            transmission.Manufacturer = manufacturer;
            chassis.NumberOfWheels = numberOfWheels;
            chassis.NumberOfChassis = numberOfChassis;
            chassis.PermissibleLoad = permissibleLoad;
        }

    }
}
