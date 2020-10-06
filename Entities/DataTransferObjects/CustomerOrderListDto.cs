using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CustomerOrderListDto
    {
        public long Id { get; set; }
        public string OrderDate { get; set; }
        public string OrderPrice { get; set; }
        public int ProductCount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
