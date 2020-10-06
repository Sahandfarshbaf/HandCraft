using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CustomerOrderProductDto
    {
        public long CustomerOrderProductId { set; get; }
        public long ProductId { set; get; }
        public string CoverImageUrl { get; set; }
        public string ProductName { get; set; }
        public long? ProductPrice { get; set; }
        public string SellerName { set; get; }
        public int Count { get; set; }
    }
}
