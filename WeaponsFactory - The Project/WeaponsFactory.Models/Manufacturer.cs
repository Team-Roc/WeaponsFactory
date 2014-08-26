namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        [Required]
        public string ManufacturerName { get; set; }
        
        public string FactoryAddress { get; set; }

        public int SupplyPerMonth { get; set; }
    }
}