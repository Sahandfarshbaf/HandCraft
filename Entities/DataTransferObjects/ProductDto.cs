using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects
{
   public class ProductDto
    {
        public long Id { get; set; }
        public string CatProductName { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long FirstCount { get; set; }
        public long Count { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
