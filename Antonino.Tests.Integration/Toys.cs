using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using AntoninoDB = Antonino.Classes.MongoDB;
using Antonino.Classes;
using System.Linq;
using System;
// TODO make tests for exceptions

namespace Antonino.Tests.Integration
{
    [TestClass]
    public class Toys
    {
        private IMongoDatabase db;
        private const string TOY_NAME = "test-toy";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
            collection.InsertOne(new Toy
            {
                Name = TOY_NAME
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("toys");
            }
        }

        [TestMethod]
        public void GetAllToys_Should_Return_A_List()
        {
            var db = new AntoninoDB();
            var list = db.GetAllToys();
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void GetToy_Should_Return_TestToy()
        {
            var db = new AntoninoDB();
            var test = new Toy
            {
                Name = TOY_NAME
            };
            var toy = db.GetToy(test);

            Assert.IsNotNull(toy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A empty toy argument was inappropriately allowed.")]
        public void GetToy_ShouldThrow_Exception_When_Toy_Is_Null()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.GetToy(null);
        }
    }
}
