using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public GetProductHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }

    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Product = await _ProductRepository.GetByIdAsync(request.Id, cancellationToken);

        if (Product == null)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        return _mapper.Map<GetProductResult>(Product);
    }
}