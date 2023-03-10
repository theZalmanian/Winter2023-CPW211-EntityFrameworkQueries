using EntityFrameworkQueries.Data;
using EntityFrameworkQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

            // Display Vendors
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
            GetVendor("IBM");

            // Get and display the number of invoices in the DB
            GetInvoiceCount();

            // Check if a vendor exists in Washington
            DoesVendorExistIn("WA");
        }

        private static void GetVendor(string vendorName)
        {
            // Get a single vendor from the DB
            using ApContext dbContext = new();

            Vendor? currVendor = (from vendor in dbContext.Vendors
                                  where vendor.VendorName == vendorName
                                  select vendor).SingleOrDefault();

            if (currVendor != null)
            {
                // Display the vendor's name
                MessageBox.Show(currVendor.VendorName);
            }
        }

        private static void GetInvoiceCount()
        {
            // Get and display the number of invoices in the DB
            using ApContext dbContext = new();

            int invoiceCount = (from invoice in dbContext.Invoices
                                select invoice).Count();

            MessageBox.Show($"There are {invoiceCount} invoices in the AP database");
        }

        private static void DoesVendorExistIn(string state)
        {
            // Check if a vendor exists in the given state
            using ApContext dbContext = new();

            bool doesExist = (from vendor in dbContext.Vendors
                              where vendor.VendorState == state
                              select vendor).Any();

            // Display results
            if (doesExist)
            {
                MessageBox.Show($"A vendor does exist in the state of {state}");
            }

            else
            {
                MessageBox.Show($"A vendor does not exist in the state of {state}");
            }
        }

        private void BtnVendorsAndInvoices_Click(object sender, EventArgs e)
        {
            // Get all Vendors and their Invoices
            using ApContext dbContext = new();

            // Vendors LEFT JOIN Invoices
            List<Vendor> allVendors = dbContext.Vendors.Include(vendor => vendor.Invoices).ToList();

            // Display Vendors and their invoices
            StringBuilder results = new();

            // Run through each Vendor
            foreach (Vendor currVendor in allVendors)
            {
                // Display their name
                results.Append(currVendor.VendorName);

                // Run through all that Vendor's Invoices
                foreach(Invoice currInvoice in currVendor.Invoices)
                {
                    // Display the invoice number
                    results.Append($", {currInvoice.InvoiceNumber}");
                }

                // Blank line for spacing
                results.AppendLine();
            }

            MessageBox.Show(results.ToString());
        }
    }

    class VendorLocation
    {
        public string VendorName { get; set; }

        public string VendorCity { get; set; }

        public string VendorState { get; set; }
    }
}