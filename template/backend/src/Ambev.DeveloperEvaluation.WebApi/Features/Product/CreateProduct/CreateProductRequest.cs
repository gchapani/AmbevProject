using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;

public class CreateProductRequest
{
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    [JsonIgnore]
    public int Quantities { get; set; }
    [JsonIgnore]
    public double Discount { get; set; }
    [JsonIgnore]
    public bool Canceled { get; set; }
}