using Ambev.DeveloperEvaluation.Domain.Interfaces;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

public class GetAllSaleResult
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; }
    public double SaleValueTotal { get; set; }
    public string Branch { get; set; }
    public ICollection<ISaleProduct> SaleProduct { get; set; } = new List<ISaleProduct>();
}