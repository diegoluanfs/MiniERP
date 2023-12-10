using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Forms.Forms
{
    public partial class MainForm:Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // Criar uma instância do novo formulário
            CustomerForm customerForm = new CustomerForm();

            // Exibir o novo formulário
            customerForm.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            // Criar uma instância do novo formulário
            SupplierForm suppliertForm = new SupplierForm();

            // Exibir o novo formulário
            suppliertForm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            // Criar uma instância do novo formulário
            ProductForm productForm = new ProductForm();

            // Exibir o novo formulário
            productForm.Show();
        }

    }
}
