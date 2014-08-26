namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        public string ProductName { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; }

        [ForeignKey("WeaponType")]
        public int WeaponTypeID { get; set; }
    }
}