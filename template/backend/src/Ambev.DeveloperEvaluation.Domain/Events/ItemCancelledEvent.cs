using System;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ItemCancelledEvent : DomainEvent
    {
        public Sale Sale { get; }
        public string ProductId { get; }

        public ItemCancelledEvent(Sale sale, string productId)
        {
            Sale = sale;
            ProductId = productId;
        }
    }
} 