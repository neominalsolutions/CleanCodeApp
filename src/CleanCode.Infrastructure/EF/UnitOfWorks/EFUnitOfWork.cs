using CleanCode.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.EF.UnitOfWorks
{
  // IUnitOfWork Port için EFUnitOfWork EF Adaptörü
  // Hexagonal Architecture Port and Adapter Architecture
  public class EFUnitOfWork : IUnitOfWork
  {
    public void Commit()
    {
      Console.Out.WriteLine("Save Changes");
    }
  }
}
