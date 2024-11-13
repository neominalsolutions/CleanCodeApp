using CleanCode.Domain.Aggregates;
using CleanCode.Infrastructure.Mongo;
using MediatR;

namespace CleanCode.Domain.Test
{
  public class ProductServiceTest
  {
    private readonly IMediator mediator;

    [Fact]
    public void Create_Product_Test()
    {

      // Arrange
      var repo = new MongoProductRepository();
      var unitofWork = new MongoUnitOfWork();
      
      var product = new ProductService(repo, unitofWork, mediator);

      // Act

      product.Create(Product.Create("P-1", 10, 20));

      // Assert
      Assert.IsAssignableFrom<Product>(product);
     
    }
  }
}