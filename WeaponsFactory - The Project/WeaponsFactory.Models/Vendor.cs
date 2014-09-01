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

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Sale> Weapons
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
