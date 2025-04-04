using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .LessThanOrEqualTo(20)
                .WithMessage("Cannot sell more than 20 identical items");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0);

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(1);

            RuleFor(x => x.TotalAmount)
                .GreaterThanOrEqualTo(0);
        }
    }
} 