namespace WeaponsFactory.ConsoleClient
{
    using System;
    using WeaponsFactory.Data;
    using WeaponsFactory.Models;

    public class WeaponsFactoryConsoleClient
    {
        public static void Main()
        {
            var db = new WeaponsFactoryDbContext();
            db.Database.Initialize(true);

            foreach (var v in db.Vendors)
            {
                Console.WriteLine(v.Name + " - " + v.Address);
            }
        }
    }
}
