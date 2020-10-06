using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  public  class ProductOfferRepository : RepositoryBase<ProductOffer>, IProductOfferRepository
    {
        public ProductOfferRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
