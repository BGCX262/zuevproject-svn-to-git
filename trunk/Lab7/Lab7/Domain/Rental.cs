using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7.Domain
{
    public class Rental
    {
        public int DaysRented { get; set; }
        public Movie Movie { get; set; }

        public double Charge
        {
            get {
                double result = 0;
                switch (Movie.PriceCode)
                {
                    case Movie.Regular:
                        result += 2;
                        if (DaysRented > 2)
                            result += (DaysRented - 2) * 1.5;
                        break;

                    case Movie.Release:
                        result += DaysRented * 3;
                        break;

                    case Movie.Childrens:
                        result += 1.5;
                        if (DaysRented > 3)
                            result += (DaysRented - 3) * 1.5;
                        break;
                }
                return result;
            }
        }

        public int FrequentRenterPoint
        {
            get
            {
                if ((Movie.PriceCode == Movie.Release) &&
                        (DaysRented > 1))
                    return 2;
                else
                    return 1;
            }
        }
    }
}
