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
    using System.Collections;
    using System.Collections.Generic;

    public class WeaponsFactoryMongoData
    {
        private MongoClient mongoClient;
        private MongoServer server;
        private MongoDatabase mongoDb;
        private WeaponsFactoryData sqlData;

        public WeaponsFactoryMongoData(WeaponsFactoryData sqlData)
        {
            this.mongoClient = new MongoClient("mongodb://127.0.0.1");
            this.server = mongoClient.GetServer();
            this.mongoDb = server.GetDatabase("WeaponsFactory");
            this.sqlData = sqlData;
        }

        public void TransferDataToSqlDb()
        {
            var vendors = this.GetVendors();
            this.sqlData.Vendors.AddRange(vendors);
            this.sqlData.Vendors.SaveChanges();

            var manufacturers = this.GetManufacturers();
            this.sqlData.Manufacturers.AddRange(manufacturers);
            this.sqlData.Manufacturers.SaveChanges();

            var categories = this.GetCategories();
            this.sqlData.Categories.AddRange(categories);
            this.sqlData.Categories.SaveChanges();

            var weapons = this.GetWeapons();
            this.sqlData.Weapons.AddRange(weapons);
            this.sqlData.Weapons.SaveChanges();
        }

        private IEnumerable<Vendor> GetVendors()
        {
            var mongoVendors = this.mongoDb.GetCollection<MongoVendor>("Vendors");
            var vendors = new List<Vendor>();

            foreach (var mongoVendor in mongoVendors.FindAll())
            {
                var entryExists = this.sqlData.Vendors.All().Any(a => a.Name == mongoVendor.Name);
                if (!entryExists)
                {
                    var newSqlVendor = new Vendor
                    {
                        Name = mongoVendor.Name,
                        Address = mongoVendor.Address
                    };

                    vendors.Add(newSqlVendor);
                }
            }

            return vendors;
        }

        private IEnumerable<Manufacturer> GetManufacturers()
        {
            var mongoManufacturers = this.mongoDb.GetCollection<MongoManufacturer>("Manufacturers");
            var manufacturers = new List<Manufacturer>();

            foreach (var mongoManufacturer in mongoManufacturers.FindAll())
            {
                var entryExists = this.sqlData.Manufacturers.All().Any(a => a.Name == mongoManufacturer.Name);
                if (!entryExists)
                {
                    var newSqlManufacturer = new Manufacturer
                    {
                        Name = mongoManufacturer.Name
                    };

                    manufacturers.Add(newSqlManufacturer);
                }
            }

            return manufacturers;
        }

        private IEnumerable<Category> GetCategories()
        {
            var mongoCategories = this.mongoDb.GetCollection<MongoCategory>("Categories");
            var categories = new List<Category>();
            foreach (var mongoCategory in mongoCategories.FindAll())
            {
                var entryExists = this.sqlData.Categories.All().Any(a => a.Name == mongoCategory.Name);
                if (!entryExists)
                {
                    var newSqlCategory = new Category
                    {
                        Name = mongoCategory.Name
                    };

                    categories.Add(newSqlCategory);
                }
            }

            return categories;
        }

        private IEnumerable<Weapon> GetWeapons()
        {
            var mongoWeapons = this.mongoDb.GetCollection<MongoWeapon>("Weapons");
            var weapons = new List<Weapon>();

            foreach (var mongoWeapon in mongoWeapons.FindAll())
            {
                var entryExists = this.sqlData.Weapons.All().Any(a => a.Name == mongoWeapon.Name);
                if (!entryExists)
                {
                    var newSqlWeapon = new Weapon
                    {
                        Name = mongoWeapon.Name,
                        Description = mongoWeapon.Description,
                        CategoryId = mongoWeapon.CategoryId,
                        ManufacturerId = mongoWeapon.ManufacturerId
                    };

                    weapons.Add(newSqlWeapon);
                }
            }

            return weapons;
        }

        private void InsertEntity<T>(T entity, string collectionName)
        {
            var mongoEntities = this.mongoDb.GetCollection<T>(collectionName);
            mongoEntities.Insert(entity);
        }
    }
}
