using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class PostType
    {
        public PostType()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long? Rkey { get; set; }
        public long? Price { get; set; }
        public string Icon { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
