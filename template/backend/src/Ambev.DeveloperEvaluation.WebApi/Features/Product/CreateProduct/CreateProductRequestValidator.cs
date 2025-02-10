using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(Product => Product.Title).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Description).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Price).NotEmpty();
    }
}