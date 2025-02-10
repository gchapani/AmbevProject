using Ambev.DeveloperEvaluation.Application.SaleProduct.DeleteSaleProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.DeleteSaleProduct;

public class DeleteSaleProductProfile : Profile
{
    public DeleteSaleProductProfile()
    {
        CreateMap<Guid, DeleteSaleProductCommand>()
            .ConstructUsing(id => new DeleteSaleProductCommand(id));
    }
}