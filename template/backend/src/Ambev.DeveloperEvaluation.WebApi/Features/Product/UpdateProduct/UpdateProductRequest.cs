namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Image { get; set; }
}
