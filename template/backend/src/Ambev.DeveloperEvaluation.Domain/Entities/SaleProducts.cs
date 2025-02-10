using Ambev.DeveloperEvaluation.Domain.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleProduct : ISaleProduct
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantities { get; set; }
    public double Discount { get; set; }
    public bool Canceled { get; set; }
    public virtual Sale? Sale { get; set; }
    public virtual Product? Product { get; set; }
}
