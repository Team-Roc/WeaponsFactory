namespace ExcelOperationsModule
{
    using System.Data;
    using System.IO;

    using OfficeOpenXml;
    using OfficeOpenXml.Table;

    public static class ZipCreator
    {
#warning Add connection strings for MySQL and SQLite

        private const string ReportStartCell = "A1";

        public static void GenerateExcelReport()
        {
            DataTable mySqlData = GetMySqlData();
            DataTable sqliteData = GetSqliteData();
        }

        private static DataTable GetSqliteData()
        {
            throw new System.NotImplementedException();
        }

        private static DataTable GetMySqlData()
        {
            throw new System.NotImplementedException();
        }

        private void CreateExcelReport(DataTable dataTable, string sheetName, string fileName)
        {
            var excelFile = File.Create(fileName);
            
            using (var excelPackage = new ExcelPackage(excelFile))
            {
                // Add a new worksheet to the excel file
                var worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                // Fill in data, beginning from the most top left cell
                worksheet.Cells[ReportStartCell].LoadFromDataTable(dataTable, true, TableStyles.None);

                // Create the .xlsx file
                excelPackage.Save();
            }
        }
    }
}
