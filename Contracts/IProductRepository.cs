using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        List<Product> GetSellerProductList(long sellerId);
        List<Product> GetTopProductListWithRate();
        List<Product> GetProductListWithDetail();
        List<Product> GetProductListByCatId(long catId);
        List<Product> GetProductListByParentCatId(long catId);
    }
}
