using CleanCode.Application.Features.Products.Dtos;
using CleanCode.Domain.Aggregates;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Application.Features.Products.Handlers
{
  public class IncreaseProductPriceRequestHandler : IRequestHandler<IncreaseProductPrice>
  {
    // Not: Bir interface çalışma anında 2 farklı sınıfa göre işlem yapabilecek şekilde yazılırsa bu durumda IServiceScopeFactory üzerindeki Service Provider üzerinden erişim sağlarız.
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public IncreaseProductPriceRequestHandler(IServiceScopeFactory serviceScopeFactory)
    {
      _serviceScopeFactory = serviceScopeFactory;
    }

    public Task Handle(IncreaseProductPrice request, CancellationToken cancellationToken)
    {
      var productService = _serviceScopeFactory.CreateScope().ServiceProvider.GetKeyedService<IProductService>("default");

      ArgumentNullException.ThrowIfNull(productService);

      productService.IncreasePrice(request.ProductId, request.Rate);

      return Task.CompletedTask;
    }
  }
}
