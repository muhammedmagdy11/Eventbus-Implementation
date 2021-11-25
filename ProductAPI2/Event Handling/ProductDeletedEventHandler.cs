using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using ProductAPI2.Events;
using ProductAPI2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI2.Event_Handling
{
    public class ProductDeletedEventHandler : IIntegrationEventHandler<ProductDeletedEvent>
    {
        private IProductRepository _productRepository;

        public ProductDeletedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductDeletedEvent @eventt)
        {
            throw new Exception("Deleted Handled");
            // await _productRepository.d
            //await _productRepository.GetProductById(@event.Product_Id);

        }
    }
}
