using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ProductMeter
    {
        public ProductMeter()
        {
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Rkey { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
