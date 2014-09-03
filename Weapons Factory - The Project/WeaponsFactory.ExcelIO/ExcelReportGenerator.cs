namespace WeaponsFactory.ExcelIO
{
    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;
    using OfficeOpenXml.Table;
    using Telerik.OpenAccess;
    using WeaponsFactory.DataAccess;


    public static class ExcelFileCreator
    {
        private const string ReportStartCell = "A1";
        private const string ConnStr = @"Data Source={0};Version=3;";
        private const string SqliteFilePath = @"D:\AmmoOffered.sqlite";

        public static void GenerateExcelReport(string filePath, string sheetName = "Sheet1")
        {
            var sqliteData = GetSqliteData();
            var mySqlData = GetMySqlData();

            DataTable reportData = MergeDataTables(sqliteData, mySqlData);

            CreateExcelReport(sqliteData, sheetName, filePath);
        }

        private static DataTable GetSqliteData()
        {
            var result = new DataTable();

            var connStr = string.Format(ExcelFileCreator.ConnStr, ExcelFileCreator.SqliteFilePath);
            var dbConn = new SQLiteConnection(connStr);
            var query = @"SELECT * FROM AmmoInfo";
            var adapter = new SQLiteDataAdapter(query, dbConn);

            using (dbConn)
            {
                dbConn.Open();
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
                // Add a new worksheet to the excel file
                var worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                // Fill in data, beginning from the most top left cell
                worksheet.Cells[ExcelFileCreator.ReportStartCell].LoadFromDataTable(dataTable, true, TableStyles.None);

                // Create the .xlsx file
                excelPackage.Save();
            }
        }

        private static DataTable MergeDataTables(DataTable t1, DataTable t2)
        {
            var result = new DataTable();

            var res = t1.AsEnumerable();

            foreach (DataRow row in res)
            {
                var rowHasData = row.ItemArray.Any(i => i != DBNull.Value);

                if (rowHasData)
                {
                    Console.WriteLine(row["weaponid"]);
                    Console.WriteLine(row["ammosold"]);
                }
            }

            Console.WriteLine();

            //Console.WriteLine("SQLite");
            //foreach (DataRow item in t1.Rows)
            //{
            //    var items = item.ItemArray;

            //    foreach (var i in items)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("MySQL");

            //foreach (DataRow item in t2.Rows)
            //{
            //    var items = item.ItemArray;

            //    foreach (var i in items)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            return result;
        }
    }
}
