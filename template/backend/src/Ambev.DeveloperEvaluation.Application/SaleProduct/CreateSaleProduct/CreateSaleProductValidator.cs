using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;

public class CreateSaleProductCommandValidator : AbstractValidator<CreateSaleProductCommand>
{
    public CreateSaleProductCommandValidator()
    {
        RuleFor(SaleProduct => SaleProduct.SaleId).NotEmpty();
        RuleFor(SaleProduct => SaleProduct.ProductId).NotEmpty();
    }
}