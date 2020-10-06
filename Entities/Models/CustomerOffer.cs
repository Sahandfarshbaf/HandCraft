using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CustomerOffer
    {
        public long Id { get; set; }
        public long? OfferId { get; set; }
        public long? CustomerId { get; set; }
        public string Name { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
        public double? Value { get; set; }
        public string OfferCode { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Offers Offer { get; set; }
    }
}
