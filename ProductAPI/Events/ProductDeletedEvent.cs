using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Events
{
    public record ProductDeletedEvent:IntegrationEvent
    {
        public int Product_Id { get; set; }

        public ProductDeletedEvent(int product_Id)
        {
            Product_Id = product_Id;
        }
    }
}
