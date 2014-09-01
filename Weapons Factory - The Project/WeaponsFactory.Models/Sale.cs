namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Vendor")]
        public int VendorID { get; set; }

        public virtual Vendor Vendor { get; set; }

        [ForeignKey("Weapon")]
        public int WeaponID { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}
