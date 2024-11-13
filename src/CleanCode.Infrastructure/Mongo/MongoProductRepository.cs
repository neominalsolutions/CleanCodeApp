using CleanCode.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.Mongo
{
    public class MongoProductRepository : IProductRepository
    {

        public void Add(Product entity)
        {
            Console.Out.WriteLine("MongoDb Kayıt atıldı");
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
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            Console.Out.WriteLine("MongoDb Kayıt atıldı");
        }
    }
}
