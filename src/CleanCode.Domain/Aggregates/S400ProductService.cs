using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  // Open Close Solid Prensipleri Örneği
  // ProductService kayıt atarken S400 kaydıt işlemini Product Service içerisinde yönetmek ve Product Servisi güncellemek, değiştirmek yerine yeni bir S400ProductService açarak sürecin buradan devam etmesini sağladık. Uygulamanın Kayıt sürecini geliştirdik, ama ana kodu değiştirmedik.
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
