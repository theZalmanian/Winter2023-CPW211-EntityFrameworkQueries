using EntityFrameworkQueries.Data;
using EntityFrameworkQueries.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EntityFrameworkQueries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSelectAllVendors_Click(object sender, EventArgs e)
        {
            // Select all Vendors in the AP DB
            using ApContext dbContext = new();

            // LINQ Method Syntax
            List<Vendor> methodVendors = dbContext.Vendors.ToList();

            // LINQ Query Syntax
            List<Vendor> queryVendors = (from vendor in dbContext.Vendors
                                        select vendor).ToList();
        }

        private void BtnSelectAllVendorsInCA_Click(object sender, EventArgs e)
        {
            // Select all Vendors located in California, ordered by name ASC
            using ApContext dbContext = new();

            // LINQ Method Syntax
            List<Vendor> methodVendors = dbContext.Vendors
                                            .Where(currVendor => currVendor.VendorState == "CA")
                                            .OrderBy(currVendor => currVendor.VendorName)
                                            .ToList();

            // LINQ Query Syntax
            List<Vendor> queryVendors = (from vendor in dbContext.Vendors
                                         where vendor.VendorState == "CA"
                                         orderby vendor.VendorName ascending
                                         select vendor).ToList();
        }

        private void BtnSelectSpecificColumns_Click(object sender, EventArgs e)
        {
            // Get the VendorName, VendorCity, and VendorState for all Vendors
            using ApContext dbContext = new();

            List<VendorLocation> results = (from vendor in dbContext.Vendors
                                               select new VendorLocation
                                               {
                                                  VendorName = vendor.VendorName,
                                                  VendorCity = vendor.VendorCity,
                                                  VendorState = vendor.VendorState
                                               }
                                            ).ToList();

            // Display vendors
            StringBuilder displayString = new();
            foreach(VendorLocation vendor in results)
            {
                displayString.AppendLine($"{vendor.VendorName} is in {vendor.VendorCity}, {vendor.VendorState}");
            }

            MessageBox.Show(displayString.ToString());
        }

        private void BtnMiscQueries_Click(object sender, EventArgs e)
        {
            // Get a single vendor from the DB
            getVendor();

            // Get and display the number of invoices in the DB
            getInvoiceCount();
        }

        private void getVendor()
        {
            // Get a single vendor from the DB
            using ApContext dbContext = new();

            Vendor? currVendor = (from vendor in dbContext.Vendors
                                  where vendor.VendorName == "IBM"
                                  select vendor).SingleOrDefault();

            if (currVendor != null)
            {
                // Display the vendor's name
                MessageBox.Show(currVendor.VendorName);
            }
        }

        private void getInvoiceCount()
        {
            // Get and display the number of invoices in the DB
            using ApContext dbContext = new();

            int invoiceCount = (from invoice in dbContext.Invoices
                                select invoice).Count();

            MessageBox.Show($"There are {invoiceCount} invoices in the AP database");
        }
    }

    class VendorLocation
    {
        public string VendorName { get; set; }

        public string VendorCity { get; set; }

        public string VendorState { get; set; }
    }
}