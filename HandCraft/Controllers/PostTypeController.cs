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
    public class PostTypeController : ControllerBase
    {
      
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private string userid;
        private long timeTick;

        public PostTypeController(IRepositoryWrapper repository, IMapper mapper)
        {
          
            _repository = repository;
            _mapper = mapper;
            //userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
            timeTick = DateTime.Now.Ticks;
        }

        [HttpGet]
        [Route("PostType/GetPostTypeList")]
        public IActionResult GetPostTypeList()
        {
            try
            {
                var result = _repository.PostType.FindByCondition(c => c.DaUserId.Equals(null) && c.DuserId.Equals(null))
                    .Select(c => new { c.Id, c.Title, c.Icon, c.Description, c.Price }).ToList();
              
                return Ok(result);
            }
            catch (Exception e)
            {
           
                return BadRequest("Internal server error");
            }

        }
    }
}
