using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class PostTypeRepository : RepositoryBase<PostType>, IPostTypeRepository
    {
        public PostTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
