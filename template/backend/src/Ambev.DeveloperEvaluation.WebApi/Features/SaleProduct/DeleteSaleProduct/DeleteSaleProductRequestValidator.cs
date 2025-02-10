using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.DeleteSaleProduct;

public class DeleteSaleProductRequestValidator : AbstractValidator<DeleteSaleProductRequest>
{
    public DeleteSaleProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("SaleProduct ID is required");
    }
}