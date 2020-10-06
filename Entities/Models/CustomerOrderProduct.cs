using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public partial class CustomerOrderProduct
    {
        public long Id { get; set; }
        public long? CustomerOrderId { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public long? ProductColorId { get; set; }
        public long? ProductPrice { get; set; }
        public double? ProductOfferValue { get; set; }
        public string ProductOfferCode { get; set; }
        public long? ProductOfferPrice { get; set; }
        public long? FinalStatusId { get; set; }
        public int? OrderCount { get; set; }
        public long? Weight { get; set; }
        public long? ProductCode { get; set; }
        public string Description { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }
        [JsonIgnore]
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Status FinalStatus { get; set; }
        public virtual Product Product { get; set; }
    }
}
