using System;
namespace Commands
{
    public abstract class Auto
    {
        public string Brand;
        public string Model;
        public int Amount;
        public double Price;

        public Auto(string brand, string model, int amount, double price)
        {
            if (String.IsNullOrEmpty(brand))
            {
                throw new ArgumentException("Necessary to input brand of auto!");
            }
            else
            {
                Brand = brand;
            }

            if(String.IsNullOrEmpty(brand))
            {
                throw new ArgumentException("Necessary to input model of auto!");
            }
            else
            {
                Model = model;
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount of autos must be more than 0!");
            }
            else
            {
                Amount = amount;
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price of auto must be more than 0!");
            }
            else
            {
                Price = price;
            }
            
        }
    }
}
