using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public double SaleValueTotal { get; set; }
    public string Branch { get; set; } = string.Empty;

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}