using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
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

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Sale must have at least one item");

            RuleForEach(x => x.Items).SetValidator(new CreateSaleItemRequestValidator());
        }
    }

    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemRequestValidator()
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
        }
    }
} 