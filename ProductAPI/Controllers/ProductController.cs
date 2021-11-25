using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using ProductAPI.Events;
using ProductAPI.Models;
using ProductAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventbus;

        public ProductController(IProductRepository productRepository,IEventBus eventBus)
        {
            _productRepository = productRepository;
            _eventbus = eventBus;
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
            var product =await _productRepository.GetProductById(id);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            if (product != null)
            {
              
                 await   _productRepository.UpdateProduct(product);
                var @event = new ProductNameChangedEvent(product.Id,product.Name);
              _eventbus.Publish(@event);

                    return Ok(product);

            }
            return new NoContentResult();
        }
    }
}
