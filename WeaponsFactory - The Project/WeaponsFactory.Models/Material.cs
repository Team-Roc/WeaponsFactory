namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        public string MaterialName { get; set; }

        public int UnitWeight { get; set; }

        public decimal PricePerUnit { get; set; }
    }
}