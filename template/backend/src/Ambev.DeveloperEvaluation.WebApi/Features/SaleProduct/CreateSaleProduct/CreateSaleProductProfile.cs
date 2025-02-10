using Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;

public class CreateSaleProductProfile : Profile
{
    public CreateSaleProductProfile()
    {
        CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>();
        CreateMap<CreateSaleProductResult, CreateSaleProductResponse>();
    }
}