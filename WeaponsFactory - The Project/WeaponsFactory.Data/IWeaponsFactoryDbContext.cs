namespace WeaponsFactory.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using WeaponsFactory.Models;

    public interface IWeaponsFactoryDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Sale> Sales { get; set; }

        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<Weapon> Weapons { get; set; }

        int SaveChanges();
    }
}
