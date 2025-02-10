using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.DeleteSaleProduct;

public record DeleteSaleProductCommand : IRequest<DeleteSaleProductResponse>
{
    public Guid Id { get; }

    public DeleteSaleProductCommand(Guid id)
    {
        Id = id;
    }
}