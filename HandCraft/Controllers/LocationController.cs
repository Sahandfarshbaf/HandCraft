using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LocationController : ControllerBase
    {
 
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public LocationController(IRepositoryWrapper repository, IMapper mapper)
        {
        
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Location/GetCountryList")]
        public IActionResult GetCountryList()
        {
            var countrylist = _repository.Location.GetCountryList().ToList();
         
            return Ok(countrylist);
        }

        [HttpGet]
        [Route("Location/GetProvinceList")]
        public IActionResult GetProvinceList(long? countryId)
        {
            var provincelist = _repository.Location.GetProvinceList(countryId).ToList();
      
            return Ok(provincelist);
        }

        [HttpGet]
        [Route("Location/GetCityList")]
        public IActionResult GetCityList(long provinceId)
        {
            var citylist = _repository.Location.GetCityList(provinceId).ToList();
            
            return Ok(citylist);
        }
    }
}
