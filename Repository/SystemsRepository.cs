using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class SystemsRepository : RepositoryBase<Systems>, ISystemsRepository
    {
        public SystemsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
