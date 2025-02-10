using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct
{
    public class CreateSaleProductListHandler : IRequestHandler<CreateSaleProductListCommand, List<CreateSaleProductResult>>
    {
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;

        public CreateSaleProductListHandler(ISaleProductRepository saleProductRepository, IMapper mapper)
        {
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
        }

        public async Task<List<CreateSaleProductResult>> Handle(CreateSaleProductListCommand request, CancellationToken cancellationToken)
        {
            var results = new List<CreateSaleProductResult>();

            foreach (var command in request.SaleProductCommands)
            {
                var saleProduct = _mapper.Map<Domain.Entities.SaleProduct>(command);
                var createdSaleProduct = await _saleProductRepository.CreateAsync(saleProduct, cancellationToken);
                var result = _mapper.Map<CreateSaleProductResult>(createdSaleProduct);
                results.Add(result);
            }

            return results;
        }
    }
}