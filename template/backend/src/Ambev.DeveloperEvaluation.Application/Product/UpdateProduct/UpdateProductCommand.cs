using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;

public record UpdateProductCommand : IRequest<UpdateProductResult>
{
    public Guid Id { get; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    public UpdateProductCommand(Guid id)
    {
        Id = id;
    }
}