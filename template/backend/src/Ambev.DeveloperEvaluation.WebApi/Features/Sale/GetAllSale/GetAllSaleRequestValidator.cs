using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetAllSale;

public class GetAllSaleRequestValidator : AbstractValidator<GetAllSaleRequest>
{
    public GetAllSaleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required");
    }
}