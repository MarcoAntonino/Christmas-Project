using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Antonino.Classes
{
    public class MongoDB : IDataBase
    {
        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(string id, OrderStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
