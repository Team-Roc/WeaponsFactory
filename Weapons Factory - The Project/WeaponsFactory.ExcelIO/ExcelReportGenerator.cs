namespace WeaponsFactory.ExcelIO
{
    using System.Data;
    using System.IO;

    using OfficeOpenXml;
    using OfficeOpenXml.Table;

    public static class ExcelFileCreator
    {
#warning Add connection strings for MySQL and SQLite

        private const string ReportStartCell = "A1";
        private const string SqliteFilePath = @"D:\TaxesByWeaponCategory.sqlite";

        public static void GenerateExcelReport()
        {
            DataTable sqliteData = GetSqliteData();
            //DataTable mySqlData = GetMySqlData();
        }

        private static DataTable GetSqliteData()
        {



            return new DataTable();
        }

        private static DataTable GetMySqlData()
        {
            throw new System.NotImplementedException();
        }

        private static void CreateExcelReport(DataTable dataTable, string sheetName, string fileName)
        {
            var excelFile = File.Create(fileName);

            using (var excelPackage = new ExcelPackage(excelFile))
            {
                // Add a new worksheet to the excel file
                var worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                // Fill in data, beginning from the most top left cell
                worksheet.Cells[ExcelFileCreator.ReportStartCell].LoadFromDataTable(dataTable, true, TableStyles.None);

                // Create the .xlsx file
                excelPackage.Save();
            }
        }
    }
}
