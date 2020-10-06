using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class ProductMeterRepository : RepositoryBase<ProductMeter>, IProductMeterRepository
    {
        public ProductMeterRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
