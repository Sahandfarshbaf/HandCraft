using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
   public class CustomerOrderPaymentRepository : RepositoryBase<CustomerOrderPayment>, ICustomerOrderPaymentRepository
    {
       public CustomerOrderPaymentRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
       {
       }
    }
}
