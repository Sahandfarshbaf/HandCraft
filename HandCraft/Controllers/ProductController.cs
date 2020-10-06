using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandCraft.Tools;

namespace HandCraft.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private string userid;
        private long timeTick;

        public ProductController(IRepositoryWrapper repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            userid = "1";
            // userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
            timeTick = DateTime.Now.Ticks;

        }

        [HttpPost]
        [Route("Product/InsertProduct")]
        public IActionResult InsertProduct()
        {
            Product _product = JsonSerializer.Deserialize<Product>(HttpContext.Request.Form["Product"]);
            var coverImageUrl = HttpContext.Request.Form.Files[0];

            FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(coverImageUrl, 1, "ProductImages");

            Seller seller = new Seller();

            if (uploadFileStatus.Status == 200)
            {
                _product.CoverImageUrl = uploadFileStatus.Path;

                userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();
                if (_product.SellerId == null || _product.SellerId == 0)
                {
                    seller = _repository.Seller.FindByCondition(c => c.UserId == userid).FirstOrDefault();
                }
                else
                {
                    seller = _repository.Seller.FindByCondition(c => c.Id == _product.SellerId).FirstOrDefault();
                }

                _product.SellerId = seller.Id;

                var catProduct = _repository.CatProduct.FindByCondition(c => c.Id == _product.CatProductId)
                    .FirstOrDefault();
                var counter = (_repository.Product
                                  .FindByCondition(c => c.SellerId == seller.Id && c.CatProductId == catProduct.Id)
                                  .Count() + 1).ToString();
                counter = counter.PadLeft(3, '0');
                _product.Coding = long.Parse(seller.SellerCode.ToString() + catProduct.Coding.ToString() + counter);
                _product.CuserId = userid;
                _product.Cdate = timeTick;
                _repository.Product.Create(_product);

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
        [Route("Product/EditProduct")]
        public IActionResult EditProduct(long productId)
        {


            Product _product = JsonSerializer.Deserialize<Product>(HttpContext.Request.Form["Product"]);
            Seller seller = new Seller();
            userid = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).SingleOrDefault();

            var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            if (_product.SellerId == null || _product.SellerId == 0)
            {
                seller = _repository.Seller.FindByCondition(c => c.UserId == userid).FirstOrDefault();
            }
            else
            {
                seller = _repository.Seller.FindByCondition(c => c.Id == _product.SellerId).FirstOrDefault();
            }

            if (product.SellerId != seller.Id || product.CatProductId != _product.CatProductId)
            {
                var catProduct = _repository.CatProduct.FindByCondition(c => c.Id == _product.CatProductId)
                    .FirstOrDefault();
                var counter = (_repository.Product
                                   .FindByCondition(c => c.SellerId == seller.Id && c.CatProductId == catProduct.Id)
                                   .Count() + 1).ToString();
                counter = counter.PadLeft(3, '0');
                product.Coding = long.Parse(seller.SellerCode.ToString() + catProduct.Coding.ToString() + counter);

            }

            product.Name = _product.Name;
            product.EnName = _product.EnName;
            product.CatProductId = _product.CatProductId;
            product.Coding = _product.Coding;
            product.Price = _product.Price;
            product.FirstCount = _product.FirstCount;
            product.ProductMeterId = _product.ProductMeterId;
            product.Description = _product.Description;
            product.SellerId = seller.Id;
            product.MuserId = userid;
            product.Mdate = timeTick;

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var coverImageUrl = HttpContext.Request.Form.Files[0];
                var deletedFile = product.CoverImageUrl;
                FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(coverImageUrl, 1, "ProductImages");
                if (uploadFileStatus.Status == 200)
                {

                    product.CoverImageUrl = uploadFileStatus.Path;
                    _repository.Product.Update(product);
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

                _repository.Product.Update(product);
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
        [Route("Product/DeleteProduct")]
        public IActionResult DeleteProduct(long productId)
        {

            try
            {
                var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
                if (product == null)
                {
                               return NotFound();

                }
                product.Ddate = timeTick;
                product.DuserId = userid;
                _repository.Product.Update(product);
                _repository.Save();

                return Ok("");


            }
            catch (Exception e)
            {

       
                return BadRequest("Internal server error");
            }
        }

        [HttpGet]
        [Route("Product/GetProductById")]
        public IActionResult GetProductById(long productId)
        {
            try
            {
                var result = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
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

        [HttpGet]
        [Route("Product/GetSellerProductList")]
        public IActionResult GetSellerProductList(long? sellerId)
        {
            try
            {
                long _sellerId;
                if (!sellerId.Equals(null))
                {
                    _sellerId = sellerId.Value;
                }
                else
                {

                    _sellerId = _repository.Seller.FindByCondition(s => s.UserId.Equals(userid)).Select(c => c.Id).FirstOrDefault();
                }

                var productList = _repository.Product.GetSellerProductList(_sellerId).ToList();
                var result = _mapper.Map<List<ProductDto>>(productList);

                return Ok(result);
            }
            catch (Exception e)
            {

     
                return BadRequest("Internal server error");
            }

        }

        [HttpGet] //محصولاتی که بیشترین امتیاز را دارند
        [Route("Product/GetTopProductListWithRate")]
        public IActionResult GetTopProductListWithRate()
        {

            try
            {
                var productList = _repository.Product.GetTopProductListWithRate()
                             .ToList();

                var result = _mapper.Map<List<ProductByOfferRate>>(productList);

  
                return Ok(result);
            }
            catch (Exception e)
            {


                return BadRequest("Internal server error");
            }

        }

        [HttpGet] // آخرین محصولات
        [Route("Product/GetLatestProductList")]
        public IActionResult GetLatestProductList()
        {
            try
            {
                var productList = _repository.Product.GetProductListWithDetail().OrderByDescending(p => p.Id).Take(10)
                    .ToList();
                var result = _mapper.Map<List<ProductByOfferRate>>(productList);

     
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }
        }

        [HttpGet] // محصولاتی که بیشترین بازدید را دارند
        [Route("Product/GetMostSeenProductList")]
        public IActionResult GetMostSeenProductList()
        {
            try
            {
                var productList = _repository.Product.FindAll().Include(c=>c.ProductOffer).OrderByDescending(p => p.SeenCount).Take(10)
                    .ToList();
                var result = _mapper.Map<List<ProductByOfferRate>>(productList);


                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }
        }

        [HttpGet]
        [Route("Product/GetProductInfoById")]
        public IActionResult GetProductInfoById(long producId)
        {
            try
            {
                var product = _repository.Product.FindByCondition(c => c.Id.Equals(producId)).Include(p => p.CatProduct).FirstOrDefault();
                var result = _mapper.Map<ProductDto>(product);
                product.SeenCount = product.SeenCount + 1;
                product.LastSeenDate = timeTick;
                _repository.Product.Update(product);
                _repository.Save();

                return Ok(result);
            }
            catch (Exception e)
            {
        
                return BadRequest("Internal server error");
            }
        }

        [HttpGet] // محصولاتی که اخیرا بازدید شده اند  
        [Route("Product/GetLatestSeenProductList")]
        public IActionResult GetLatestSeenProductList()
        {
            try
            {
                var productList = _repository.Product.FindAll().OrderByDescending(p => p.LastSeenDate).Take(10)
                    .ToList();
                var result = _mapper.Map<List<ProductDto>>(productList);
       
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("");
            }
        }

        [HttpGet] //لیست محصولات بر اساس دسته بندی
        [Route("Product/GetProductByCatId")]
        public IActionResult GetProductByCatId(long catId)
        {

            try
            {
                var productList = _repository.Product.GetProductListByCatId(catId)
                    .ToList();

                var result = _mapper.Map<List<ProductByOfferRate>>(productList);

      
                return Ok(result);
            }
            catch (Exception e)
            {

        
                return BadRequest("Internal server error");
            }

        }

        [HttpGet]
        [Route("Product/GetFullInfoProductById")]
        public IActionResult GetFullInfoProductById(long productId)
        {
            try
            {
                var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId))
                                    .Include(p => p.CatProduct)
                                    .Include(p => p.ProductCustomerRate)
                                    .Include(p => p.ProductOffer)
                                    .FirstOrDefault();
                if (product.Equals(null))
                {
               
                    return NotFound();
                }
                var result = _mapper.Map<ProductByOfferRate>(product);
      

                return Ok(result);
            }
            catch (Exception e)
            {

          
                return BadRequest("Internal server error");
            }

        }

        [HttpGet] //لیست محصولات بر اساس دسته بندی و زیرمجموعه
        [Route("Product/GetProductByParentCatId")]
        public IActionResult GetProductByParentCatId(long catId)
        {

            try
            {
                var productList = _repository.Product.GetProductListByParentCatId(catId)
                    .ToList();

                var result = _mapper.Map<List<ProductByOfferRate>>(productList);

                return Ok(result);
            }
            catch (Exception e)
            {

               
                return BadRequest("Internal server error");
            }

        }

        [HttpGet]
        [Route("Product/GetSimilarProductsByProductId")]
        public IActionResult GetSimilarProductsByProductId(long productId)
        {
            try
            {
                var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();

                if (product == null)
                {
                    return NotFound();
                }
                var productlist = _repository.Product.FindByCondition(c => c.CatProductId == product.CatProductId)
                    .Include(p => p.CatProduct)
                    .Include(p => p.ProductCustomerRate)
                    .Include(p => p.ProductOffer)
                    .ToList();

                var result = _mapper.Map<List<ProductByOfferRate>>(productlist);
              

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }

        }


    }
}
