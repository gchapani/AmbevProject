using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.ClientName).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.SaleProductList!.Where(x => x.Quantities > 20));
        RuleForEach(sale => sale.SaleProductList).ChildRules(saleProduct =>
        {
            saleProduct.RuleFor(sp => sp.Quantities).LessThan(20).WithMessage("Quantities must be less than 20.");
        });
    }
}