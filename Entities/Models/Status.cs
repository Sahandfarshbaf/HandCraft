using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Status
    {
        public Status()
        {
            Customer = new HashSet<Customer>();
            CustomerOrder = new HashSet<CustomerOrder>();
            CustomerOrderProduct = new HashSet<CustomerOrderProduct>();
            Product = new HashSet<Product>();
            Seller = new HashSet<Seller>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Rkey { get; set; }
        public long? NextStatusId { get; set; }
        public string Color { get; set; }
        public long? StatusTypeId { get; set; }
        public long? CatStatusId { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual CatStatus CatStatus { get; set; }
        public virtual StatusType StatusType { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<CustomerOrderProduct> CustomerOrderProduct { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Seller> Seller { get; set; }
    }
}
