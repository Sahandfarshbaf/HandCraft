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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public List<Product> GetTopProductListWithRate()
        {
            return FindAll()
                .Include(p => p.CatProduct)
                .Include(p => p.ProductCustomerRate)
                .Include(p => p.ProductOffer)
                .OrderByDescending(p => p.ProductCustomerRate.Average(r => r.Rate))
                .Take(10)
                .ToList();
        }

        public List<Product> GetSellerProductList(long sellerId)
        {
            return FindByCondition(p => p.SellerId.Equals(sellerId))
                .Include(p => p.CatProduct)
                .Include(p => p.ProductOffer)
                .Include(p => p.ProductCustomerRate)
                .OrderByDescending(p => p.Id)
                .ToList();
        }

        public List<Product> GetProductListWithDetail()
        {
            return FindAll().Include(p => p.CatProduct)
                .Include(p => p.ProductCustomerRate)
                .Include(p => p.ProductOffer)
                .ToList();
        }

        public List<Product> GetProductListByCatId(long catId)
        {
            return FindByCondition(p => p.CatProduct.Id.Equals(catId))
                .Include(p => p.CatProduct)
                .Include(p => p.ProductOffer)
                .Include(p => p.ProductCustomerRate)
                .OrderByDescending(p => p.Id)
                .ToList();
        }

        public List<Product> GetProductListByParentCatId(long catId)
        {
            return FindByCondition(p => p.CatProduct.Id.Equals(catId) || p.CatProduct.Pid==catId)
                .Include(p => p.CatProduct)
                .Include(p => p.ProductOffer)
                .Include(p => p.ProductCustomerRate)
                .OrderByDescending(p => p.Id)
                .ToList();
        }
    }
}
