using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Domain.Aggregates
{
    public class Product
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public DateTime CreatedAt { get; init; }

        public DateTime? UpdatedAt { get; private set; }

        private Product(string name, decimal price, int stock)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Today;
            SetName(name);
            SetPrice(price);
            SetStock(stock);
        }

        public static Product Create(string name, decimal price, int stock)
        {
            return new(name, price, stock);
        }

        public void SetName(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            Name = name.Trim();
            UpdatedAt = DateTime.Today;
        }

        public void SetPrice(decimal price)
        {
            Price = price < 0 ? 0 : price;
            UpdatedAt = DateTime.Today;
        }

        public void SetStock(int stock)
        {
            if (stock < 10)
            {
                throw new Exception("Stok en az 10 adet girilmelidir");
            }

            Stock = stock;
            UpdatedAt = DateTime.Today;
        }

    }
}
