using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.DeleteSaleProduct;

public class DeleteSaleProductHandler : IRequestHandler<DeleteSaleProductCommand, DeleteSaleProductResponse>
{
    private readonly ISaleProductRepository _SaleProductRepository;

    public DeleteSaleProductHandler(ISaleProductRepository SaleProductRepository)
    {
        _SaleProductRepository = SaleProductRepository;
    }

    public async Task<DeleteSaleProductResponse> Handle(DeleteSaleProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SaleProductRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"SaleProduct with ID {request.Id} not found");

        return new DeleteSaleProductResponse { Success = true };
    }
}