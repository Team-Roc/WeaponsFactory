namespace WeaponsFactory.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Weapon
    {
        private ICollection<Sale> sales;

        public Weapon()
        {
            this.sales = new HashSet<Sale>();
        }

        [Key]
        public int WeaponID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get
            {
                return this.sales;
            }
            set
            {
                this.sales = value;
            }
        }
    }
}
