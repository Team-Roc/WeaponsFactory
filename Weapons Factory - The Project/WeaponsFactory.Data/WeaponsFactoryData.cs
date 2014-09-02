﻿namespace WeaponsFactory.Data
{
    using System;
    using System.Collections.Generic;

    using WeaponsFactory.Data.Repositories;
    using WeaponsFactory.Models;

    public class WeaponsFactoryData : IWeaponsFactoryData
    {
        private IWeaponsFactoryDbContext context;
        private IDictionary<Type, object> repositories;

        public WeaponsFactoryData()
            : this(new WeaponsFactoryDbContext())
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public WeaponsFactoryData(IWeaponsFactoryDbContext weaponsFactoryDbContext)
        {
            this.context = weaponsFactoryDbContext;
        }

        public IGenericRepository<Vendor> Vendors
        {
            get
            {
                return this.GetRepository<Vendor>();
            }
        }

        public IGenericRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IGenericRepository<Weapon> Weapons
        {
            get
            {
                return this.GetRepository<Weapon>();
            }
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(IGenericRepository<T>);
                if (typeOfModel.IsAssignableFrom(typeof(T)))
                {
                    typeOfRepository = typeof(GenericRepository<T>);
                }

                var newRepository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(typeOfModel, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}