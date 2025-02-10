using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProduct;

public record GetAllProductCommand : IRequest<List<GetAllProductResult>>
{
    public Guid Id { get; }
}