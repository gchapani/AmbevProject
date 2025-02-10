using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProduct;

public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, List<GetAllProductResult>>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public GetAllProductHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllProductResult>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
    {
        var Product = await _ProductRepository.GetAllAsync(cancellationToken);

        if (Product == null)
            throw new KeyNotFoundException($"Product not found");

        return _mapper.Map<List<GetAllProductResult>>(Product);
    }
}