namespace WeaponsFactory.Data
{
    using WeaponsFactory.Data.Repositories;
    using WeaponsFactory.Models.SqlModels;

    public interface IWeaponsFactoryData
    {
        IGenericRepository<Vendor> Vendors { get; }

        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<Weapon> Weapons { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Sale> Sales { get; }
    }
}
