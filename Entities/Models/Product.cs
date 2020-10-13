using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            CustomerOrderProduct = new HashSet<CustomerOrderProduct>();
            ProductCustomerComments = new HashSet<ProductCustomerComments>();
            ProductCustomerRate = new HashSet<ProductCustomerRate>();
            ProductImage = new HashSet<ProductImage>();
            ProductOffer = new HashSet<ProductOffer>();
            ProductParameters = new HashSet<ProductParameters>();
        }

        public long Id { get; set; }
        public long? SellerId { get; set; }
        public long? CatProductId { get; set; }
        public long? ProductMeterId { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public long? Rkey { get; set; }
        public long? Coding { get; set; }
        public long? Price { get; set; }
        public long? FinalStatusId { get; set; }
        public long? FirstCount { get; set; }
        public long? Count { get; set; }
        public string CoverImageUrl { get; set; }
        public string CoverImageHurl { get; set; }
        public long? SeenCount { get; set; }
        public long? LastSeenDate { get; set; }
        public string Description { get; set; }
        public string AparatUrl { get; set; }
        public long? Weight { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual CatProduct CatProduct { get; set; }
        public virtual Status FinalStatus { get; set; }
        public virtual ProductMeter ProductMeter { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<CustomerOrderProduct> CustomerOrderProduct { get; set; }
        public virtual ICollection<ProductCustomerComments> ProductCustomerComments { get; set; }
        public virtual ICollection<ProductCustomerRate> ProductCustomerRate { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ProductOffer> ProductOffer { get; set; }
        public virtual ICollection<ProductParameters> ProductParameters { get; set; }
    }
}
