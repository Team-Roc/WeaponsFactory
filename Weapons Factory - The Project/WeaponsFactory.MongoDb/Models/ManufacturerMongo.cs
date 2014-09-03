namespace WeaponsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class ManufacturerMongo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int ManufacturerId { get; set; }

        public string Name { get; set; }
    }
}
