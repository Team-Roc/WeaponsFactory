namespace WeaponsFactory.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using WeaponsFactory.Models;

    public sealed class Configuration : DbMigrationsConfiguration<WeaponsFactoryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "WeaponsFactory.Data.WeaponsFactoryDbContext";
        }

        protected override void Seed(WeaponsFactoryDbContext context)
        {
            this.SeedVendors(context);
        }

        private void SeedVendors(WeaponsFactoryDbContext context)
        {
            if (context.Vendors.Any())
            {
                return;
            }

            context.Vendors.Add(new Vendor()
            {
                Name = "SeedName",
                Address = "SeedAddress"
            });
        }
    }
}
