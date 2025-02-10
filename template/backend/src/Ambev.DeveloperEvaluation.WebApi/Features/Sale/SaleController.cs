using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetAllSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale;

[ApiController]
[Route("api/[controller]")]
public class SaleController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SaleController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        //Business Rules
        double total = 0;

        //Create List of Products
        foreach (CreateSaleProductRequest x in request.SaleProductList!)
        {
            var commandProduct = _mapper.Map<GetProductCommand>(x.ProductId);
            var responseProduct = await _mediator.Send(commandProduct, cancellationToken);
            GetProductResponse _product = _mapper.Map<GetProductResponse>(responseProduct);

            if (x.Quantities >= 4 && x.Quantities < 10)
            {
                x.Discount = 0.1;
            }
            else if (x.Quantities >= 10 && x.Quantities <= 20)
            {
                x.Discount = 0.2;
            }
            else
            {
                x.Discount = 0;
            }

            total += (_product.Price * x.Quantities) - ((_product.Price * x.Quantities) * x.Discount);
        }

        request.SaleValueTotal = total;
        request.SaleDate = DateTime.UtcNow;
        //Business Rules

        //Create Sale
        var commandSale = _mapper.Map<CreateSaleCommand>(request);
        var responseSale = await _mediator.Send(commandSale, cancellationToken);
        CreateSaleResponse _sale = _mapper.Map<CreateSaleResponse>(responseSale);

        foreach (CreateSaleProductRequest x in request.SaleProductList!) { x.SaleId = _sale.Id; }

        var commandSaleProduct = new CreateSaleProductListCommand(_mapper.Map<List<CreateSaleProductCommand>>(request.SaleProductList));
        var responseSaleProduct = await _mediator.Send(commandSaleProduct, cancellationToken);
        List<CreateSaleProductResponse> _saleProduct = _mapper.Map<List<CreateSaleProductResponse>>(responseSaleProduct);

        _sale.SaleProductList = _saleProduct;

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(_sale)
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllSale(CancellationToken cancellationToken)
    {
        var command = new GetAllSaleCommand();
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<List<GetAllSaleResponse>>
        {
            Success = true,
            Message = "Sale(s) retrieved successfully",
            Data = _mapper.Map<List<GetAllSaleResponse>>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        var validator = new GetSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleRequest { Id = id };
        var validator = new DeleteSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        });
    }
}
