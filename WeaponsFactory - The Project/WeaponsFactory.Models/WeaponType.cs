namespace WeaponsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WeaponType
    {
        [Key]
        public int WeaponTypeId { get; set; }

        public string TypeName { get; set; }

        [ForeignKey("Purpose")]
        public int PurposeID { get; set; }

        [ForeignKey("Material")]
        public int MaterialID { get; set; }
    }
}
