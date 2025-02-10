using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AmbevContext _context;

    public ProductRepository(AmbevContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product Product, CancellationToken cancellationToken = default)
    {
        await _context.Product.AddAsync(Product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Product;
    }

    public async Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Product.ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Product.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Product = await GetByIdAsync(id, cancellationToken);

        if (Product == null)
            return false;

        _context.Product.Remove(Product);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        var ProductExist = await GetByIdAsync(product.Id, cancellationToken);

        if (ProductExist == null)
            return false;

        _context.Entry(ProductExist).State = EntityState.Detached;
        _context.Product.Update(product);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}