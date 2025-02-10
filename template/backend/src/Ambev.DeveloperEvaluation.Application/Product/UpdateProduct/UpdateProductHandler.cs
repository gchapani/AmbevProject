using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Product = _mapper.Map<Domain.Entities.Product>(command);

        var success = await _ProductRepository.UpdateAsync(Product, cancellationToken);

        if (!success)
            throw new KeyNotFoundException($"Product with ID {Product.Id} not found");

        return new UpdateProductResult { Id = Product.Id };
    }
}