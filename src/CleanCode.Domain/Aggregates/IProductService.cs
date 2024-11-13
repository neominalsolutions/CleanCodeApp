using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  public interface IProductService
  {
    void Create(Product product);
    void IncreasePrice(Guid Id, float rate);
  }
}
