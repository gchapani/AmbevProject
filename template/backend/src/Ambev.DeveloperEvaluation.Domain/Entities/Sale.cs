using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity, ISale
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; }
    public double SaleValueTotal { get; set; }
    public string Branch { get; set; }
    public ICollection<SaleProduct> SaleProduct { get; set; } = new List<SaleProduct>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    string ISale.Id => Id.ToString();

    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
