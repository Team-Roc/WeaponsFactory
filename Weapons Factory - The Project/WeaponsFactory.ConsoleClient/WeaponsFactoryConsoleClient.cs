namespace WeaponsFactory.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Configuration;

    using WeaponsFactory.Data;
    using WeaponsFactory.Models;
    using WeaponsFactory.DataAccess;
    using WeaponsFactory.MongoDb;
    using WeaponsFactory.Data.PDFReportGeneration;
    using WeaponsFactory.ExcelIO;

    public class WeaponsFactoryConsoleClient
    {
        public const string PdfReportfPath = "../../";
        public const string PdfReportName = "/Report.pdf";

        private static readonly IWeaponsFactoryData weaponsFactoryData = new WeaponsFactoryData();

        public static void Main()
        {
            //SQL
            var data = new WeaponsFactoryData();

            



            //{
            //    //var vendor = new Vendor { Name = "NewVendorName", Address = "NewVendorAddress" };
            //    //data.Vendors.Add(vendor);
            //    //data.Vendors.SaveChanges();

            //    //var manufacturer = new Manufacturer { Name = "TestManufacturer" };
            //    //data.Manufacturers.Add(manufacturer);
            //    //data.Manufacturers.SaveChanges();

            //    //WeaponsFactory.Models.Sale sale = new WeaponsFactory.Models.Sale{ Quantity = 5, UnitPrice = 17, VendorId = 1, WeaponId = 3, Date = DateTime.Now }
            //    //data.Manufacturers.Add(manufacturer);
            //    //data.Manufacturers.SaveChanges();

            //    // this is how you delete (facepalm)
            //    //data.Vendors.Delete(data.Vendors.All().Where(v => v.Name == "NewVendorName").FirstOrDefault());
            //    //data.Vendors.SaveChanges();

            //    //foreach (var v in data.Vendors.All())
            //    //{
            //    //    Console.WriteLine(v.Name + " - " + v.Address);
            //    //}
            //}

            ////MONGO
            //{
            //    var mongoData = new WeaponsFactoryMongoData(data);

            //    //mongoData.Get();
            //}

            //var dataAccess = new WeaponsFactoryModel();

            //data.GenerateJsonReports();

            //dataAccess.DeserializeWeapons();
            ////foreach (var sale in sales)
            ////{
            ////    Console.WriteLine("date: {0}, Quantity: {1}, SaleId {2}, UnitePrice: {3}, Vendor: {4}, VendorID: {5}, Weapon: {6}, WeaponID {7}", sale.Date, sale.Quantity, sale.SaleId, sale.UnitPrice, sale.Vendor, sale.VendorId, sale.Weapon, sale.WeaponId);
            ////}

            ////GeneratePDFReport();
        }

        private static void GeneratePDFReport()
        {
            var prdfReportGenerator = new PDFReportGenerator(weaponsFactoryData);
            prdfReportGenerator.ExportSalesEntriesToPdf(PdfReportfPath, PdfReportName, new DateTime(2000, 1, 1), new DateTime(2014, 1, 1));
        }
    }
}
