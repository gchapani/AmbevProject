namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ISaleProduct
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantities { get; set; }
        public double Discount { get; set; }
    }
}
