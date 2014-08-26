namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Purpose
    {
        [Key]
        public int PurposeId { get; set; }

        public string Purpose { get; set; }
    }
}