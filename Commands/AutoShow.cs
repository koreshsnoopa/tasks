using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    public sealed class AutoShow
    {
        private AutoShow() { }
      
        private static AutoShow _instance;

        public static AutoShow GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AutoShow();
            }
            return _instance;
        }

        public List<Auto> Autos = new List<Auto>();

        public int CountTypes()
        {
            if (Autos.Count() == 0)
            {
                throw new IndexOutOfRangeException("Auto show has no autos!");
            }

            return Autos.GroupBy(x => x.Brand).Select(x => x.Key.Count()).Count();
        }

        public int CountAutos()
        {
            if (Autos.Count() == 0)
            {
                throw new IndexOutOfRangeException("Auto show has no autos!");
            }

            int amount = 0;
            Autos.ForEach(x => amount += x.Amount);
            return amount;
        }

        public double GetAveragePrice()
        {
            if (Autos.Count() == 0)
            {
                throw new IndexOutOfRangeException("Auto show has no autos!");
            }

            double sumPrice = 0;
            Autos.ForEach(x => sumPrice += x.Price);
            return sumPrice / Autos.Count();
        }

        public double GetAveragePriceOfType(string brand)
        {
            if (Autos.Count() == 0)
            {
                throw new IndexOutOfRangeException("Auto show has no autos!");
            }
            if (String.IsNullOrEmpty(brand))
            {
                throw new ArgumentException("Need to input type!");
            }
            if (Autos.Where(x => x.Brand.ToLower() == brand.ToLower()).ToList().Count() == 0)
            {
                throw new IndexOutOfRangeException("There is no autos of such type!");
            }

            double sumPrice = 0;
            Autos.Where(x => x.Brand.ToLower() == brand.ToLower()).ToList().ForEach(x => sumPrice += x.Price);
            return sumPrice / Autos.Where(x => x.Brand.ToLower() == brand.ToLower()).ToList().Count();
        }

    }
}
