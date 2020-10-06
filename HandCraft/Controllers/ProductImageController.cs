using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandCraft.Tools;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        private long timeTick;
        public ProductImageController(IRepositoryWrapper repository, IMapper mapper)
        {
  
            _repository = repository;
            _mapper = mapper;
            timeTick = DateTime.Now.Ticks;
        }

        [HttpGet]
        [Route("ProductImage/GetImageList")]
        public IActionResult GetImageList(long productId)
        {
            try
            {
                var imagelist = _repository.ProductImage.GetProductImageWithDetails(productId).Where(c=>string.IsNullOrWhiteSpace(c.DaUserId) && string.IsNullOrWhiteSpace(c.DuserId)).ToList();
                if (imagelist.Count == 0)
                {

                    return NotFound();
                }

                var imagelistResult = _mapper.Map<List<ProductImageDto>>(imagelist);

                return Ok(imagelistResult);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }

        }

        [HttpPost]
        [Route("ProductImage/InsertProductImage")]
        public IActionResult InsertProductImage(long productId, long colorId)
        {
            try
            {
                var productImageUrl = HttpContext.Request.Form.Files[0];
                FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(productImageUrl, 1, "ProductImages");
                if (uploadFileStatus.Status == 200)
                {

                    ProductImage productImage = new ProductImage
                    {

                        ImageUrl = uploadFileStatus.Path,
                        ColorId = colorId,
                        ProductId = productId,
                        //CuserId= userid
                        DaDate = timeTick

                    };

                    _repository.ProductImage.Create(productImage);
                    _repository.Save();

                    return Ok("");
                }
                else
                {


                    return BadRequest("Internal server error");
                }
            }
            catch (Exception e)
            {


                return BadRequest("Internal server error");
            }
           
            
        }

        [HttpGet]
        [Route("ProductImage/GetProductImageById")]
        public IActionResult GetProductImageById(long productImageId)
        {
            try
            {
                var image = _repository.ProductImage.FindByCondition(p=>p.Id.Equals(productImageId)).FirstOrDefault();
                if (image == null)
                {

                    return NotFound();
                }

              

                return Ok(image.ImageUrl);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }

        }

        [HttpDelete]
        [Route("ProductImage/DeleteProductImageById")]
        public IActionResult DeleteProductImageById(long productImageId)
        {
            try
            {
                var image = _repository.ProductImage.FindByCondition(p => p.Id.Equals(productImageId)).FirstOrDefault();
                if (image == null)
                {
                 
                    return NotFound();
                }

                //image.DuserId = userid;
                image.Ddate = timeTick;
                _repository.ProductImage.Update(image);
                _repository.Save();
             
                return Ok(image.ImageUrl);
            }
            catch (Exception e)
            {
 
                return BadRequest("Internal server error");
            }

        }
    }
}
