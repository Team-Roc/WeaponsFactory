namespace WeaponsFactory.Data.JSONSerialization
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class SerializeJson
    {
        public static void SerializeWeapons (IWeaponsFactoryDbContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                SaleId = s.SaleId,
                WeaponId = s.WeaponId,
                WeaponName = s.Weapon.Name,
                VendorName = s.Vendor.Name,
                Quantity = s.Quantity,
                Income = s.Quantity * s.UnitPrice
            });

            JsonSerializer serializer = new JsonSerializer();

            foreach (var sale in sales)
            {
                var currentSaleFile = "../../../JsonReports/" + sale.SaleId + ".json";
                if (File.Exists(currentSaleFile))
                {
                    return;
                }

                using (var fileStream = new FileStream("../../../JsonReports/" + sale.SaleId + ".json", FileMode.CreateNew))
                using (var streamWriter = new StreamWriter(fileStream))
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonWriter.Formatting = Formatting.Indented;

                    serializer.Serialize(jsonWriter, sale);
                }
            }
        }
    }
}
