using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerOfferController : ControllerBase
    {
    
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private long timeTick;

        public CustomerOfferController(IRepositoryWrapper repository, IMapper mapper)
        {
       
            _repository = repository;
            _mapper = mapper;
            this.timeTick = DateTime.Now.Ticks;
        }

        [HttpGet]
        [Route("CustomerOffer/GetCustomerOfferByCode")]
        public IActionResult GetCustomerOfferByCode(string code)
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                var customerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();
                var offer = _repository.CustomerOffer
                    .FindByCondition(c =>
                        c.OfferCode == code && string.IsNullOrWhiteSpace(c.DuserId) &&  string.IsNullOrWhiteSpace(c.DaUserId) &&
                        c.CustomerId == customerId && c.FromDate <= timeTick && timeTick <= c.ToDate).FirstOrDefault();
                if (offer==null)
                {

                    return NotFound("کد تخفیف وارد شده معتبر نمی باشد.");
                }

                return Ok(offer.Value);
            }
            catch (Exception e)
            {
        
                return BadRequest("Internal server error");
            }
        }
    }
}
