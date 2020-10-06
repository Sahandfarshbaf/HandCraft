using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class CatProductParametersRepository : RepositoryBase<CatProductParameters>, ICatProductParametersRepository
    {
        public CatProductParametersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
