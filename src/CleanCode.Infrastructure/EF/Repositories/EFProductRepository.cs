using CleanCode.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.EF.Repositories
{
  // Adapter, IProductRepository EF Adaptörü.
  public class EFProductRepository : IProductRepository
  {
    public void Add(Product entity)
    {
      // dbContext.Products.Add(entity);
      Console.Out.WriteLine("Product Added State");
    }

    public void Delete(Guid Id)
    {
      throw new NotImplementedException();
    }

    public IQueryable<Product> Find(Expression<Func<Product, bool>> expression)
    {
      throw new NotImplementedException();
    }

    public Product FindById(Guid Id)
    {
      // dbContext.Product.Find(Id);
      return Product.Create("P-1", 15, 15);
    }

    public void Update(Product entity)
    {
      Console.Out.WriteLine("Product Modified State");
    }
  }
}
