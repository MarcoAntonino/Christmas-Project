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

        public IEnumerable<Product> GetAllProducts()
        {
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("product");
            return productCollection.Find(new BsonDocument()).ToList();
        }

        public Product GetProduct(string id)
        {
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("product");
            return productCollection.Find(_ => _.ID == id).FirstOrDefault();
        }

        public bool InsertProduct(Product product)
        {
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("product");
            try
            {
                productCollection.InsertOne(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveProduct(string id)
        {
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("product");
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
            try
            {
                productCollection.DeleteOne(filter);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("product");
            var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(product.ID));
            var update = Builders<Product>.Update
                .Set("name", product.Name)
                .Set("category", product.Category);
            try
            {
                productCollection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
