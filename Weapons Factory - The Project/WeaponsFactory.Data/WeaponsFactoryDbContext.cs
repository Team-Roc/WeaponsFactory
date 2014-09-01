namespace WeaponsFactory.Data
{
    using System.Data.Entity;

    using WeaponsFactory.Models;

    public class WeaponsFactoryDbContext : DbContext, IWeaponsFactoryDbContext
    {
        public WeaponsFactoryDbContext()
            : base("WeaponsFactory")
        {

        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Weapon> Weapons { get; set; }
    }
}
