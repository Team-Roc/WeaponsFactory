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

        }
    }
}
