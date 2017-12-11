using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Antonino.Classes
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }
    }
}
