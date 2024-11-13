using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  public interface IReadOnlyRepo<T> where T:class
  {
    T FindById(Guid Id);
    IQueryable<T> Find(Expression<Func<T, bool>> expression);
  }

  public interface IWriteOnlyRepo<T> where T:class
  {
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid Id);
  }

  // Kendimize diğer katmalanların referans alacağı domain katmanınında diğer katmanalara bağımlı olmayacağı bir port açıyoruz.
  public interface IProductRepository: IReadOnlyRepo<Product>, IWriteOnlyRepo<Product>
  {
  }
}
