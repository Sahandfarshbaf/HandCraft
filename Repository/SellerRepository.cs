using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
   public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
   {
       public SellerRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
       {
       }
    }
}
