using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

public class GetAllSaleHandler : IRequestHandler<GetAllSaleCommand, List<GetAllSaleResult>>
{
    private readonly ISaleRepository _SaleRepository;
    private readonly ISaleProductRepository _SaleProductRepository;
    private readonly IMapper _mapper;

    public GetAllSaleHandler(ISaleRepository SaleRepository, ISaleProductRepository SaleProductRepository, IMapper mapper)
    {
        _SaleRepository = SaleRepository;
        _SaleProductRepository = SaleProductRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllSaleResult>> Handle(GetAllSaleCommand request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Sale>? Sale = await _SaleRepository.GetAllAsync(cancellationToken);

        foreach (Domain.Entities.Sale item in Sale)
        {
            item.SaleProduct = await _SaleProductRepository.GetByIdAsync(item.Id, cancellationToken);
        }

        if (Sale == null)
            throw new KeyNotFoundException($"Sale not found");

        return _mapper.Map<List<GetAllSaleResult>>(Sale);
    }
}