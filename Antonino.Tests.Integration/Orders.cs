using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using AntoninoDB = Antonino.Classes.MongoDB;
using Antonino.Classes;
using MongoDB.Bson;
using System.Linq;
using System;

// TODO make tests for exceptions

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
        [ExpectedException(typeof(ArgumentException), "A null id argument was inappropriately allowed.")]
        public void GetOrder_Should_Throw_Exception_When_id_Is_Null()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.GetOrder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A empty id argument was inappropriately allowed.")]
        public void GetOrder_Should_Throw_Exception_When_id_Is_Empty()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.GetOrder(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A whitespaced id argument was inappropriately allowed.")]
        public void GetOrder_Should_Throw_Exception_When_id_Is_Whitespaced()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.GetOrder("  ");
        }

        [TestMethod]
        public void UpdateOrder_Should_Return_True()
        {
            var db = new AntoninoDB();
            var order = db.GetOrder(testOrderId);
            order.Status = OrderStatus.InProgress;
            Assert.IsTrue(db.UpdateOrder(order.ID, order.Status));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A null id argument was inappropriately allowed.")]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Null()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();
            
            // act
            db.UpdateOrder(null, OrderStatus.Done);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A empty id argument was inappropriately allowed.")]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Empty()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.UpdateOrder(string.Empty, OrderStatus.Done);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A whitespaced id argument was inappropriately allowed.")]
        public void Update_Order_Should_Throw_Exception_When_id_Is_Whitespaced()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.UpdateOrder(" ", OrderStatus.Done);
        }
    }
}
