using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleProductRepository
{
    Task<SaleProduct> CreateAsync(SaleProduct SaleProduct, CancellationToken cancellationToken = default);

    Task<List<SaleProduct>?> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<List<SaleProduct>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}