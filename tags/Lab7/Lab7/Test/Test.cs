using System;
using System.Collections.Generic;
using System.Text;
using Lab7.Domain;
using NUnit.Framework;

namespace Lab7.Test
{
    [TestFixture]
    public class ReportTest
    {
        Movie m1 = new Movie() { Title = "кино", PriceCode = Movie.REGULAR };
        Movie m2 = new Movie() { Title = "мультик", PriceCode = Movie.CHILDRENS };
        Movie m3 = new Movie() { Title = "новинка", PriceCode = Movie.NEW_RELEASE };
        private Customer customer = null;

        [SetUp]
        public void Init()
        {
            customer = new Customer() { Name = "Иванов И. И." };
        }

        [Test]
        public void RegularMovieSingleDayTest()
        {
            customer.AddRental(new Rental() { Movie = m1, DaysRented = 1 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tкино\t2\nСумма задолженности составляет 2\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void RegularMovieManyDaysTest()
        {
            customer.AddRental(new Rental() { Movie = m1, DaysRented = 10 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tкино\t14\nСумма задолженности составляет 14\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ChildrensMovieSingleDayTest()
        {
            customer.AddRental(new Rental() { Movie = m2, DaysRented = 1 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tмультик\t1.5\nСумма задолженности составляет 1.5\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ChildrensMovieManyDaysTest()
        {
            customer.AddRental(new Rental() { Movie = m2, DaysRented = 10 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tмультик\t12\nСумма задолженности составляет 12\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void NewMovieSingleDayTest()
        {
            customer.AddRental(new Rental() { Movie = m3, DaysRented = 1 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tновинка\t3\nСумма задолженности составляет 3\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void NewMovieManyDaysTest()
        {
            customer.AddRental(new Rental() { Movie = m3, DaysRented = 10 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tновинка\t30\nСумма задолженности составляет 30\nВы заработали 2 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ComplexTest()
        {
            customer.AddRental(new Rental() { Movie = m1, DaysRented = 1 });
            customer.AddRental(new Rental() { Movie = m1, DaysRented = 2 });
            customer.AddRental(new Rental() { Movie = m1, DaysRented = 3 });

            customer.AddRental(new Rental() { Movie = m2, DaysRented = 1 });
            customer.AddRental(new Rental() { Movie = m2, DaysRented = 2 });
            customer.AddRental(new Rental() { Movie = m2, DaysRented = 3 });

            customer.AddRental(new Rental() { Movie = m3, DaysRented = 1 });
            customer.AddRental(new Rental() { Movie = m3, DaysRented = 2 });
            customer.AddRental(new Rental() { Movie = m3, DaysRented = 3 });

            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tкино\t2\n\tкино\t2\n\tкино\t3.5\n\tмультик\t1.5\n\tмультик\t1.5\n\tмультик\t1.5\n\tновинка\t3\n\tновинка\t6\n\tновинка\t9\nСумма задолженности составляет 30\nВы заработали 11 очков за активность";
            Assert.AreEqual(etalon, report);
        }
    }
}
