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
    public class ProductMeterController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private string userid;
        private long timeTick;

        public ProductMeterController(IRepositoryWrapper repository, IMapper mapper)
        {
        _repository = repository;
            _mapper = mapper;
            //userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
            timeTick = DateTime.Now.Ticks;
        }
        [HttpGet]
        [Route("ProductMeter/GetProductMeterList")]
        public IActionResult GetProductMeterList()
        {

            try
            {
                var result = _repository.ProductMeter.FindByCondition(c => string.IsNullOrWhiteSpace(c.DaUserId) && string.IsNullOrWhiteSpace(c.DuserId)).Select(p => new { p.Id, p.Name }).ToList();
                
                return Ok(result);

            }
            catch (Exception e)
            {

               
                return BadRequest("Internal server error");
            }

        }
    }
}
