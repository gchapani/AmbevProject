using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    public Guid Id { get; }

    public DeleteSaleCommand(Guid id)
    {
        Id = id;
    }
}