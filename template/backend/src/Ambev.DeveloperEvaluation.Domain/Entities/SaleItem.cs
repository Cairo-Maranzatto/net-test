using System;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public bool IsCancelled { get; private set; }

        private SaleItem() { }

        public SaleItem(string productId, string productName, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            IsCancelled = false;

            CalculateDiscount();
            CalculateTotalAmount();
        }

        public void Cancel()
        {
            if (IsCancelled)
                throw new DomainException("Item is already cancelled");

            IsCancelled = true;
            CalculateTotalAmount();
        }

        private void CalculateDiscount()
        {
            if (Quantity < 4)
            {
                Discount = 0;
                return;
            }

            if (Quantity >= 10 && Quantity <= 20)
            {
                Discount = 0.20m; // 20% discount
                return;
            }

            if (Quantity >= 4)
            {
                Discount = 0.10m; // 10% discount
                return;
            }

            Discount = 0;
        }

        private void CalculateTotalAmount()
        {
            var subtotal = Quantity * UnitPrice;
            var discountAmount = subtotal * Discount;
            TotalAmount = subtotal - discountAmount;
        }

        public void Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);
            if (!result.IsValid)
                throw new DomainException(string.Join(", ", result.Errors.Select(e => e.ErrorMessage)));
        }
    }
} 