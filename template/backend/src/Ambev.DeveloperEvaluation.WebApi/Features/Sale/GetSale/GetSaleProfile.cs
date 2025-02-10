using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Guid, GetSaleCommand>().ConstructUsing(id => new GetSaleCommand(id));
        CreateMap<GetSaleResponse, GetSaleResult>().ReverseMap();
    }
}