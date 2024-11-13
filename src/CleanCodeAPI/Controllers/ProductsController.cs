using CleanCode.Application.Features.Products.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
      _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request)
    {
      // Mediator isteğin doğru sınıfa yönelndirilmesini indirection yöntemi ile sağlar.
      await _mediator.Send(request);

      return Ok();
    }


    [HttpPut("increasePrice")]
    public async Task<IActionResult> IncreasePrice([FromBody] IncreaseProductPrice request)
    {

      await _mediator.Send(request);

      return Ok();
    }
  }
}
