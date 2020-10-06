using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Location
    {
        public Location()
        {
            Customer = new HashSet<Customer>();
            CustomerAddressCity = new HashSet<CustomerAddress>();
            CustomerAddressProvince = new HashSet<CustomerAddress>();
            InverseCountry = new HashSet<Location>();
            InverseP = new HashSet<Location>();
            InverseProvince = new HashSet<Location>();
        }

        public long Id { get; set; }
        public long? Pid { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public long? LocationCode { get; set; }
        public long? CountryId { get; set; }
        public long? ProvinceId { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual Location Country { get; set; }
        public virtual Location P { get; set; }
        public virtual Location Province { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddressCity { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddressProvince { get; set; }
        public virtual ICollection<Location> InverseCountry { get; set; }
        public virtual ICollection<Location> InverseP { get; set; }
        public virtual ICollection<Location> InverseProvince { get; set; }
    }
}
