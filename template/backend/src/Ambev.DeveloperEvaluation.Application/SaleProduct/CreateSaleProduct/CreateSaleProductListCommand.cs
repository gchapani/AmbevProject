using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct
{
    public class CreateSaleProductListCommand : IRequest<List<CreateSaleProductResult>>
    {
        public List<CreateSaleProductCommand> SaleProductCommands { get; set; }

        public CreateSaleProductListCommand(List<CreateSaleProductCommand> saleProductCommands)
        {
            SaleProductCommands = saleProductCommands;
        }
    }
}