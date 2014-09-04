namespace WeaponsFactory.XMLOperations
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using WeaponsFactory.Data;
    using WeaponsFactory.Models.MongoModels;
    using WeaponsFactory.Models.SqlModels;

    public static class XMLParser
    {
        private static Random random = new Random();
        private static HashSet<MongoWeapon> mongoWeapons = new HashSet<MongoWeapon>();

        public static void ImportCategoriesXMLToSqlAndMongoDb(IWeaponsFactoryData sqlDb, WeaponsFactoryMongoData mongoDb, string fullFilePath)
        {
            var categoriesToImport = GetCategoriesFromFile(fullFilePath);

            foreach (var category in categoriesToImport)
            {
                sqlDb.Weapons.AddRange(category.Weapons);
                sqlDb.Weapons.SaveChanges();
            }

            foreach (var weapon in mongoWeapons)
            {
                mongoDb.InsertEntity(weapon, "Weapons");
            }
        }

        private static IEnumerable<Category> GetCategoriesFromFile(string fullFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fullFilePath);

            var xmlQueryString = "/categories/category";
            var nodesList = xmlDoc.SelectNodes(xmlQueryString);

            var categories = new HashSet<Category>();

            foreach (XmlNode node in nodesList)
            {
                var categoryName = node.Attributes["name"].Value;

                var newCategory = new Category()
                {
                    Name = categoryName
                };

                var weaponsList = node.SelectNodes("weapon");

                foreach (XmlNode weaponNode in weaponsList)
                {
                    var name = weaponNode.Attributes["name"].Value;
                    var description = weaponNode.Attributes["description"].Value;
                    var manufacturerId = weaponNode.Attributes["manufacturerId"].Value;
                    var categoryId = weaponNode.Attributes["categoryId"].Value;

                    var newWeapon = new Weapon()
                    {
                        Name = name,
                        Description = description,
                        ManufacturerId = int.Parse(manufacturerId),
                        CategoryId = int.Parse(categoryId)
                    };

                    var newMongoWeapon = new MongoWeapon()
                    {
                        WeaponId = random.Next(11, 100),
                        Name = name,
                        Description = description,
                        ManufacturerId = int.Parse(manufacturerId),
                        CategoryId = int.Parse(categoryId),
                    };

                    newCategory.Weapons.Add(newWeapon);
                    mongoWeapons.Add(newMongoWeapon);
                }

                categories.Add(newCategory);
            }

            return categories;
        }
    }
}
