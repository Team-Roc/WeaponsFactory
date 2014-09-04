namespace WeaponsFactory.Reports.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PdfSaleReportEntry
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Vendor { get; set; }

        [Column("Unit Price")]
        public decimal UnitPrice { get; set; }

        public decimal Sum { get; set; }
    }
}
