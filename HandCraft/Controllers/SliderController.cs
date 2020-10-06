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
        [Route("Slider/GetSliderByTypeId")]
        public IActionResult GetSliderByTypeId(long typeId)
        {

            try
            {
                var slider = _repository.Slider.FindByCondition(s => s.SliderPlaceType.Rkey.Equals(typeId))
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
        [Route("Slider/InsertSlider")]
        public IActionResult InsertSlider()
        {
            Slider _slider = JsonSerializer.Deserialize<Slider>(HttpContext.Request.Form["Slider"]);
            var imageUrl = HttpContext.Request.Form.Files[0];

            FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(imageUrl, 1, "SliderImages");

            if (uploadFileStatus.Status == 200)
            {
                _slider.ImageUrl = uploadFileStatus.Path;
                _slider.CuserId = userid;
                _slider.Cdate = timeTick;
                _repository.Slider.Create(_slider);

                try
                {
                    _repository.Save();

                    return Ok("");
                }
                catch (Exception e)
                {

                    FileManeger.FileRemover(new List<string> { uploadFileStatus.Path });
                    return BadRequest(e.Message.ToString());
                }

            }
            else
            {

                return BadRequest("Internal server error");
            }


        }

        [HttpPut]
        [Route("Slider/EditSlider")]
        public IActionResult EditSlider(long sliderId)
        {


            Slider _slider = JsonSerializer.Deserialize<Slider>(HttpContext.Request.Form["Slider"]);
            var slider = _repository.Slider.FindByCondition(c => c.Id.Equals(sliderId)).FirstOrDefault();
            if (slider.Equals(null))
            {

                return NotFound();
            }

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var imageUrl = HttpContext.Request.Form.Files[0];
                var deletedFile = slider.ImageUrl;
                FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(imageUrl, 1, "SliderImages");
                if (uploadFileStatus.Status == 200)
                {

                    slider.ImageHurl = _slider.ImageHurl;
                    slider.ImageUrl = uploadFileStatus.Path;
                    slider.LinkUrl = _slider.LinkUrl;
                    slider.Mdate = timeTick;
                    slider.MuserId = userid;
                    slider.Rorder = _slider.Rorder;
                    slider.SliderPlaceTypeId = _slider.SliderPlaceTypeId;
                    slider.Title = _slider.Title;
                    _repository.Slider.Update(slider);
                    try
                    {
                        _repository.Save();
                        FileManeger.FileRemover(new List<string> { deletedFile });

                        return Ok("");
                    }
                    catch (Exception e)
                    {


                        FileManeger.FileRemover(new List<string> { uploadFileStatus.Path });
                        return BadRequest("Internal server error");
                    }

                }
                else
                {

                    return BadRequest("Internal server error");
                }
            }
            else
            {

                slider.ImageHurl = _slider.ImageHurl;
                slider.LinkUrl = _slider.LinkUrl;
                slider.Mdate = timeTick;
                slider.MuserId = userid;
                slider.Rorder = _slider.Rorder;
                slider.SliderPlaceTypeId = _slider.SliderPlaceTypeId;
                slider.Title = _slider.Title;
                _repository.Slider.Update(slider);
                try
                {
                    _repository.Save();

                    return Ok("");
                }
                catch (Exception e)
                {

        
                    return BadRequest("Internal server error");
                }


            }


        }

        [HttpDelete]
        [Route("Slider/DeleteSlider")]
        public IActionResult DeleteSlider(long sliderId)
        {

            try
            {
                var slider = _repository.Slider.FindByCondition(c => c.Id.Equals(sliderId)).FirstOrDefault();
                if (slider.Equals(null))
                {
   
                    return NotFound();

                }
                slider.Ddate = timeTick;
                slider.DuserId = userid;
                _repository.Slider.Update(slider);
                _repository.Save();
     
                return Ok("");


            }
            catch (Exception e)
            {


                return BadRequest("Internal server error");
            }
        }

        [HttpGet]
        [Route("Slider/GetSliderById")]
        public IActionResult GetSliderById(long sliderId)
        {
            try
            {
                var result = _repository.Slider.FindByCondition(c => c.Id.Equals(sliderId)).FirstOrDefault();
                if (result.Equals(null))
                {
             
                    return NotFound();
                }
          
                return Ok(result);
            }
            catch (Exception e)
            {

     
                return BadRequest("Internal server error");
            }

        }

    
    }
}
