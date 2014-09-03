namespace WeaponsFactory.Data
{
    using System.Data.Entity;

    using WeaponsFactory.Data.Migrations;
    using WeaponsFactory.Models.SqlModels;

    public class WeaponsFactoryDbContext : DbContext, IWeaponsFactoryDbContext
    {
        public WeaponsFactoryDbContext()
            : base("WeaponsFactory")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WeaponsFactoryDbContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Weapon> Weapons { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
