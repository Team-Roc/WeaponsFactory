namespace WeaponsFactory.ConsoleClient
{
    using WeaponsFactory.Data;
    using WeaponsFactory.Models;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var db = new WeaponsFactoryDbContext();
            db.Database.Initialize(true);

            var vendor = new Vendor()
            {
                Name = "TestVendorName",
                Address = "TestVendorAddress"
            };

            db.Vendors.Add(vendor);
            db.SaveChanges();

            foreach (var v in db.Vendors)
            {
                System.Console.WriteLine(v.Name + " - " + v.Address);
            }
        }
    }
}
