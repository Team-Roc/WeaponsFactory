// <copyright file="WeaponsFactoryModule.cs" company="Telerik">
// Telerik Academy 2014
// </copyright>

namespace WeaponsFactory.ConsoleClient
{
    using System;

    using WeaponsFactory.Data;
    using WeaponsFactory.Data.PDFReportGeneration;
    using WeaponsFactory.DataAccess;
    using WeaponsFactory.ExcelIO;

    public static class WeaponsFactoryModule
    {
        private const string ZipReportFilePath = "../../../InputData/WeaponsFactorySalesReports.zip";
        private const string PdfReportFilePath = "../../../Reports/PDF/Report.pdf";
        private const string ExcelReportFilePath = "../../../Reports/Excel/Report.xlsx";

        private static DateTime PdfReportStartDate = new DateTime(2000, 1, 1);
        private static DateTime PdfReportEndDate = new DateTime(2014, 1, 1);

        private static IWeaponsFactoryData weaponsFactorySqlData;
        private static WeaponsFactoryModel weaponsDataAccess;

        /// <summary>
        /// Initialize the data from Mongo and MySql databases.
        /// </summary>
        public static void InitializeData()
        {
            weaponsFactorySqlData = new WeaponsFactoryData();
            weaponsDataAccess = new WeaponsFactoryModel();
        }

        /// <summary>
        /// Move database schema from MongoDB to SQL Server.
        /// </summary>
        public static void MoveMongoDbDataToSqlDb()
        {
            var mongoData = new WeaponsFactoryMongoData(weaponsFactorySqlData);
            mongoData.TransferDataToSqlDb();
        }

        /// <summary>
        /// Load Excel Reports from ZIP File in MS SQL Server.
        /// </summary>
        public static void LoadDataFromExcelInSqlDb()
        {
            var importedExcel = ZipImporter.ImportZippedExcelReports(ZipReportFilePath);
            weaponsFactorySqlData.Sales.AddRange(importedExcel);
            weaponsFactorySqlData.Sales.SaveChanges();
        }

        /// <summary>
        /// Generate PDF Reports summarizing information from the SQL Server.
        /// </summary>
        public static void GeneratePDFReport()
        {
            var prdfReportGenerator = new PDFReportGenerator(weaponsFactorySqlData);
            prdfReportGenerator.ExportSalesEntriesToPdf(PdfReportFilePath, PdfReportStartDate, PdfReportEndDate);
        }

        /// <summary>
        /// Generate report in XML format from SQL Server database.
        /// </summary>
        public static void GenerateXmlReport()
        {

        }

        /// <summary>
        /// Create report for each product in JSON format.
        /// </summary>
        public static void GenerateJsonReport()
        {
            weaponsFactorySqlData.GenerateJsonReports();
        }

        /// <summary>
        /// Save all Json reports in MySQL database.
        /// </summary>
        public static void SaveJsonInMySqlDb()
        {
            weaponsDataAccess.DeserializeWeapons();
        }

        /// <summary>
        /// Load data from XML and save it in Mongo database
        /// </summary>
        public static void LoadDataFromXmlInMongoDb()
        {

        }

        /// <summary>
        /// Generate single Excel report from the data in SQLite and MySQL databases
        /// </summary>
        public static void GenerateExcelReportFromSQLiteAndMySqlDb()
        {
            ExcelFileCreator.GenerateExcelReport(ExcelReportFilePath);
        }
    }
}
