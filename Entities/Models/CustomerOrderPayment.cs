using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CustomerOrderPayment
    {
        public long Id { get; set; }
        public long? CustomerOrderId { get; set; }
        public string TrackingCode { get; set; }
        public long? TransactionDate { get; set; }
        public long? TransactionPrice { get; set; }
        public long? SystemTraceNo { get; set; }
        public string OrderNo { get; set; }
        public string ResNum { get; set; }
        public long? TerminalNo { get; set; }
        public string RefNum { get; set; }
        public string CardPan { get; set; }
        public string TraceNo { get; set; }
        public long? FinalStatusId { get; set; }
        public string CuserId { get; set; }
        public long? Cdate { get; set; }
        public string DuserId { get; set; }
        public long? Ddate { get; set; }
        public string MuserId { get; set; }
        public long? Mdate { get; set; }
        public string DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
    }
}
