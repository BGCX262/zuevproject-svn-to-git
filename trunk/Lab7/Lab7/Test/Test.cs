using System;
using System.Collections.Generic;
using System.Text;
using Lab7.Domain;
using NUnit.Framework;
using System.Reflection;
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersionAttribute("4.3.2.1")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]



namespace Lab7.Test
{
    [TestFixture]
    public class ReportTest
    {
        Movie Avatar = new Movie() { Title = "кино", PriceCode = Movie.Regular };
        Movie SouthPark = new Movie() { Title = "мультик", PriceCode = Movie.Childrens };
        Movie ANightmareOnElmStreet	 = new Movie() { Title = "новинка", PriceCode = Movie.Release };
        private Customer customer;

        #region Add all rent
        private void AllRental()
        {
            customer.AddRental(new Rental() { Movie = Avatar, DaysRented = 1 });
            customer.AddRental(new Rental() { Movie = Avatar, DaysRented = 2 });
            customer.AddRental(new Rental() { Movie = Avatar, DaysRented = 3 });

            customer.AddRental(new Rental() { Movie = SouthPark, DaysRented = 1 });
            customer.AddRental(new Rental() { Movie = SouthPark, DaysRented = 2 });
            customer.AddRental(new Rental() { Movie = SouthPark, DaysRented = 3 });

            customer.AddRental(new Rental() { Movie = ANightmareOnElmStreet, DaysRented = 1 });
            customer.AddRental(new Rental() { Movie = ANightmareOnElmStreet, DaysRented = 2 });
            customer.AddRental(new Rental() { Movie = ANightmareOnElmStreet, DaysRented = 3 });
        }
        #endregion

        [SetUp]
        public void Init()
        {
            customer = new Customer() { Name = "Иванов И. И." };
        }

        [Test]
        public void RegularMovieSingleDayTest()
        {
            customer.AddRental(new Rental() { Movie = Avatar, DaysRented = 1 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tкино\t2\nСумма задолженности составляет 2\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void RegularMovieManyDaysTest()
        {
            customer.AddRental(new Rental() { Movie = Avatar, DaysRented = 10 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tкино\t14\nСумма задолженности составляет 14\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ChildrensMovieSingleDayTest()
        {
            customer.AddRental(new Rental() { Movie = SouthPark, DaysRented = 1 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tмультик\t1,5\nСумма задолженности составляет 1,5\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ChildrensMovieManyDaysTest()
        {
            customer.AddRental(new Rental() { Movie = SouthPark, DaysRented = 10 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tмультик\t12\nСумма задолженности составляет 12\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void NewMovieSingleDayTest()
        {
            customer.AddRental(new Rental() { Movie = ANightmareOnElmStreet, DaysRented = 1 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tновинка\t3\nСумма задолженности составляет 3\nВы заработали 1 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void NewMovieManyDaysTest()
        {
            customer.AddRental(new Rental() { Movie = ANightmareOnElmStreet, DaysRented = 10 });
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tновинка\t30\nСумма задолженности составляет 30\nВы заработали 2 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ComplexTest()
        {
            AllRental();          
            string report = customer.Statement();
            string etalon = "Учет аренды для Иванов И. И.\n\tкино\t2\n\tкино\t2\n\tкино\t3,5\n\tмультик\t1,5\n\tмультик\t1,5\n\tмультик\t1,5\n\tновинка\t3\n\tновинка\t6\n\tновинка\t9\nСумма задолженности составляет 30\nВы заработали 11 очков за активность";
            Assert.AreEqual(etalon, report);
        }

        [Test]
        public void ComplexHtmlTest()
        {
            AllRental();         
            string report = customer.HtmlStatement();
            string etalon = "<H1>Учет аренды для <EM>Иванов И. И.</EM><H1><P>\nкино: 2<BR>\nкино: 2<BR>\nкино: 3,5<BR>\nмультик: 1,5<BR>\nмультик: 1,5<BR>\nмультик: 1,5<BR>\nновинка: 3<BR>\nновинка: 6<BR>\nновинка: 9<BR>\n<P>Сумма задолженности составляет <EM>30</EM><P>\nВы заработали <EM>11</EM> очков за активность";
            Assert.AreEqual(etalon, report);
        }
    }
}
