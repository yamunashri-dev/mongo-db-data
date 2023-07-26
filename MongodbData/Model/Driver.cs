using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace MongodbData.Model
{
    public class Driver
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string ObjectId { get; set; }

        public string? Name { get; set; }

        public string Id { get; set; }

        public string Salary { get; set; }

    }
}
