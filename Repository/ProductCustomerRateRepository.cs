using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class ProductCustomerRateRepository : RepositoryBase<ProductCustomerRate>, IProductCustomerRateRepositry
    {
        public ProductCustomerRateRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
