using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class AmbevContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<SaleProduct> SaleProduct { get; set; }

    public AmbevContext(DbContextOptions<AmbevContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SaleProduct>().HasKey(sp => new { sp.SaleId, sp.ProductId });

        modelBuilder.Entity<SaleProduct>()
            .HasOne<Sale>(sp => sp.Sale)
            .WithMany(s => s.SaleProduct)
            .HasForeignKey(sp => sp.SaleId);

        modelBuilder.Entity<SaleProduct>()
            .HasOne<Product>(sp => sp.Product)
            .WithMany(p => p.SaleProduct)
            .HasForeignKey(sp => sp.ProductId);
    }
}
public class AmbevContextFactory : IDesignTimeDbContextFactory<AmbevContext>
{
    public AmbevContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<AmbevContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        );

        return new AmbevContext(builder.Options);
    }
}