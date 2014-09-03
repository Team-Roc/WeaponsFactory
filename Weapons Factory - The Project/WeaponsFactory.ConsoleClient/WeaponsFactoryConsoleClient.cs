namespace WeaponsFactory.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Configuration;

    using ExcelOperationsModule;
    using WeaponsFactory.Data;
    using WeaponsFactory.Models;
    using WeaponsFactory.DataAccess;
    using WeaponsFactory.MongoDb;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            //SQL
            var data = new WeaponsFactoryData();
            {
                //var vendor = new Vendor { Name = "NewVendorName", Address = "NewVendorAddress" };
                //data.Vendors.Add(vendor);
                //data.Vendors.SaveChanges();

                //var manufacturer = new Manufacturer { Name = "TestManufacturer" };
                //data.Manufacturers.Add(manufacturer);
                //data.Manufacturers.SaveChanges();

                // this is how you delete (facepalm)
                //data.Vendors.Delete(data.Vendors.All().Where(v => v.Name == "NewVendorName").FirstOrDefault());
                //data.Vendors.SaveChanges();

                //foreach (var v in data.Vendors.All())
                //{
                //    Console.WriteLine(v.Name + " - " + v.Address);
                //}
            }

            //MONGO
            {
                var mongoData = new WeaponsFactoryMongoData(data);

                //mongoData.Get();
            }

            var dataAccess = new WeaponsFactoryModel();

            data.GenerateJsonReports();

            dataAccess.DeserializeWeapons();
            //foreach (var sale in sales)
            //{
            //    Console.WriteLine("date: {0}, Quantity: {1}, SaleId {2}, UnitePrice: {3}, Vendor: {4}, VendorID: {5}, Weapon: {6}, WeaponID {7}", sale.Date, sale.Quantity, sale.SaleId, sale.UnitPrice, sale.Vendor, sale.VendorId, sale.Weapon, sale.WeaponId);
            //}
        }
    }
}
