using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(Product => Product.Title).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Description).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Price).NotEmpty();
    }
}