namespace WeaponsFactory.ExcelIO
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text.RegularExpressions;

    using WeaponsFactory.Models.SqlModels;

    public static class ZipImporter
    {
        private static string oledbConnStr = ConfigurationManager.ConnectionStrings["OleDB"].ConnectionString;

        public static IEnumerable<Sale> ImportZippedExcelReports(string zipPath, string tmpFolderPath = "none")
        {
            if (tmpFolderPath == "none")
            {
                tmpFolderPath = Path.GetTempPath() + @"dbproject";
            }

            var extractedFilepaths = ExtractZipContents(zipPath, tmpFolderPath);
            var importedSales = new List<Sale>();

            foreach (var filepath in extractedFilepaths)
            {
                var fileContents = ZipImporter.ReadExcelFile(filepath);
                var newImportedSale = ZipImporter.GetSaleObjByData(fileContents, filepath);
                importedSales.AddRange(newImportedSale);
            }

            if (Directory.Exists(tmpFolderPath))
            {
                Directory.Delete(tmpFolderPath, true);
            }

            return importedSales;
        }

        private static IEnumerable<Sale> GetSaleObjByData(DataTable fileContents, string filePath)
        {
            var dateStr = Regex.Match(filePath, @"\d{2}-\w{3}-\d{4}", RegexOptions.IgnoreCase).Value;

            var vendorIdStr = Regex.Match(filePath, @"-id(\d+)-", RegexOptions.IgnoreCase).Value;
            vendorIdStr = Regex.Match(vendorIdStr, @"\d+").Value;
            var vendorId = int.Parse(vendorIdStr);

            var date = DateTime.Parse(dateStr, CultureInfo.InvariantCulture);
            var newSales = new List<Sale>();

            foreach (DataRow row in fileContents.Rows)
            {
                var rowContainsData = row.ItemArray
                    .Any(i => i != DBNull.Value);

                if (rowContainsData)
                {
                    var newSale = new Sale();
                    newSale.Date = date;
                    newSale.Quantity = (int)((double)row["Quantity"]);
                    newSale.UnitPrice = (decimal)((double)row["Unit Price"]);
                    newSale.VendorId = vendorId;
                    newSale.WeaponId = (int)((double)row["WeaponID"]);
                    newSales.Add(newSale);
                }
            }

            return newSales;
        }

        private static IEnumerable<string> ExtractZipContents(string zipPath, string tmpFolderPath)
        {
            var extractedFilesPaths = new List<string>();

            if (!Directory.Exists(tmpFolderPath))
            {
                Directory.CreateDirectory(tmpFolderPath);
            }

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                string currentFolderName = string.Empty;
                string currentFolderPath = string.Empty;

                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith("/"))
                    {
                        currentFolderName = entry.FullName.Substring(0, entry.FullName.Length - 1);
                        currentFolderPath = Path.Combine(tmpFolderPath, currentFolderName);
                        Directory.CreateDirectory(currentFolderPath);
                    }
                    else
                    {
                        var filepath = Path.Combine(currentFolderPath, entry.Name);
                        entry.ExtractToFile(filepath, true);
                        extractedFilesPaths.Add(filepath);
                    }
                }
            }

            return extractedFilesPaths;
        }

        private static DataTable ReadExcelFile(string excelFilePath)
        {
            var connStr = string.Format(oledbConnStr, excelFilePath);
            var exelFileConn = new OleDbConnection(connStr);

            var dataTable = new DataTable();

            using (exelFileConn)
            {
                exelFileConn.Open();
                var sqlQuery = @"SELECT * FROM [Sales$]";
                var dataAdapter = new OleDbDataAdapter(sqlQuery, exelFileConn);
                dataAdapter.Fill(dataTable);
            }

            return dataTable;
        }
    }
}