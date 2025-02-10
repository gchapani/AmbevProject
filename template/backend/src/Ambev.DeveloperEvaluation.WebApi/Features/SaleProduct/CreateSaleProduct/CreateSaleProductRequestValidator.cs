using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;

public class CreateSaleProductRequestValidator : AbstractValidator<CreateSaleProductRequest>
{
    public CreateSaleProductRequestValidator()
    {
        RuleFor(SaleProduct => SaleProduct.ProductId).NotEmpty();
        RuleFor(SaleProduct => SaleProduct.SaleId).NotEmpty();
    }
}