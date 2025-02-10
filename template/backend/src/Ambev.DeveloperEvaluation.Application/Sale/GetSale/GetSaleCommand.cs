using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

public record GetSaleCommand : IRequest<GetSaleResult>
{
    public Guid Id { get; }

    public GetSaleCommand(Guid id)
    {
        Id = id;
    }
}