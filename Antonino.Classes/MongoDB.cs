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
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(new BsonDocument()).ToList();
        }

        public Order GetOrder(string id)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public User GetUser(string id)
        {
            IMongoCollection<User>userCollection = database.GetCollection<User>("users");
            return userCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public bool UpdateOrder(string id, OrderStatus status)
        {
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            var filter = Builders<Order>.Filter.Eq("_id", id);
            var update = Builders<Order>.Update.Set("status", status);
            try
            {
                orderCollection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
