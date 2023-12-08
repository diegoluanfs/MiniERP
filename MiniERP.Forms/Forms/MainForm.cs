// MainForm.cs
using System;
using System.Windows.Forms;
using MiniERP.Customers;

namespace MiniERP.Forms
{
    public partial class MainForm : Form
    {
        private CustomerLayout customerLayout;

        public MainForm()
        {
            InitializeComponent();
            customerLayout = new CustomerLayout();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            customerLayout.ModifyLayoutForCustomer(this);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {

        }
    }
}
