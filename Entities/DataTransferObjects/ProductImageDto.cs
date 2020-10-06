using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductImageDto
    {
        public long ProductImageId { get; set; }
        public string ColorName { get; set; }
        public string ImageURL { get; set; }
    }
}

