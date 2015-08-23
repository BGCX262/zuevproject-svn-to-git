using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7.Domain
{
    public class Customer
    {
        public string Name { get; set; }

        private IList<Rental> _rentals = new List<Rental>();

        // Добавить аренду
        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        // Формирование отчета о прокате для клиента
        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Учет аренды для " + Name + "\n";
            foreach (var each in _rentals)
            {
                double thisAmount = 0;
                // определить сумму для каждой строки
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;

                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;

                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }

                // добавить очки для активного арендатора
                frequentRenterPoints++;

                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) &&
                    (each.DaysRented > 1))
                    frequentRenterPoints++;

                // показать результаты для этой аренды
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";

                totalAmount += thisAmount;

            }

            // добавить нижний колонтитул
            result += "Сумма задолженности составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + frequentRenterPoints.ToString() + " очков за активность";
            return result;
        }
    }
}
