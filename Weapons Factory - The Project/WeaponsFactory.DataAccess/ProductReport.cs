namespace WeaponsFactory.DataAccess
{
    public class ProductReport
    {
        public int WeaponId { get; set; }

        public string WeaponName { get; set; }
        public string ManufacturerName { get; set; }

        public int Quantity { get; set; }
        public decimal Income { get; set; }
    }
}
