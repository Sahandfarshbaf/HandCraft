using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SellerController : ControllerBase
    {
 
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private long timeTick;

        public SellerController(IRepositoryWrapper repository, IMapper mapper)
        {
     
            _repository = repository;
            _mapper = mapper;
            timeTick = DateTime.Now.Ticks;
        }

        [HttpGet]
        [Route("Seller/GetLastestSellerList")]
        public IActionResult GetLastestSellerList()
        {
            try
            {
                var result = _repository.Seller.FindAll().OrderByDescending(c => c.Cdate).Take(10).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
             
                return BadRequest("Internal server error");
            }
        }

        [HttpGet]
        [Route("Seller/GetSellerList")]
        public IActionResult GetSellerList()
        {
            try
            {
                var result = _repository.Seller.FindByCondition(c => string.IsNullOrEmpty(c.DuserId) && string.IsNullOrEmpty(c.DaUserId)).Select(c => new { c.Id, sellername = (c.Name + c.Fname) }).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
         
                return BadRequest("Internal server error");
            }
        }
    }





}
