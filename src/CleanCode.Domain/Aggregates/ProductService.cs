using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  // ProductService ile Cohesion sağladık. (Product,ProductRepo,UnitOfWork)
  public class ProductService:IProductService
  {
    // Dependecy Inversion
    private IProductRepository _productRepository; // EFProductRepo
    private IUnitOfWork _unitOfWork;
    private IMediator _mediator;
    // Depency Injection.
    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMediator mediator)
    {
      _productRepository = productRepository;
      _unitOfWork = unitOfWork;
      _mediator = mediator;
    }

    public void Create(Product product)
    {
      _productRepository.Add(product);
      // _productRepository.Update(product);
      _unitOfWork.Commit();
    }

    /// <summary>
    /// Belirli oradan fiyata zam yapmamızı sağlar.
    /// İlgili fiyata zam yapıldığında zam yapılan ürün için event fırlatıp bu eventi dinleyen servis, ürün favorilerine ekleyen kullanıcıları bulup bildirim atsın.
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="rate"></param>
    public void IncreasePrice(Guid Id,float rate)
    {
      var product = _productRepository.FindById(Id);
      ArgumentNullException.ThrowIfNull(product);

      decimal newPrice = product.Price * (decimal)(1 + rate);
      product.SetPrice(newPrice);

      _productRepository.Update(product);
      _unitOfWork.Commit();

      // event fırlat.

      _mediator.Publish(new ProductPriceChanged(product.Name, newPrice));
    }

  }
}
