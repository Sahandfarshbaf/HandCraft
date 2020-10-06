using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
