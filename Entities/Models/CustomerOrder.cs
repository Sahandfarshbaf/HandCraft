using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            CustomerOrderPayment = new HashSet<CustomerOrderPayment>();
            CustomerOrderProduct = new HashSet<CustomerOrderProduct>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? CustomerAddressId { get; set; }
        public long? OrderDate { get; set; }
        public long? OrderNo { get; set; }
        public long? FinalStatusId { get; set; }
        public string PostTackingCode { get; set; }
        public long? SendDate { get; set; }
        public long? DeliveryDate { get; set; }
        public long? Weight { get; set; }
        public long? PostTypeId { get; set; }
        public long? PostPrice { get; set; }
        public double? TaxValue { get; set; }
        public long? TaxPrice { get; set; }
        public int? OfferValue { get; set; }
        public long? OfferPrice { get; set; }
        public long? OrderPrice { get; set; }
        public long? FinalPrice { get; set; }
        public long? PaymentTypeId { get; set; }
        public string CustomerDescription { get; set; }
        public string AdminDescription { get; set; }
        public string SellerDescription { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual Status FinalStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual PostType PostType { get; set; }
        public virtual ICollection<CustomerOrderPayment> CustomerOrderPayment { get; set; }
        public virtual ICollection<CustomerOrderProduct> CustomerOrderProduct { get; set; }
    }
}
