using Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetAllSale;

public class GetAllSaleProfile : Profile
{
    public GetAllSaleProfile()
    {
        CreateMap<GetAllSaleRequest, GetAllSaleCommand>().ReverseMap();
        CreateMap<GetAllSaleResponse, GetAllSaleResult>().ReverseMap();
    }
}