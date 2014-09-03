namespace WeaponsFactory.Models.MongoModels
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MongoCategory
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
