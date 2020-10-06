using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CatProductRepository : RepositoryBase<CatProduct>, ICatProductRepository
    {
        public CatProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
