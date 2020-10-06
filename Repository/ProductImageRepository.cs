using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public List<ProductImage> GetProductImageWithDetails(long productId)
        {
            return FindByCondition(c => c.ProductId.Equals(productId))
                .Include(p => p.Color)
                .ToList();
        }
    }
}
