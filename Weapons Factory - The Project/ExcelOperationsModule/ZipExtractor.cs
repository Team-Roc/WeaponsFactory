namespace ExcelOperationsModule
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;

    using WeaponsFactory.Models;

    public static class ZipExtractor
    {
        //var exlcs = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        private const string oledbConnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties=\"Excel 12.0;HDR=YES\"";

        public static IEnumerable<Sale> ReadZippedReports(string zipPath, string tmpFolderPath = "none")
        {
            if (tmpFolderPath == "none")
            {
                tmpFolderPath = Path.GetTempPath() + @"dbproject";
            }

            var extractedFilepaths = ExtractContents(zipPath, tmpFolderPath);
            var importedSales = new List<Sale>();

            foreach (var filepath in extractedFilepaths)
            {
                var fileContents = ReadExcelFile(filepath);
                var newImportedSale = GetSaleObjByData(fileContents, filepath);
                importedSales.Add(newImportedSale);
            }

            //var path = @"C:\Users\Georgi\AppData\Local\Temp\dbproject\20-Jul-2013\Bourgas-Plaza-Sales-Report-id321-20-Jul-2013.xls";
            //var content = ReadExcelFile(path);
            //var sale = GetSaleObjByData(content, path);

            if (Directory.Exists(tmpFolderPath))
            {
                Directory.Delete(tmpFolderPath, true);
            }

            return importedSales;
        }

        private static Sale GetSaleObjByData(DataTable fileContents, string filePath)
        {
            var dateStr = Regex.Match(filePath, @"\d{2}-\w{3}-\d{4}", RegexOptions.IgnoreCase).Value;
            var vendorIdStr = Regex.Match(filePath, @"-id(\d+)-", RegexOptions.IgnoreCase).Value;
            vendorIdStr = Regex.Match(vendorIdStr, @"\d+").Value;
            var date = DateTime.Parse(dateStr, CultureInfo.InvariantCulture);
            Sale newSale = new Sale();

            foreach (DataRow row in fileContents.Rows)
            {
                var rowData = row.ItemArray.Where(e => e != DBNull.Value);

                foreach (var entry in rowData)
                {
                    newSale.Date = date;
                    newSale.Quantity = (int)((double)row["Quantity"]);
                    newSale.UnitPrice = (decimal)((double)row["Unit Price"]);
                    newSale.VendorId = int.Parse(vendorIdStr);
                    newSale.WeaponId = (int)((double)row["WeaponID"]);
                }
            }

            return newSale;
        }

        private static IEnumerable<string> ExtractContents(string zipPath, string tmpFolderPath)
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
