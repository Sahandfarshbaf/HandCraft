using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class StatusTypeRepository : RepositoryBase<StatusType>, IStatusTypeRepository
    {
        public StatusTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
