using EntityFrameworkQueries.Data;
using EntityFrameworkQueries.Models;

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
            List<Vendor> allVendors1 = dbContext.Vendors.ToList();

            // LINQ Query Syntax
            List<Vendor> allVendors2 = (from vendor in dbContext.Vendors
                                        select vendor).ToList();
        }
    }
}