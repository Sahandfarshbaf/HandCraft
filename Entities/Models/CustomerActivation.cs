using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CustomerActivation
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? Mobile { get; set; }
        public long? Email { get; set; }
        public long? SendDate { get; set; }
        public long? Code { get; set; }
        public int? FaileCount { get; set; }
        public byte? Status { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
