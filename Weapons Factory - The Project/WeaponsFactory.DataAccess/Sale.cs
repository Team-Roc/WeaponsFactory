namespace WeaponsFactory.DataAccess
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int WeaponId { get; set; }

        public string WeaponName { get; set; }
        public string VendorName { get; set; }

        public int Quantity { get; set; }
        public decimal Income { get; set; }
    }
}
