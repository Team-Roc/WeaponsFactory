namespace WeaponsFactory.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vendor
    {
        private ICollection<Sale> sales;

        public Vendor()
        {
            this.sales = new HashSet<Sale>();
        }

        [Key]
        public int VendorID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Address { get; set; }

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
