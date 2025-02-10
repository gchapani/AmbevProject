using Ambev.DeveloperEvaluation.Application.Product.GetAllProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetAllProduct;

public class GetAllProductProfile : Profile
{
    public GetAllProductProfile()
    {
        CreateMap<GetAllProductRequest, GetAllProductCommand>().ReverseMap();
        CreateMap<GetAllProductResponse, GetAllProductResult>().ReverseMap();
    }
}