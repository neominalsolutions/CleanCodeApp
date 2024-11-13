using CleanCode.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.Mongo
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            Console.Out.WriteLine("Mongo Db Kayıt yansıtıldı");
        }
    }
}
