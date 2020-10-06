using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductByOfferRate
    {
        public long Id { get; set; }
        public string CatProductName { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long FirstCount { get; set; }
        public long Count { get; set; }
        public string CoverImageUrl { get; set; }
        public double Rate { get; set; }
        public double OfferValue { get; set; }
        public long PriceAfterOffer { get; set; }
    }
}
