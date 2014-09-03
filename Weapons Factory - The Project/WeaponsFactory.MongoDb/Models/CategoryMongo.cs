namespace WeaponsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class CategoryMongo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
