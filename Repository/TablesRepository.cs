using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class TablesRepository : RepositoryBase<Tables>, ITablesRepository
    {
        public TablesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
