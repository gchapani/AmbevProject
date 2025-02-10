using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetAllProduct;

public class GetAllProductRequestValidator : AbstractValidator<GetAllProductRequest>
{
    public GetAllProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
    }
}