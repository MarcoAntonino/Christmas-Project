using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Antonino.Classes
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("kid")]
        public string Kid { get; set; }

        [BsonElement("status")]
        public OrderStatus Status { get; set; }

        [BsonElement("toys")]
        public List<Toy> Toys { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement("requestDate")]
        public DateTime RequestDate { get; set; }
    }
}
