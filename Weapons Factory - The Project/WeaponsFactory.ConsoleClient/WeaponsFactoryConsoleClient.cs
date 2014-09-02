namespace WeaponsFactory.ConsoleClient
{
    using System;

    using WeaponsFactory.Data;
    using WeaponsFactory.Models;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var data = new WeaponsFactoryData();

            var vendor = new Vendor { Name = "NewVendorName", Address = "NewVendorAddress" };
            data.Vendors.Add(vendor);
            data.Vendors.SaveChanges();

            var manufacturer = new Manufacturer { Name = "TestManufacturer" };
            data.Manufacturers.Add(manufacturer);
            data.Manufacturers.SaveChanges();

            foreach (var v in data.Vendors.All())
            {
                Console.WriteLine(v.Name + " - " + v.Address);
            }

            foreach (var m in data.Manufacturers.All())
            {
                Console.WriteLine(m.Name);
            }
        }
    }
}
