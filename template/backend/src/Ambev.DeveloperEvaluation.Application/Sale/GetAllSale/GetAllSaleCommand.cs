using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

public record GetAllSaleCommand : IRequest<List<GetAllSaleResult>>
{
    public Guid Id { get; }
}