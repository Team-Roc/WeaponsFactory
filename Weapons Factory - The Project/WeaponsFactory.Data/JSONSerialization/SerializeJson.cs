namespace WeaponsFactory.Data.JSONSerialization
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class SerializeJson
    {
        public static void SerializeWeapons (IWeaponsFactoryDbContext context)
        {
            var productsReports =
                from weapon in context.Weapons
                join sale in context.Sales on weapon.WeaponId equals sale.WeaponId
                select new
                {
                    WeaponId = weapon.WeaponId,
                    WeaponName = weapon.Name,
                    ManufacturerName = weapon.Manufacturer.Name,
                    Quantity = context.Sales.Where(s => s.WeaponId == weapon.WeaponId).Sum(s => s.Quantity),
                    Income = sale.Quantity * sale.UnitPrice
                };

            JsonSerializer serializer = new JsonSerializer();

            foreach (var sale in productsReports)
            {
                var currentSaleFile = "../../../Reports/Json/" + sale.WeaponId + ".json";

                using (var fileStream = new FileStream(currentSaleFile, FileMode.Create))
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
