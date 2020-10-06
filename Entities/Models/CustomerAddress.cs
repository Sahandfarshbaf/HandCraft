using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string Address { get; set; }
        public bool? DefaultAddress { get; set; }
        public string Xgps { get; set; }
        public string Ygps { get; set; }
        public long? ProvinceId { get; set; }
        public long? CityId { get; set; }
        public long? PostalCode { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual Location City { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Location Province { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
