namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;

public class CreateSaleProductResponse
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantities { get; set; }
    public double Discount { get; set; }
    public bool Canceled { get; set; }
}