using FurnitureShop.Core.Models;
using System.Collections.Generic;

namespace FurnitureShop.Core.Repositories
{
    public interface IClientRepository
    {
        public void Insert(Client client);
        public void Delete(Client client);
        public void Update(Client client);
        public IEnumerable<Client> GetAll();
    }
}
