using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7.Domain
{
    public class Movie
    {
        public const int Childrens = 2;
        public const int Regular = 0;
        public const int Release = 1;

        public string Title { get; set; }
        public int PriceCode { get; set; }
    }
}
