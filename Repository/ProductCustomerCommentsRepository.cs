using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductCustomerCommentsRepository : RepositoryBase<ProductCustomerComments>, IProductCustomerCommentsRepository
    {
        public ProductCustomerCommentsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
