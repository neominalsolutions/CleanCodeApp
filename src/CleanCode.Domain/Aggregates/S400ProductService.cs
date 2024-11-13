using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  public class S400ProductService : IProductService
  {
    public void Create(Product product)
    {
      Console.Out.WriteLine("S400 Kayıt atıldı");
    }

    public void IncreasePrice(Guid Id, float rate)
    {
      Console.Out.WriteLine("S400 Fiyat güncellendi");
    }
  }
}
