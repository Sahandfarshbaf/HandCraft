using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CustomerOfferRepository : RepositoryBase<CustomerOffer>, ICustomerOfferRepository
    {
        public CustomerOfferRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

    }
}
