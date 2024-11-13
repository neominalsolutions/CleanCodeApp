using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  // event olarak bir sınıfın kullanılabilmesini sağladık.
  public record ProductPriceChanged(string ProductName,decimal Price):INotification;
 
}
