namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ISale
    {
        public string Id { get; }
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string ClientName { get; set; }
        public double SaleValueTotal { get; set; }
        public string Branch { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
