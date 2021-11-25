using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Events
{
    public record ProductNameChangedEvent:IntegrationEvent
    {
        public int Product_Id { get; set; }
        public string Name { get; set; }

        public ProductNameChangedEvent(int product_Id, string name)
        {
            Product_Id = product_Id;
            Name = name;
        }
    }
}
