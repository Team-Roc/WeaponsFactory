namespace WeaponsFactory.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Configuration;

    using WeaponsFactory.Data;
    using WeaponsFactory.Models;
    using WeaponsFactory.DataAccess;
    using WeaponsFactory.Data.PDFReportGeneration;
    using WeaponsFactory.ExcelIO;

    public class WeaponsFactoryConsoleClient
    {
        public const string PdfReportfPath = "../../";
        public const string PdfReportName = "/Report.pdf";

        private static readonly IWeaponsFactoryData weaponsFactoryData = new WeaponsFactoryData();

        public static void Main()
        {
            //Transfers the DB schema from MongoDB to SQL Server
            var data = new WeaponsFactoryData();

            var mongoData = new WeaponsFactoryMongoData(data);
            mongoData.TransferDataToSqlDb();

            //var dataAccess = new WeaponsFactoryModel();
            //dataAccess.GetReportsTable();
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
