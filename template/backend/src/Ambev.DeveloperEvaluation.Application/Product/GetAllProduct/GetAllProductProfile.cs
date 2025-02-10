using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProduct;

public class GetAllProductProfile : Profile
{
    public GetAllProductProfile()
    {
        CreateMap<Domain.Entities.Product, GetAllProductResult>();
        CreateMap<GetAllProductCommand, Domain.Entities.Product>();
    }
}