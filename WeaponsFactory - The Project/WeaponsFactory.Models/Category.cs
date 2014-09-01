namespace WeaponsFactory.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Weapon> weapons;

        public Category()
        {
            this.weapons = new HashSet<Weapon>();
        }

        [Key]
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Weapon> Weapons
        {
            get
            {
                return this.weapons;
            }
            set
            {
                this.weapons = value;
            }
        }
    }
}
