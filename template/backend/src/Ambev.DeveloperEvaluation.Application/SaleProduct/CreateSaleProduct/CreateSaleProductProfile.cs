using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;

public class CreateSaleProductProfile : Profile
{
    public CreateSaleProductProfile()
    {
        CreateMap<CreateSaleProductCommand, Domain.Entities.SaleProduct>();
        CreateMap<Domain.Entities.SaleProduct, CreateSaleProductResult>();
    }
}