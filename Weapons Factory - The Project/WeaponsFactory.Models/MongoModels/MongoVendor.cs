namespace WeaponsFactory.Models.MongoModels
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MongoVendor
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public int VendorId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
