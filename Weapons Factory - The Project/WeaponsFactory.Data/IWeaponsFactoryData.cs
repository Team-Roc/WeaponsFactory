namespace WeaponsFactory.Data
{
    using WeaponsFactory.Data.Repositories;
    using WeaponsFactory.Models;

    public interface IWeaponsFactoryData
    {
        IGenericRepository<Vendor> Vendors { get; }

        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<Weapon> Weapons { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Sale> Sales { get; }
    }
}
