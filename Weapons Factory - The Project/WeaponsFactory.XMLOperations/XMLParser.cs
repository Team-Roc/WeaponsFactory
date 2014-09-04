namespace WeaponsFactory.XMLOperations
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using WeaponsFactory.Models.SqlModels;

    public static class XMLParser
    {
        public static IEnumerable<Sale> GetSalesFromFile(string fullFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fullFilePath);

            var xmlQueryString = "/sales/sale";
            XmlNodeList nodesList = xmlDoc.SelectNodes(xmlQueryString);

            var sales = new HashSet<Sale>();

            foreach (XmlNode node in nodesList)
            {
                var date = node.SelectSingleNode("summary").Attributes["date"].Value;
                var quantity = node.SelectSingleNode("summary").Attributes["quantity"].Value;
                var unitPrice = node.SelectSingleNode("summary").Attributes["unit-price"].Value;
                var vendorId = node.Attributes["vendorId"].Value;
                var weaponId = node.SelectSingleNode("summary").Attributes["weaponId"].Value;

                Sale newSale = new Sale() 
                {
                    Date = DateTime.Parse(date),
                    Quantity = int.Parse(quantity),
                    UnitPrice = decimal.Parse(unitPrice),
                    VendorId = int.Parse(vendorId),
                    WeaponId = int.Parse(weaponId)
                };

                sales.Add(newSale);
            }

            return sales;
        }

        public static IEnumerable<Category> GetCategoryFromFile(string fullFilePath)
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

                foreach (var weaponNode in weaponsList)
                {
                    var name = node.Attributes["name"].Value;
                    var description = node.Attributes["description"].Value;
                    var manufacturerId = node.Attributes["manufacturerId-price"].Value;

                    Weapon newWeapon = new Weapon()
                    {
                        Name = name,
                        Description = description,
                        ManufacturerId = int.Parse(manufacturerId)
                    };

                    newCategory.Weapons.Add(newWeapon);
                }

                categories.Add(newCategory);
            }

            return categories;
        }
    }
}
