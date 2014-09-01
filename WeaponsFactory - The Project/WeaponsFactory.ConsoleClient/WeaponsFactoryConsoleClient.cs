namespace WeaponsFactory.ConsoleClient
{
    using WeaponsFactory.Data;
    using WeaponsFactory.Models;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var db = new WeaponsFactoryDbContext();

            var vendor = new Vendor()
             {
                 Name = "TestVendorName",
                 Address = "TestVendorAddress"
             };

            db.Vendors.Add(vendor);
            db.SaveChanges();
        }
    }
}
