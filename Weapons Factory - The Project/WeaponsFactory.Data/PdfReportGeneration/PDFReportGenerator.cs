namespace WeaponsFactory.Data.PDFReportGeneration
{
    using System;
    using System.IO;
    using System.Linq;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using WeaponsFactory.Reports.Models;

    public class PDFReportGenerator
    {
        private const string DateTimeFormat = "dd.MM.yyyy";
        private const int TableColumnsNumber = 6;

        private readonly IWeaponsFactoryData weaponsFactoryData;

        public PDFReportGenerator(IWeaponsFactoryData weaponsFactoryData)
        {
            this.weaponsFactoryData = weaponsFactoryData;
        }

        public void ExportSalesEntriesToPdf(string pathToSave, string pdfReportName, DateTime startDate, DateTime endDate)
        {
            Document doc = this.InitializePdfDocument(pathToSave + pdfReportName);
            using (doc)
            {
                doc.Open();
                var table = this.InitializePdfTable(TableColumnsNumber);

                this.SetTableTitle(table, TableColumnsNumber, startDate, endDate);
                this.SetTableColumnHeaders(table);

                var salesReportEntries = this.GetSaleReportsFromDatabase(startDate, endDate);
                this.FillPdfTableBody(salesReportEntries, table);

                decimal totalSum = salesReportEntries.Sum(x => x.Sum);
                this.SetTableFooter(table, totalSum, TableColumnsNumber);

                doc.Add(table);
            }
        }

        private IQueryable<PdfSaleReportEntry> GetSaleReportsFromDatabase(DateTime startDate, DateTime endDate)
        {
            var salesReportEntries = from s in this.weaponsFactoryData.Sales.All()
                                     join w in this.weaponsFactoryData.Weapons.All() on s.WeaponId equals w.WeaponId
                                     join ven in this.weaponsFactoryData.Vendors.All() on s.VendorId equals ven.VendorId
                                
                                     select new PdfSaleReportEntry
                                     {
                                         Name = w.Name,
                                         Quantity = s.Quantity,
                                         UnitPrice = s.UnitPrice,
                                         Vendor = ven.Name,
                                         Sum = s.Quantity * s.UnitPrice,
                                         Date = s.Date,
                                     };

            return salesReportEntries;
        }

        private void FillPdfTableBody(IQueryable<PdfSaleReportEntry> salesReportEntries, PdfPTable table)
        {
            foreach (var salesEntry in salesReportEntries)
            {
                this.AddTableCell(table, salesEntry.Name);
                this.AddTableCell(table, salesEntry.Quantity.ToString());
                this.AddTableCell(table, salesEntry.UnitPrice.ToString());
                this.AddTableCell(table, salesEntry.Vendor.ToString());
                this.AddTableCell(table, salesEntry.Sum.ToString());
                this.AddTableCell(table, salesEntry.Date.ToString(DateTimeFormat));
            }
        }

        private Document InitializePdfDocument(string pdfFullPath)
        {
            var doc = new Document();
            var file = File.Create(pdfFullPath);
            PdfWriter.GetInstance(doc, file);
            return doc;
        }

        private PdfPTable InitializePdfTable(int columnsNumber)
        {
            var table = new PdfPTable(columnsNumber);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            float[] widths = new float[] { 100f, 100, 100f, 100f, 100f, 100f };
            table.SetWidths(widths);
            return table;
        }

        private void SetTableTitle(PdfPTable table, int tableColumnsNumber, DateTime startDate, DateTime endDate)
        {
            var cell = new PdfPCell(new Phrase(string.Format("Weapons Factory - Aggregated Sales Report ({0} - {1})",
                startDate.ToString(DateTimeFormat), endDate.ToString(DateTimeFormat))));

            cell.Colspan = tableColumnsNumber;
            cell.HorizontalAlignment = 1;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);
        }

        private void SetTableFooter(PdfPTable table, decimal totalSum, int tableColumnsNumber)
        {
            var cell = new PdfPCell(new Phrase("Total sum: " + totalSum.ToString()));
            cell.Colspan = tableColumnsNumber - 1;
            cell.HorizontalAlignment = 2;
            cell.PaddingBottom = 5f;
            cell.PaddingRight = 35f;
            cell.BorderWidthRight = 0;
            table.AddCell(cell);

            cell = new PdfPCell();
            cell.Colspan = 1;
            cell.BorderWidthLeft = 0;
            table.AddCell(cell);
        }

        private void SetTableColumnHeaders(PdfPTable table)
        {
            this.AddTableCell(table, "Weapon");
            this.AddTableCell(table, "Quantity");
            this.AddTableCell(table, "Unit Price");
            this.AddTableCell(table, "Vendor");
            this.AddTableCell(table, "Sum");
            this.AddTableCell(table, "Date");
        }

        private void AddTableCell(PdfPTable table, string phraseName)
        {
            var cell = new PdfPCell(new Phrase(phraseName));
            cell.Colspan = 1;
            cell.HorizontalAlignment = 1;
            cell.PaddingBottom = 5f;
            cell.PaddingLeft = 5f;
            table.AddCell(cell);
        }
    }
}
