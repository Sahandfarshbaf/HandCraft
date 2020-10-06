using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
     
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly long timeTick;

        public CustomerAddressController( IRepositoryWrapper repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            this.timeTick = DateTime.Now.Ticks;
        }


        [HttpPost]
        [Route("CustomerAddress/InsertCustomerAddress")]
        public IActionResult InsertCustomerAddress(CustomerAddress customerAddress)
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();

                if (customerAddress.CustomerId == null || customerAddress.CustomerId == 0)
                {
                    customerAddress.CustomerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();
                }

                customerAddress.Cdate = timeTick;
                customerAddress.CuserId = userid;

                _repository.CustomerAddress.Create(customerAddress);
                _repository.Save();

                return Ok("");
            }
            catch (Exception e)
            {
            
                return BadRequest("Internal server error");
            }
        }

        [HttpPut]
        [Route("CustomerAddress/UpdateCustomerAddress")]
        public IActionResult UpdateCustomerAddress(CustomerAddress customerAddress)
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();

                if (customerAddress.CustomerId == null || customerAddress.CustomerId == 0)
                {
                    customerAddress.CustomerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();
                }

                var cAddress = _repository.CustomerAddress.FindByCondition(c => c.Id == customerAddress.Id)
                    .FirstOrDefault();
                if (cAddress == null)
                {
                    return NotFound("id not found!");
                }

                cAddress.CustomerId = customerAddress.CustomerId;
                cAddress.Address = customerAddress.Address;
                cAddress.CityId = customerAddress.CityId;
                cAddress.DefaultAddress = customerAddress.DefaultAddress;
                cAddress.PostalCode = customerAddress.PostalCode;
                cAddress.ProvinceId = customerAddress.ProvinceId;
                cAddress.Xgps = customerAddress.Xgps;
                cAddress.Ygps = customerAddress.Ygps;
                cAddress.Mdate = timeTick;
                cAddress.MuserId = userid;

                _repository.CustomerAddress.Update(cAddress);
                _repository.Save();

                return Ok("");
            }
            catch (Exception e)
            {
   
                return BadRequest("Internal server error");
            }
        }


        [HttpGet]
        [Route("CustomerAddress/GetCustomerAddressList")]
        public IActionResult GetCustomerAddressList()
        {
            try
            {
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                var customerId = _repository.Customer.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();

                var addresslist = _repository.CustomerAddress.FindByCondition(c => c.CustomerId == customerId && string.IsNullOrWhiteSpace(c.DuserId) && string.IsNullOrWhiteSpace(c.DaUserId))
                    .Include(c => c.Province).Include(c => c.City).ToList();

                var result = _mapper.Map<List<CustomerAddressDto>>(addresslist);
                return Ok(result);
            }
            catch (Exception e)
            {
         
                return BadRequest("Internal server error");
            }
        }

 
        [HttpGet]
        [Route("CustomerAddress/GetCustomerAddressListByCustomerId")]
        public IActionResult GetCustomerAddressList(long customerId)
        {
            try
            {

                var addresslist = _repository.CustomerAddress.FindByCondition(c => c.CustomerId == customerId && string.IsNullOrWhiteSpace(c.DuserId) && string.IsNullOrWhiteSpace(c.DaUserId))
                    .Include(c => c.Province).Include(c => c.City).ToList();

                var result = _mapper.Map<List<CustomerAddressDto>>(addresslist);
                return Ok(result);
            }
            catch (Exception e)
            {
          
                return BadRequest("Internal server error");
            }
        }


        [HttpDelete]
        [Route("CustomerAddress/DeleteCustomerAddress")]
        public IActionResult DeleteCustomerAddress(long customerId)
        {
            try
            {

                var address = _repository.CustomerAddress.FindByCondition(c => c.CustomerId == customerId).FirstOrDefault();
                if (address == null)
                {
                    return NotFound("id not found!");
                }
                var userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                address.Ddate = timeTick;
                address.DuserId = userid;
                _repository.CustomerAddress.Update(address);
                return Ok("");
            }
            catch (Exception e)
            {
            
                return BadRequest("Internal server error");
            }
        }
    }
}
