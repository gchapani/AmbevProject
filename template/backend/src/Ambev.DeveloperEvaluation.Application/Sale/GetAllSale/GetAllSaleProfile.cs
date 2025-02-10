using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

public class GetAllSaleProfile : Profile
{
    public GetAllSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetAllSaleResult>();
        CreateMap<GetAllSaleCommand, Domain.Entities.Sale>();
    }
}