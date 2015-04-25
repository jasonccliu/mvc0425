using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ClientRepository : EFRepository<Client>, IClientRepository
    {
        public override IQueryable<Client> All()
        {
            return base.All().Where(p => p.IsDelete);
        }

        public Client Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ClientId == id);
        }

        public override void Delete(Client client)
        {
            client.IsDelete = false;
        }

        public IQueryable<Product> QueryProduct()
        {
            //var db = new FabricsEntities();
            var db = (FabricsEntities)this.UnitOfWork.Context;
            return db.QueryProduct().AsQueryable();
        }
    }

    public interface IClientRepository : IRepository<Client>
    {

    }
}