namespace WeaponsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class VendorMongo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }                //check string

        public int VendorId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
