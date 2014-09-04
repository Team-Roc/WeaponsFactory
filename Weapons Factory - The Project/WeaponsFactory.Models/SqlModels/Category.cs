namespace WeaponsFactory.Models.SqlModels
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
        [Column("ID")]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
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
