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
  // Single Responsibity => Bu sınıfın tek sorumluluğu Product nesnesini s400 ve dbye kaydetmek.
  public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest>
  {
    private readonly IServiceProvider _serviceProvider;

    public CreateProductRequestHandler(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    public Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
      var product = Product.Create(request.Name, request.Price, request.Stock);

      var defaultProductService = _serviceProvider.GetKeyedService<IProductService>("default");

      ArgumentNullException.ThrowIfNull(defaultProductService);
      defaultProductService.Create(product);

      var s400Service = _serviceProvider.GetKeyedService<IProductService>("s400");

      ArgumentNullException.ThrowIfNull(s400Service);
      s400Service.Create(product);

      return Task.CompletedTask;
    }
  }
}
