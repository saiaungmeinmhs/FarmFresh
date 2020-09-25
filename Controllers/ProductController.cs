using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FarmFresh.Models;
using FarmFresh.Interfaces.Repo;
using FarmFresh.Dto.ProductDto;

namespace FarmFresh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo _repo;
        public ProductController(ILogger<HomeController> logger,IProductRepo repo)
        {
            _logger = logger;
            _repo=repo;
        }

        [HttpGet("GetProductList")]
        public async Task<IActionResult> GetProductList([FromQuery]GetProductListRequest request)
        {            
            var data = await _repo.GetProductList(request);
            return Ok(data);
        }

        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {            
            var data = await _repo.GetCategoryList();
            return Ok(data);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {            
            var data = await _repo.CreateProduct(request);
            return Ok(data);
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {            
            var data = await _repo.UpdateProduct(request);
            return Ok(data);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {            
            var data = await _repo.DeleteProduct(productId);
            return Ok(data);
        }

    }
}
