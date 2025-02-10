using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;

public class CreateSaleProductRequest
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantities { get; set; }
    [JsonIgnore]
    public double Discount { get; set; }
    [JsonIgnore]
    public bool Canceled { get; set; }
}