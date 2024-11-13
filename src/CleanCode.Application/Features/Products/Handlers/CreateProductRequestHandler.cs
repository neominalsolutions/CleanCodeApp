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
   
    private readonly IProductService _productService;
    private readonly IProductService _s400Service;
    public CreateProductRequestHandler(
      [FromKeyedServices("default")] IProductService productService, 
      [FromKeyedServices("s400")] IProductService s400Service)
    {
      _productService = productService;
      _s400Service = s400Service;

    }

    public Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
      var product = Product.Create(request.Name, request.Price, request.Stock);

    

      ArgumentNullException.ThrowIfNull(_productService);
      _productService.Create(product);



      ArgumentNullException.ThrowIfNull(_s400Service);
      _s400Service.Create(product);

      return Task.CompletedTask;
    }
  }
}
