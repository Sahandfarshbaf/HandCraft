using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductParametersRepository : RepositoryBase<ProductParameters>, IProductParametersRepository
    {
        public ProductParametersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
