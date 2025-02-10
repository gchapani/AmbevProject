using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.ClientName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("ClientName must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("ClientName cannot be longer than 50 characters.");

        RuleFor(sale => sale.Branch)
           .NotEmpty()
           .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
           .MaximumLength(50).WithMessage("Branch cannot be longer than 50 characters.");
    }
}
