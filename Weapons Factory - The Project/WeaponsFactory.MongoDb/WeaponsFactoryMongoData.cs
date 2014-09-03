namespace WeaponsFactory.MongoDb
{
    using System;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    using WeaponsFactory.Data;
    using WeaponsFactory.Models;
    using WeaponsFactory.MongoDb.Models;

    public class WeaponsFactoryMongoData
    {
        private WeaponsFactoryData data;

        public WeaponsFactoryMongoData(WeaponsFactoryData sqlData)
        {
            this.data = sqlData;
        }

        public void Get()
        {
            var mongoClient = new MongoClient("mongodb://127.0.0.1");
            var server = mongoClient.GetServer();
            MongoDatabase mongoDb = server.GetDatabase("WeaponsFactory");

            //vendors.Insert(new ManufacturerMongo()
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    ManufacturerId = 1,
            //    Name = "Benelli"
            //});

            var vendors = mongoDb.GetCollection<VendorMongo>("Vendors");
            var manufacturers = mongoDb.GetCollection<ManufacturerMongo>("Manufacturers");
            var weapons = mongoDb.GetCollection<WeaponMongo>("Weapons");
            var categories = mongoDb.GetCollection<CategoryMongo>("Categories");

            foreach (var vendor in vendors.FindAll())
            {
                var entryExists = this.data.Vendors.All().Any(a => a.VendorId == vendor.VendorId);
                if (!entryExists)
                {
                    var newVendor = new Vendor { Name = vendor.Name, Address = vendor.Address };
                    this.data.Vendors.Add(newVendor);
                    this.data.Vendors.SaveChanges();
                }
            }

            foreach (var manufacturer in manufacturers.FindAll())
            {
                Console.WriteLine(manufacturer.ManufacturerId + " " + manufacturer.Name);
            }

            foreach (var weapon in weapons.FindAll())
            {
                Console.WriteLine(weapon.WeaponId + " " + weapon.Name + " " + weapon.Description + " " + weapon.CategoryId + " " + weapon.ManufacturerId);
            }

            foreach (var category in categories.FindAll())
            {
                Console.WriteLine(category.CategoryId + " " + category.Name);
            }
        }
    }
}
