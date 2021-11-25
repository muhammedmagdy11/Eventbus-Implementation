using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using ProductAPI2.Events;
using ProductAPI2.Models;
using ProductAPI2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI2.Event_Handling
{
    public class ProductNameChangedEventHandler : IIntegrationEventHandler<ProductNameChangedEvent>
    {
        private IProductRepository _productRepository;

        public ProductNameChangedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductNameChangedEvent @eventt)
        {
            Product product = new Product() { Id = @eventt.Product_Id, Name = @eventt.Name };
            await _productRepository.UpdateProduct(product);
            //await _productRepository.GetProductById(@event.Product_Id);

        }
    }
}
