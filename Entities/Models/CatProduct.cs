using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public partial class CatProduct
    {
        public CatProduct()
        {
            CatProductParameters = new HashSet<CatProductParameters>();
            InverseP = new HashSet<CatProduct>();
            Product = new HashSet<Product>();
            SellerCatProduct = new HashSet<SellerCatProduct>();
        }

        public long Id { get; set; }
        public long? Pid { get; set; }
        public string Name { get; set; }
        public long? Coding { get; set; }
        public long? Rkey { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }
        [JsonIgnore]
        public virtual CatProduct P { get; set; }
        public virtual ICollection<CatProductParameters> CatProductParameters { get; set; }
        public virtual ICollection<CatProduct> InverseP { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SellerCatProduct> SellerCatProduct { get; set; }
    }
}
