using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.SaleNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.BranchId)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.BranchName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.TotalAmount)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Sale must have at least one item");
        }
    }
} 