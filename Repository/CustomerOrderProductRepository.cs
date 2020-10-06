using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CustomerOrderProductRepository : RepositoryBase<CustomerOrderProduct>, ICustomerOrderProductRepository
    {
        public CustomerOrderProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public List<CustomerOrderProduct> GetCustomerOrderProductFullInfoByCustomerOrderId(long customerOrderId)
        {
            return FindByCondition(c => c.CustomerOrderId.Equals(customerOrderId))
                .Include(p => p.Product)
                .ThenInclude(p => p.ProductOffer)
                .ToList();
        }
    }
}

