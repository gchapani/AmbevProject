using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleProductRepository : ISaleProductRepository
{
    private readonly AmbevContext _context;

    public SaleProductRepository(AmbevContext context)
    {
        _context = context;
    }

    public async Task<SaleProduct> CreateAsync(SaleProduct SaleProduct, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _context.SaleProduct.AsNoTracking()
            .FirstOrDefaultAsync(sp => sp.SaleId == SaleProduct.SaleId && sp.ProductId == SaleProduct.ProductId, cancellationToken);

        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        }

        await _context.SaleProduct.AddAsync(SaleProduct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return SaleProduct;
    }

    public async Task<List<SaleProduct>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaleProduct.ToListAsync(cancellationToken);
    }

    public async Task<List<SaleProduct>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleProduct.AsNoTracking().Where(o => o.SaleId == id).ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var SaleProduct = await GetByIdAsync(id, cancellationToken);

        if (SaleProduct == null)
            return false;

        _context.SaleProduct.RemoveRange(SaleProduct);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}