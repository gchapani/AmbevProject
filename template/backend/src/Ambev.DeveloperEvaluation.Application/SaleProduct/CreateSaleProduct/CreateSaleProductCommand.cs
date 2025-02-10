using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;

public class CreateSaleProductCommand : IRequest<CreateSaleProductResult>
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantities { get; set; }
    public double Discount { get; set; }
    public bool Canceled { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}