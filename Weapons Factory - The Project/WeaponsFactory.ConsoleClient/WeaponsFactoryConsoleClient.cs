﻿namespace WeaponsFactory.ConsoleClient
{
    using System;
    using System.Linq;

    using ExcelOperationsModule;
    using WeaponsFactory.Data;
    using WeaponsFactory.Models;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var data = new WeaponsFactoryData();

            //var vendor = new Vendor { Name = "NewVendorName", Address = "NewVendorAddress" };
            //data.Vendors.Add(vendor);
            //data.Vendors.SaveChanges();

            //var manufacturer = new Manufacturer { Name = "TestManufacturer" };
            //data.Manufacturers.Add(manufacturer);
            //data.Manufacturers.SaveChanges();

            // this is how you delete (facepalm)
            //data.Vendors.Delete(data.Vendors.All().Where(v => v.Name == "NewVendorName").FirstOrDefault());
            //data.Vendors.SaveChanges();
            
            //foreach (var v in data.Weapons.All())
            //{
            //    Console.WriteLine(v.Name + " - " + v.WeaponId);
            //}

            //data.GenerateJsonReports();

            //var sales = ZipExtractor.ReadZippedReports(@".\my tables.zip");

            //foreach (var sale in sales)
            //{
            //    Console.WriteLine("date: {0}, Quantity: {1}, SaleId {2}, UnitePrice: {3}, Vendor: {4}, VendorID: {5}, Weapon: {6}, WeaponID {7}", sale.Date, sale.Quantity, sale.SaleId, sale.UnitPrice, sale.Vendor, sale.VendorId, sale.Weapon, sale.WeaponId);
            //}
        }
    }
}
