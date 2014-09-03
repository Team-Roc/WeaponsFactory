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
            //this.SeedManufacturers(context);
            //this.SeedVendors(context);
            //this.SeedCategories(context);
            //this.SeedWeapons(context);
        }

        private void SeedManufacturers (WeaponsFactoryDbContext context)
        {
            if (context.Manufacturers.Local.Any())
            {
                return;
            }

            context.Manufacturers.Add(new Manufacturer
            {
                ManufacturerId = 1,
                Name = "Benelli"
            });

            context.Manufacturers.Add(new Manufacturer
            {
                ManufacturerId = 2,
                Name = "Cold Steel"
            });

            context.Manufacturers.Add(new Manufacturer
            {
                ManufacturerId = 3,
                Name = "Smith & Wesson"
            });

            context.Manufacturers.Add(new Manufacturer
            {
                ManufacturerId = 4,
                Name = "Musashi Swords"
            });
        }

        private void SeedVendors(WeaponsFactoryDbContext context)
        {
            if (context.Vendors.Any())
            {
                return;
            }

            context.Vendors.Add(new Vendor()
            {
                Name = "Hyatt Guns",
                Address = "3332 Wilkinson Blvd., Charlotte"
            });

            context.Vendors.Add(new Vendor()
                {
                    Name = "Samurai Store",
                    Address = "Tokyo, Yokohama, Himeji Japan"
                });

            context.Vendors.Add(new Vendor()
            {
                Name = "The Knight Shop International",
                Address = "Conwy, North Wales, UK"
            });

            context.Vendors.Add(new Vendor()
            {
                Name = "Weapons of War",
                Address = "weaponsofwar.org"
            });

            context.Vendors.Add(new Vendor()
            {
                Name = "Gun-BG",
                Address = "gun-bg.com"
            });
        }

        private void SeedCategories (WeaponsFactoryDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.Add(new Category()
                {
                    CategoryId = 1,
                    Name = "Two-handed sword"
                });

            context.Categories.Add(new Category()
            {
                CategoryId = 2,
                Name = "Katana"
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 3,
                Name = "Handgun"
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 4,
                Name = "Rifle"
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 5,
                Name = "Knife"
            });

            context.Categories.Add(new Category()
                {
                    CategoryId = 6,
                    Name = "Stun-gun"
                });
        }

        private void SeedWeapons (WeaponsFactoryDbContext context)
        {
            if (context.Weapons.Any())
            {
                return;
            }

            context.Weapons.Add(new Weapon()
                {
                    Name = "Summer Rain",
                    CategoryId = this.GetCategoryId("Katana", context),
                    ManufacturerId = this.GetManufacturerId("Cold Steel", context),
                    Description = "A finely crafted katana sword, fit for collections as well as actual usage."
                });

            context.Weapons.Add(new Weapon()
            {
                Name = "Smith & Wesson .500",
                CategoryId = this.GetCategoryId("Handgun", context),
                ManufacturerId = this.GetManufacturerId("Smith & Wesson", context),
                Description = "A gun with high penetrating power, used the most by Chuck Norris."
            });

            context.Weapons.Add(new Weapon()
            {
                Name = "M21",
                CategoryId = this.GetCategoryId("Rifle", context),
                ManufacturerId = this.GetManufacturerId("Benelli", context),
                Description = "A long-range rifle, used mainly by the military."
            });

            context.Weapons.Add(new Weapon()
            {
                Name = "Akechi",
                CategoryId = this.GetCategoryId("Katana", context),
                ManufacturerId = this.GetManufacturerId("Musashi Swords", context),
                Description = "A katana made as per Japanese traditions, fully functional."
            });

            context.Weapons.Add(new Weapon()
            {
                Name = "Talwar",
                CategoryId = this.GetCategoryId("Knife", context),
                ManufacturerId = this.GetManufacturerId("Cold Steel", context),
                Description = "A knife meant for self-defense or mountaneering."
            });
        }

        private int GetCategoryId (string categoryName, WeaponsFactoryDbContext context)
        {
            return context.Categories.Local.Where(c => c.Name == categoryName).First().CategoryId;
        }

        private int GetManufacturerId (string manufacturerName, WeaponsFactoryDbContext context)
        {
            return context.Manufacturers.Local.Where(m => m.Name == manufacturerName).First().ManufacturerId;
        }
    }
}
