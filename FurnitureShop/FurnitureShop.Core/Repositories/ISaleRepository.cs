using FurnitureShop.Core.Models;
using System.Collections.Generic;

namespace FurnitureShop.Core.Repositories
{
    public interface ISaleRepository
    {
        public void Insert(Sale sale);
        public void Delete(Sale sale);
        public void Update(Sale sale);
        public IEnumerable<Sale> GetAll();
    }
}
