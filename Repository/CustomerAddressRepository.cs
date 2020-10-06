using Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;

namespace Repository
{
   public class CustomerAddressRepository : RepositoryBase<CustomerAddress>, ICustomerAddressRepository
    {
       public CustomerAddressRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
       {
       }
    }
}
