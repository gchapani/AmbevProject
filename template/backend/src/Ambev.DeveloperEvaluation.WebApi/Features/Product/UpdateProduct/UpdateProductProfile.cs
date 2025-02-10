using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<Guid, GetProductCommand>().ConstructUsing(id => new GetProductCommand(id));
        CreateMap<UpdateProductResponse, GetProductResult>().ReverseMap();
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
    }
}