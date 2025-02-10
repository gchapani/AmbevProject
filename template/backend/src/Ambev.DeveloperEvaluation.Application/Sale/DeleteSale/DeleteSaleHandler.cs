using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _SaleRepository;

    public DeleteSaleHandler(ISaleRepository SaleRepository)
    {
        _SaleRepository = SaleRepository;
    }

    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SaleRepository.DeleteAsync(request.Id, cancellationToken);

        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        return new DeleteSaleResponse { Success = true };
    }
}