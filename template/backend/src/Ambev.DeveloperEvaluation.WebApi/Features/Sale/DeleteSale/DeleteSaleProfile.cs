using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

public class DeleteSaleProfile : Profile
{
    public DeleteSaleProfile()
    {
        CreateMap<Guid, Application.Sale.DeleteSale.DeleteSaleCommand>()
            .ConstructUsing(id => new Application.Sale.DeleteSale.DeleteSaleCommand(id));
    }
}