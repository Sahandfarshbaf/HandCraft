using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandCraft.Tools;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SliderController : ControllerBase
    {
 
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private string userid;
        private long timeTick;
        public SliderController(IRepositoryWrapper repository, IMapper mapper)
        {
         
            _repository = repository;
            _mapper = mapper;
            //userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
            timeTick = DateTime.Now.Ticks;
        }

        [HttpGet]
        [Route("Slider/GetSliderByPlaceCode")]
        public IActionResult GetSliderByPlaceCode(long sliderPlaceCode)
        {

            try
            {
                var slider = _repository.Slider.FindByCondition(s => s.SliderPlace.Rkey.Equals(sliderPlaceCode))
                                                .OrderByDescending(c => c.Rorder)
                                                .Select(s => new { s.Id, s.ImageUrl, s.LinkUrl }).ToList();
                if (slider.Count.Equals(0))
                {


                    return NotFound();
                }
                return Ok(slider);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }

        }

        [HttpPost]
        [Route("Slider/InserSlider")]
        public IActionResult InserSlider(Slider slider)
        {
            try
            {


                _repository.Slider.Create(slider);
                _repository.Save();
                return Created("", slider);
            }
            catch (Exception e)
            {
                return BadRequest("");
            }


        }

    }
}
