using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CustomerOrderRepository : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
