using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using AntoninoDB = Antonino.Classes.MongoDB;
using Antonino.Classes;
using System;

namespace Antonino.Tests.Integration
{

    // TODO make tests for exceptions

    [TestClass]
    public class Users
    {
        private IMongoDatabase db;
        private const string SCREEN_NAME = "test-user";
        private const string USER_PASSWORD = "test-user";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            collection.InsertOne(new User
            {
                ScreenName = SCREEN_NAME,
                Password = USER_PASSWORD
            });
        }
        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("users");
            }
        }

        [TestMethod]
        public void GetUser_Should_Return_TestUser()
        {
            var db = new AntoninoDB();
            var test = new User
            {
                ScreenName = SCREEN_NAME,
                Password = USER_PASSWORD
            };
            var user = db.GetUser(test);
            
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A empty user argument was inappropriately allowed.")]
        public void GetUser_ShouldThrow_Exception_When_User_Is_Null()
        {
            // arrange
            AntoninoDB db = new AntoninoDB();

            // act
            db.GetUser(null);
        }

    }
}
