using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return orderCollection.Find(new BsonDocument()).SortBy(o => o.RequestDate).ToList();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(new BsonDocument()).SortBy(t => t.Amount).ToList();
        }

        public Order GetOrder(string id)
        {
            IdChecker(id);
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            return orderCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public User GetUser(User user)
        {
            GetParamChecker(user);
            IMongoCollection<User> userCollection = database.GetCollection<User>("users");
            return userCollection.Find(_ => _.Email == user.Email && _.Password == user.Password).FirstOrDefault();
        }
               
        public Toy GetToy(Toy toy)
        {
            GetParamChecker(toy);
            IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toys");
            return toyCollection.Find(_ => _.Name == toy.Name).FirstOrDefault();
        }

        public bool UpdateOrder(string id, OrderStatus status)
        {
            IdChecker(id);
            OrderStatusChecker(status);
            IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
            var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Order>.Update.Set("status", (int)status);
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

        public void IdChecker(string idParam)
        {
            if (string.IsNullOrEmpty(idParam) || string.IsNullOrWhiteSpace(idParam))
                throw new ArgumentException("The ID's value is not valid");            
        }

        public void OrderStatusChecker(OrderStatus statusParam)
        {
            if (statusParam < 0 || statusParam > Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().Last())
                throw new ArgumentOutOfRangeException("The status of your order is not valid");
        }

        public void GetParamChecker(object objectParam)
        {
            if (objectParam == null)
                throw new ArgumentNullException();            
        }
    }
}
