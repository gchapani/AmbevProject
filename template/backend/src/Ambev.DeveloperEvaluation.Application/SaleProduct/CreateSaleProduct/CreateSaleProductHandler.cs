using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;

public class CreateSaleProductHandler : IRequestHandler<CreateSaleProductCommand, CreateSaleProductResult>
{
    private readonly ISaleProductRepository _SaleProductRepository;
    private readonly IMapper _mapper;

    public CreateSaleProductHandler(ISaleProductRepository SaleProductRepository, IMapper mapper)
    {
        _SaleProductRepository = SaleProductRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleProductResult> Handle(CreateSaleProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var SaleProduct = _mapper.Map<Domain.Entities.SaleProduct>(command);

        var createdSaleProduct = await _SaleProductRepository.CreateAsync(SaleProduct, cancellationToken);
        var result = _mapper.Map<CreateSaleProductResult>(createdSaleProduct);

        return result;
    }
}