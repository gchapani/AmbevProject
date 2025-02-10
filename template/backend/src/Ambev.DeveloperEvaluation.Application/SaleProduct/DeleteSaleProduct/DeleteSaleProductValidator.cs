using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.DeleteSaleProduct;

public class DeleteSaleProductValidator : AbstractValidator<DeleteSaleProductCommand>
{
    public DeleteSaleProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("SaleProduct ID is required");
    }
}