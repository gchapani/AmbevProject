namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface IProduct
    {
        public string Id { get; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}