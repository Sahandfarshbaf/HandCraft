using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using HandCraft.Tools.Zarinpal;
using ZarinPal = HandCraft.Tools.ZarinPal.ZarinPal;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
       
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        private readonly long timeTick;

        public CustomerOrderController( IRepositoryWrapper repository, IMapper mapper)
        {
           
            _repository = repository;
            _mapper = mapper;
            this.timeTick = DateTime.Now.Ticks;
        }

  
        [HttpPost]
        [Route("CustomerOrder/InsertCustomerOrder")]
        public IActionResult InsertCustomerOrder(List<CustomerOrderProduct> customerOrderProductlist)
        {
            try
            {

                CustomerOrder customerOrder = new CustomerOrder();
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                var customerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();



                customerOrder.CuserId = userid;
                customerOrder.Cdate = timeTick;
                customerOrder.CustomerId = customerId;
                customerOrder.OrderDate = timeTick;
                customerOrder.OrderNo = timeTick;
                customerOrder.CustomerId = customerId;


                customerOrderProductlist.ForEach(x =>
                {
                    x.Cdate = timeTick;
                    x.CuserId = userid;

                });

                customerOrder.CustomerOrderProduct = customerOrderProductlist;

                _repository.CustomerOrder.Create(customerOrder);
                _repository.Save();
           
                return Ok(customerOrder.Id);
            }
            catch (Exception e)
            {
           
                return BadRequest("Internal server error");
            }

        }

    
        [HttpPut]
        [Route("CustomerOrder/FinalOrderInsert")]
        public IActionResult FinalOrderInsert(long customerOrderId, long postTypeId, long paymentTypeId, string customerDescription, string offerCode)
        {
            try
            {


                var custumerOrderProduct =
                    _repository.CustomerOrderProduct.GetCustomerOrderProductFullInfoByCustomerOrderId(customerOrderId);


                custumerOrderProduct.ForEach(c =>
                {
                    c.ProductPrice = c.Product.Price;

                    c.ProductOfferValue = c.Product.ProductOffer
                        .Where(x => x.FromDate <= timeTick && timeTick <= x.ToDate).Select(x => x.Value)
                        .DefaultIfEmpty(0).FirstOrDefault();


                    c.ProductOfferCode = c.Product.ProductOffer
                        .Where(x => x.FromDate <= timeTick && timeTick <= x.ToDate).Select(x => x.OfferCode)
                        .FirstOrDefault();


                    c.ProductOfferPrice = Convert.ToInt64((c.ProductOfferValue / 100) * c.Product.Price);


                    c.Weight = c.Product.Weight;
                    c.ProductCode = c.Product.Coding;
                });

                var custumerOrder = _repository.CustomerOrder.FindByCondition(c => c.Id.Equals(customerOrderId)).FirstOrDefault();
                var costomerId = custumerOrder.CustomerId.Value;
                custumerOrder.PaymentTypeId = paymentTypeId;
                custumerOrder.PostTypeId = postTypeId;
                custumerOrder.CustomerDescription = customerDescription;
                custumerOrder.CustomerOrderProduct = custumerOrderProduct;

                custumerOrder.Weight = custumerOrderProduct.Sum(c => (c.Weight * c.OrderCount));
                custumerOrder.TaxValue = 9;
                custumerOrder.OrderPrice = custumerOrderProduct.Where(c => c.Ddate.Equals(null))
                                                                .Sum(c => (c.OrderCount * (c.ProductPrice - c.ProductOfferPrice)));



                var customerOfferRecord = _repository.CustomerOffer
                    .FindByCondition(c => c.CustomerId == costomerId && c.FromDate <= timeTick && timeTick <= c.ToDate && c.OfferCode == offerCode &&
                                                                string.IsNullOrWhiteSpace(c.DuserId) && string.IsNullOrWhiteSpace(c.DaUserId))
                    .FirstOrDefault();
                custumerOrder.OfferValue = customerOfferRecord != null ? (int?)customerOfferRecord.Value / 100 : 0;
                custumerOrder.OfferPrice = (custumerOrder.OrderPrice) * (custumerOrder.OfferValue / 100);
                custumerOrder.TaxPrice = (long?)((custumerOrder.OrderPrice - custumerOrder.OfferPrice) * 0.09);


                var postTypeRecord = _repository.PostType.FindByCondition(c => c.Rkey.Equals(postTypeId)).FirstOrDefault();
                custumerOrder.PostPrice = postTypeRecord != null ? postTypeRecord.Price : 0;

                custumerOrder.FinalPrice =
                    ((custumerOrder.OrderPrice - custumerOrder.OfferPrice) + custumerOrder.TaxPrice + custumerOrder.PostPrice);

                _repository.CustomerOrder.Update(custumerOrder);
                if (customerOfferRecord != null)
                {
                    var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                    customerOfferRecord.DaUserId = userid;
                    customerOfferRecord.DaDate = timeTick;
                    _repository.CustomerOffer.Update(customerOfferRecord);
                }



                if (custumerOrder.PaymentTypeId == 2)
                {

                    ZarinPallRequest request = new ZarinPallRequest();
                    request.amount = ((int)custumerOrder.FinalPrice.Value) * 10;
                    request.description = "order NO: " + custumerOrder.OrderNo;
                    Tools.ZarinPal.ZarinPal zarinPal = new Tools.ZarinPal.ZarinPal();
                    var res = zarinPal.Request(request);

                    CustomerOrderPayment customerOrderPayment = new CustomerOrderPayment();
                    customerOrderPayment.CustomerOrderId = customerOrderId;
                    customerOrderPayment.OrderNo = custumerOrder.OrderNo.ToString();
                    customerOrderPayment.TraceNo = res.authority;
                    customerOrderPayment.TransactionPrice = custumerOrder.FinalPrice;
                    customerOrderPayment.Cdate = timeTick;
                    customerOrderPayment.CuserId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                    _repository.CustomerOrderPayment.Create(customerOrderPayment);


                    _repository.Save();
                    return Ok("https://www.zarinpal.com/pg/StartPay/" + res.authority);

                }
                _repository.Save();
                return Ok("");
            }
            catch (Exception e)
            {
              
                return BadRequest("Internal server error");
            }
        }


        [HttpGet]
        [Route("CustomerOrder/GetCustomerOrderById")]
        public IActionResult GetCustomerOrderById(long customerOrderId)
        {
            try
            {
                var order = _repository.CustomerOrder.FindByCondition(c => c.Id == customerOrderId)
                    .Include(x => x.CustomerOrderProduct)
                    .ThenInclude(c => c.Product)
                    .FirstOrDefault();

                return Ok(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("CustomerOrder/GetCustomerOrderListByCustomerId")]
        public IActionResult GetCustomerOrderListByCustomerId()
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                var customerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();

                var result = _repository.CustomerOrder.FindByCondition(c => c.CustomerId == customerId)
                      .Include(c => c.CustomerOrderProduct).ThenInclude(c => c.Product).ToList();


                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Internal server error");
            }
        }

        [HttpGet]
        [Route("CustomerOrder/GetCustomerOrderShortListByCustomerId")]
        public IActionResult GetCustomerOrderShortListByCustomerId()
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                var customerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();

                var productList = _repository.CustomerOrder.FindByCondition(c => c.CustomerId == customerId)
                    .Include(c => c.CustomerOrderProduct).Include(c => c.CustomerOrderPayment).ToList();

                var result = _mapper.Map<List<CustomerOrderListDto>>(productList);
                return Ok(result);
            }
            catch (Exception e)
            {
               
                return BadRequest("Internal server error");
            }
        }


        [HttpGet]
        [Route("CustomerOrder/GetCustomerOrderProductList")]
        public IActionResult GetCustomerOrderProductList(long customerOrderId)
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                var customerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();
                var allowed = _repository.CustomerOrder
                    .FindByCondition(c => c.Id == customerOrderId && c.CustomerId == customerId).Any();
                if (!allowed)
                {
                    return Forbid();
                }

                var productList = _repository.CustomerOrderProduct.FindByCondition(c => c.CustomerOrderId == customerOrderId)
                    .Include(c => c.Product).ThenInclude(c => c.Seller).ToList();

                var result = _mapper.Map<List<CustomerOrderProductDto>>(productList);
                return Ok(result);
            }
            catch (Exception e)
            {
              
                return BadRequest("Internal server error");
            }
        }

    }
}
