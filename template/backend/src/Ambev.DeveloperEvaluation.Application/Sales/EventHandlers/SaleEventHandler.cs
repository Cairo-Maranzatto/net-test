using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.EventHandlers
{
    public class SaleEventHandler
    {
        private readonly ILogger<SaleEventHandler> _logger;

        public SaleEventHandler(ILogger<SaleEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleSaleCreatedEvent(SaleCreatedEvent @event)
        {
            _logger.LogInformation("Sale created: {SaleNumber}", @event.Sale.SaleNumber);
            return Task.CompletedTask;
        }

        public Task HandleSaleCancelledEvent(SaleCancelledEvent @event)
        {
            _logger.LogInformation("Sale cancelled: {SaleNumber}", @event.Sale.SaleNumber);
            return Task.CompletedTask;
        }

        public Task HandleItemCancelledEvent(ItemCancelledEvent @event)
        {
            _logger.LogInformation("Item cancelled: Sale {SaleNumber}, Product {ProductId}", 
                @event.Sale.SaleNumber, @event.ProductId);
            return Task.CompletedTask;
        }
    }
} 