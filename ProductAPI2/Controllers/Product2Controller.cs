using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI2.Models;
using ProductAPI2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public Product2Controller(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            if (product != null)
            {

                await _productRepository.UpdateProduct(product);
                return Ok(product);

            }
            return new NoContentResult();
        }
    }
}
