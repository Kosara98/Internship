using FurnitureShop.Core.Models;
using System.Collections.Generic;

namespace FurnitureShop.Core.Repositories
{
    public interface IProductRepository
    {
        public void Insert(Product product);
        public void Delete(Product product);
        public void Update(Product product);
        public IEnumerable<Product> GetAll();
    }
}
