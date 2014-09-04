// <copyright file="WeaponsFactoryFacade.cs" company="Telerik">
// Telerik Academy 2014
// </copyright>

namespace WeaponsFactory.ConsoleClient
{
    using System;

    using WeaponsFactory.Data;
    using WeaponsFactory.Data.PDFReportGeneration;
    using WeaponsFactory.DataAccess;
    using WeaponsFactory.ExcelIO;

    public static class WeaponsFactoryFacade
    {
        private const string ZipReportFilePath = "../../../InputData/WeaponsFactorySalesReports.zip";
        private const string DataSourcesSQLitePath = "../../../InputData/AmmoOffered.sqlite";
        private const string PdfReportFilePath = "../../../Reports/PDF/Report.pdf";
        private const string ExcelReportFilePath = "../../../Reports/Excel/WeaponsFactoryFinancialResult.xlsx";

        private const string InitializeDataMessage = "Database initializing... ";
        private const string TransferDataToSqlDbMessage = "MongoDb to SqlDb... ";
        private const string LoadDataFromExcelInSqlDbMessage = "Excel to SqlDb... ";
        private const string GeneratePDFReportMessage = "SqlDb to PDF... ";
        private const string GenerateXmlReportMessage = "SqlDb to Xml... ";
        private const string GenerateJsonReportMessage = "SqlDb to Json... ";
        private const string SaveJsonInMySqlDbMessage = "Json to MySqlDb... ";
        private const string LoadDataFromXmlInMongoDbMessage = "Xml to MongoDb... ";
        private const string GenerateExcelReportFromSQLiteAndMySqlDbMessage = "SQLite and MySqlDb to Excel... ";
        private const string SuccessMessage = "Done!";

        private static DateTime pdfReportStartDate = new DateTime(2000, 1, 1);
        private static DateTime pdfReportEndDate = new DateTime(2014, 1, 1);

        private static IWeaponsFactoryData weaponsFactorySqlData;
        private static WeaponsFactoryModel weaponsFactoryDataAccess;

        /// <summary>
        /// Initialize the data from Mongo and MySql databases.
        /// </summary>
        public static void InitializeData()
        {
            WeaponsFactoryConsoleWriter.StartProcess(InitializeDataMessage);

            weaponsFactorySqlData = new WeaponsFactoryData();
            weaponsFactoryDataAccess = new WeaponsFactoryModel();

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Move database schema from MongoDB to SQL Server.
        /// </summary>
        public static void MoveMongoDbDataToSqlDb()
        {
            WeaponsFactoryConsoleWriter.StartProcess(TransferDataToSqlDbMessage);

            var mongoData = new WeaponsFactoryMongoData(weaponsFactorySqlData);
            mongoData.TransferDataToSqlDb();

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Load Excel Reports from ZIP File in MS SQL Server.
        /// </summary>
        public static void LoadDataFromExcelInSqlDb()
        {
            WeaponsFactoryConsoleWriter.StartProcess(LoadDataFromExcelInSqlDbMessage);

            var importedExcel = ZipImporter.ImportZippedExcelReports(ZipReportFilePath);
            weaponsFactorySqlData.Sales.AddRange(importedExcel);
            weaponsFactorySqlData.Sales.SaveChanges();

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Generate PDF Reports summarizing information from the SQL Server.
        /// </summary>
        public static void GeneratePDFReport()
        {
            WeaponsFactoryConsoleWriter.StartProcess(GeneratePDFReportMessage);

            var prdfReportGenerator = new PDFReportGenerator(weaponsFactorySqlData);
            prdfReportGenerator.ExportSalesEntriesToPdf(PdfReportFilePath, pdfReportStartDate, pdfReportEndDate);

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Generate report in XML format from SQL Server database.
        /// </summary>
        public static void GenerateXmlReport()
        {
            WeaponsFactoryConsoleWriter.StartProcess(GenerateXmlReportMessage);

            //TODO!

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Create report for each product in JSON format.
        /// </summary>
        public static void GenerateJsonReport()
        {
            WeaponsFactoryConsoleWriter.StartProcess(GenerateJsonReportMessage);

            weaponsFactorySqlData.GenerateJsonReports();

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Save all Json reports in MySQL database.
        /// </summary>
        public static void SaveJsonInMySqlDb()
        {
            WeaponsFactoryConsoleWriter.StartProcess(SaveJsonInMySqlDbMessage);

            weaponsFactoryDataAccess.DeserializeWeapons();

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Load data from XML and save it in Mongo database
        /// </summary>
        public static void LoadDataFromXmlInMongoDb()
        {
            WeaponsFactoryConsoleWriter.StartProcess(LoadDataFromXmlInMongoDbMessage);

            //TODO!

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }

        /// <summary>
        /// Generate single Excel report from the data in SQLite and MySQL databases
        /// </summary>
        public static void GenerateExcelReportFromSQLiteAndMySqlDb()
        {
            WeaponsFactoryConsoleWriter.StartProcess(GenerateExcelReportFromSQLiteAndMySqlDbMessage);

            ExcelFileCreator.GenerateExcelReport(ExcelReportFilePath, DataSourcesSQLitePath);

            WeaponsFactoryConsoleWriter.Success(SuccessMessage);
        }
    }
}
