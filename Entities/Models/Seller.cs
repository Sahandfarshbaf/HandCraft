using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Product = new HashSet<Product>();
            SellerCatProduct = new HashSet<SellerCatProduct>();
        }

        public long Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public long? MelliCode { get; set; }
        public long? Mobile { get; set; }
        public long? Bdate { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ProfileImageHurl { get; set; }
        public long? LocationId { get; set; }
        public long? PostalCode { get; set; }
        public string Address { get; set; }
        public long? FinalStatusId { get; set; }
        public long? SellerCode { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual Status FinalStatus { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SellerCatProduct> SellerCatProduct { get; set; }
    }
}
