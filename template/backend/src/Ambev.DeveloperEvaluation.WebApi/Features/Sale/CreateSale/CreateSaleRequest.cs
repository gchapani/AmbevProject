using Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleRequest
{
    public int SaleNumber { get; set; }
    [JsonIgnore]
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = string.Empty;
    [JsonIgnore]
    public double SaleValueTotal { get; set; }
    public string Branch { get; set; } = string.Empty;
    public List<CreateSaleProductRequest>? SaleProductList { get; set; }
}