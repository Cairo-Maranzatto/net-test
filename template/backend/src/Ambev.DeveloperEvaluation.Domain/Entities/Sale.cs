using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public string CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string BranchId { get; private set; }
        public string BranchName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public bool IsCancelled { get; private set; }
        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();
        private readonly List<SaleItem> _items = new();

        private Sale() { }

        public Sale(string saleNumber, string customerId, string customerName, string branchId, string branchName)
        {
            SaleNumber = saleNumber;
            SaleDate = DateTime.UtcNow;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            TotalAmount = 0;
            IsCancelled = false;

            AddDomainEvent(new SaleCreatedEvent(this));
        }

        public void AddItem(string productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new DomainException("Cannot sell more than 20 identical items");

            var item = new SaleItem(productId, productName, quantity, unitPrice);
            _items.Add(item);
            RecalculateTotalAmount();
        }

        public void Cancel()
        {
            if (IsCancelled)
                throw new DomainException("Sale is already cancelled");

            IsCancelled = true;
            AddDomainEvent(new SaleCancelledEvent(this));
        }

        public void CancelItem(string productId)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
                throw new DomainException("Item not found");

            item.Cancel();
            RecalculateTotalAmount();
            AddDomainEvent(new ItemCancelledEvent(this, productId));
        }

        private void RecalculateTotalAmount()
        {
            TotalAmount = _items.Sum(item => item.TotalAmount);
        }

        public void Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            if (!result.IsValid)
                throw new DomainException(string.Join(", ", result.Errors.Select(e => e.ErrorMessage)));
        }
    }
} 