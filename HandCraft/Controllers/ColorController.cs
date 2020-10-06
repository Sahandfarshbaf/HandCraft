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
    public class ColorController : ControllerBase
    {
     
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ColorController( IRepositoryWrapper repository, IMapper mapper)
        {
           
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Color/GetColorList")]
        public IActionResult GetColorList() {

            try
            {
                var result = _repository.Color.FindAll()
                                            .Where(c => string.IsNullOrWhiteSpace(c.DaUserId) && string.IsNullOrWhiteSpace(c.DuserId))
                                            .Select(p => new { p.Id, p.Name }).ToList();
               
                return Ok(result);
            }
            catch (Exception e)
            {

               
                return BadRequest("Internal server error");
            }
        
        }
    }
}
