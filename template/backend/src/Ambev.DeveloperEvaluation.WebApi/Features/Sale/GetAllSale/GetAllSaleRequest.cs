namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetAllSale;

public class GetAllSaleRequest
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string? ClientName { get; set; }
    public double SaleValueTotal { get; set; }
    public string? Branch { get; set; }
}