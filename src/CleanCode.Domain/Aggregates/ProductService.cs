using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  public class ProductService
  {
    // Dependecy Inversion
    private IProductRepository _productRepository; // EFProductRepo
    private IUnitOfWork _unitOfWork;
    // Depency Injection.
    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
      _productRepository = productRepository;
      _unitOfWork = unitOfWork;
    }

    public void Save(Product product)
    {
      _productRepository.Add(product);
      // _productRepository.Update(product);
      _unitOfWork.Commit();
    }

  }
}
