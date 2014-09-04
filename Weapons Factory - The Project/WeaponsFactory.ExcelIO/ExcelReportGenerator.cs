namespace WeaponsFactory.ExcelIO
{
    using System.Data;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;
    using OfficeOpenXml.Table;
    using WeaponsFactory.DataAccess;

    public static class ExcelFileCreator
    {
        private const string ReportStartCell = "A1";
        private const string ConnStr = @"Data Source={0};Version=3;";

        public static void GenerateExcelReport(string reportFilePath, string dataSourcePath, string sheetName = "Sheet1")
        {
            var sqliteData = GetSqliteData(dataSourcePath);
            var mySqlData = GetMySqlData();

            var reportData = MergeDataTables(sqliteData, mySqlData);

            CreateExcelReport(reportData, sheetName, reportFilePath);
        }

        private static DataTable GetSqliteData(string dataSourcePath)
        {
            var result = new DataTable();

            var connectionString = string.Format(ExcelFileCreator.ConnStr, dataSourcePath);
            var dbConnection = new SQLiteConnection(connectionString);
            var query = @"SELECT * FROM AmmoInfo";
            var adapter = new SQLiteDataAdapter(query, dbConnection);

            using (dbConnection)
            {
                dbConnection.Open();
                adapter.Fill(result);
            }

            return result;
        }

        private static DataTable GetMySqlData()
        {
            var dataAccess = new WeaponsFactoryModel();
            DataTable mySqlData = dataAccess.GetReportsTable();
            return mySqlData;
        }

        private static void CreateExcelReport(DataTable dataTable, string sheetName, string fileName)
        {
            var excelFile = File.Create(fileName);

            using (var excelPackage = new ExcelPackage(excelFile))
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
                worksheet.Cells[ExcelFileCreator.ReportStartCell].LoadFromDataTable(dataTable, true, TableStyles.None);
                excelPackage.Save();
            }
        }

        private static DataTable MergeDataTables(DataTable sqliteData, DataTable mySqlData)
        {
            var dtResult = new DataTable();
            dtResult.Columns.Add("Weapon Name", typeof(string));
            dtResult.Columns.Add("Manufacturere Name", typeof(string));
            dtResult.Columns.Add("Quantity Sold", typeof(int));
            dtResult.Columns.Add("Income", typeof(decimal));
            dtResult.Columns.Add("Expenses", typeof(int));
            dtResult.Columns.Add("Financial Result", typeof(int));

            var result = from mySqlRows in mySqlData.AsEnumerable()
                         join sqliteRows in sqliteData.AsEnumerable()
                         on mySqlRows.Field<int>("WeaponId") equals sqliteRows.Field<long>("WeaponId")
                         orderby mySqlRows.Field<decimal>("Income")
                         select new object[]
                         {
                             mySqlRows.Field<string>("WeaponName"),
                             mySqlRows.Field<string>("ManufacturerName"),
                             mySqlRows.Field<int>("Quantity"),
                             mySqlRows.Field<decimal>("Income"),
                             (sqliteRows.Field<long>("TotalGiftAmmoPrice") * mySqlRows.Field<int>("Quantity")),
                             (mySqlRows.Field<decimal>("Income") - ((decimal)sqliteRows.Field<long>("TotalGiftAmmoPrice") * mySqlRows.Field<int>("Quantity")))
                         };

            foreach (var row in result)
            {
                var newRow = dtResult.NewRow();
                newRow.ItemArray = row;
                dtResult.Rows.Add(newRow);
            }

            var totalQuantitySold = result.Select(r => (int)r[2]).Sum();
            var totalIncome = result.Select(r => (decimal)r[3]).Sum();
            var totalExpenses = result.Select(r => (long)r[4]).Sum();
            var totalFinancialResult = result.Select(r => (decimal)r[5]).Sum();

            var finalRow = dtResult.NewRow();
            finalRow.ItemArray = new object[]
                {
                    "Totals:", 
                    " - ", 
                    totalQuantitySold, 
                    totalIncome, 
                    totalExpenses, 
                    totalFinancialResult 
                };
            dtResult.Rows.Add(finalRow);

            return dtResult;
        }
    }
}
