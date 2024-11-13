using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  // Db Trigger Program tarafındaki kullanımı
  public class ProductPriceChangeHandler : INotificationHandler<ProductPriceChanged>
  {
    public Task Handle(ProductPriceChanged notification, CancellationToken cancellationToken)
    {
     return Console.Out.WriteLineAsync($"{notification.ProductName} ürünü için güncel fiyat {notification.Price}");
    }
  }
}
