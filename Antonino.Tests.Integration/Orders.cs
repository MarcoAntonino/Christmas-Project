using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using AntoninoDB = Antonino.Classes.MongoDB;
using Antonino.Classes;
using MongoDB.Bson;
using System.Linq;

namespace Antonino.Tests.Integration
{
    [TestClass]
    public class Orders
    {
        private IMongoDatabase db;
        private string testOrderId = ObjectId.GenerateNewId().ToString(); //ObjectId cannot be assigned to a const 

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Order> collection = db.GetCollection<Order>("orders");
            collection.InsertOne(new Order
            {
                ID = testOrderId
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("orders");
            }
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_A_List()
        {
            var db = new AntoninoDB();
            var list = db.GetAllOrders();
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void GetOrder_Should_Return_TestOrder()
        {
            var db = new AntoninoDB();
            var order = db.GetOrder(testOrderId);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void UpdateOrder_Should_Return_True()
        {
            var db = new AntoninoDB();
            var order = db.GetOrder(testOrderId);
            order.Status = OrderStatus.InProgress;
            Assert.IsTrue(db.UpdateOrder(order.ID, order.Status));
        }
    }
}
