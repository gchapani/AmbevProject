using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateProductRequest, GetProductCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        //CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>();
    }
}