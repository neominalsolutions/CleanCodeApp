using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
  public interface IUnitOfWork
  {
    void Commit(); // veri tabanına kaydı yansıt. EF savechanges gibi
  }
}
