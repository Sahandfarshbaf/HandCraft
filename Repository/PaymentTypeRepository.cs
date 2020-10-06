using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
   public class PaymentTypeRepository : RepositoryBase<PaymentType>, IPaymentTypeRepository
    {
       public PaymentTypeRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
       {
       }
    }
}
