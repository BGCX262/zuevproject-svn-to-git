using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7.Domain
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public string Title { get; set; }
        public int PriceCode { get; set; }
    }
}
