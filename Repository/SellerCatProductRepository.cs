using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class SellerCatProductRepository : RepositoryBase<SellerCatProduct>, ISellerCatProductRepository
    {
        public SellerCatProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
