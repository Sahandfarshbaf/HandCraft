using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
   public interface ICustomerOrderProductRepository:IRepositoryBase<CustomerOrderProduct>
   {
       List<CustomerOrderProduct> GetCustomerOrderProductFullInfoByCustomerOrderId(long customerOrderId);
   }
}
