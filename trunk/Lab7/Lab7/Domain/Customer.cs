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
            string result = "Учет аренды для " + Name + "\n";
            foreach (var each in _rentals)
            {              
                // показать результаты для этой аренды
                result += "\t" + each.Movie.Title + "\t" + each.Charge + "\n";
            }

            // добавить нижний колонтитул
            result += "Сумма задолженности составляет " + GetTotalCharge() + "\n" + "Вы заработали " + GetTotalFrequentRenterPoints() + " очков за активность";
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (var each in _rentals)
            {
                result += each.Charge;
            }
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (var each in _rentals)
            {
                result += each.FrequentRenterPoint;
            }
            return result;
        }

        public string HtmlStatement()
        {
            string result = "<H1>Учет аренды для <EM>" + Name + "</EM><H1><P>\n";

            foreach (var each in _rentals)
                result += each.Movie.Title + ": " + each.Charge + "<BR>\n";

            result += "<P>Сумма задолженности составляет <EM>" + GetTotalCharge() + "</EM><P>\n";
            result += "Вы заработали <EM>" + GetTotalFrequentRenterPoints() + "</EM> очков за активность";
            return result;
        }

    }
}
