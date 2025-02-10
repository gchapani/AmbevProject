using Ambev.DeveloperEvaluation.Application.SaleProduct.CreateSaleProduct;
using Ambev.DeveloperEvaluation.Application.SaleProduct.DeleteSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.CreateSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct.DeleteSaleProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProduct;

[ApiController]
[Route("api/[controller]")]
public class SaleProductController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SaleProductController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleProduct([FromBody] CreateSaleProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleProductResponse>
        {
            Success = true,
            Message = "SaleProduct created successfully",
            Data = _mapper.Map<CreateSaleProductResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSaleProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleProductRequest { Id = id };
        var validator = new DeleteSaleProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleProductCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "SaleProduct deleted successfully"
        });
    }
}
