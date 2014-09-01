namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        [Column("ID")]
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        [Column("Unit Price")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        [ForeignKey("Weapon")]
        public int WeaponId { get; set; }

        public virtual Weapon Weapon { get; set; }
    }
}
