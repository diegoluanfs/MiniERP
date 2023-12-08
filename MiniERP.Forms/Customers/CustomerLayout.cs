// CustomerLayout.cs
using MiniERP.Logic;
using System;
using System.Windows.Forms;

namespace MiniERP.Customers
{
    public class CustomerLayout
    {
        private Button btnBack;
        private Button btnCustomers;
        private ListView listViewCustomers;
        private Label label1;
        private Label label2;
        private TextBox txtID;
        private TextBox txtName;
        private bool isCustomerLayout = false;

        public CustomerLayout()
        {
            // Inicialização ou configurações específicas para o layout de clientes podem ser feitas aqui, se necessário.
        }

        public void ModifyLayoutForCustomer(Form form)
        {
            int linha1 = 25;
            int linha2 = 70;
            int linha3 = 85;
            int linha4 = 120;

            int coluna1 = 25;
            int coluna2 = 125;
            int coluna3 = 325;

            if (!isCustomerLayout)
            {
                // Limpar todos os controles existentes na MainForm
                form.Controls.Clear();

                // Configurar os controles conforme necessário para a visualização de clientes
                btnBack = new Button
                {
                    Location = new System.Drawing.Point(coluna1, linha1),
                    Name = "btnBack",
                    Size = new System.Drawing.Size(150, 30),
                    Text = "Voltar",
                    UseVisualStyleBackColor = true,
                };
                btnBack.Click += new System.EventHandler((sender, e) => btnBack_Click(form, e));

                label1 = new Label
                {
                    AutoSize = true,
                    Location = new System.Drawing.Point(coluna1, linha2),
                    Name = "label1",
                    Size = new System.Drawing.Size(25, 30),
                    Text = "ID",
                };

                txtID = new TextBox
                {
                    Enabled = true,
                    Location = new System.Drawing.Point(coluna1, linha3),
                    Name = "txtID",
                    Size = new System.Drawing.Size(50, 40),
                };
                txtID.TextChanged += new System.EventHandler((sender, e) => TxtID_TextChanged(form, e));

                // Adicionar os controles conforme especificado ao invés de limpar tudo
                btnCustomers = new Button
                {
                    Location = new System.Drawing.Point(coluna3, linha3),
                    Name = "btnCustomers",
                    Size = new System.Drawing.Size(200, 30),
                    Text = "Listar Clientes",
                    UseVisualStyleBackColor = true,
                };
                // Adicionar manipuladores de evento conforme necessário
                btnCustomers.Click += new System.EventHandler((sender, e) => btnCustomers_Click(form, e));

                label2 = new Label
                {
                    AutoSize = true,
                    Location = new System.Drawing.Point(coluna2, linha2),
                    Name = "label2",
                    Size = new System.Drawing.Size(50, 30),
                    Text = "Nome",
                };

                txtName = new TextBox
                {
                    Location = new System.Drawing.Point(coluna2, linha3),
                    Name = "txtName",
                    Size = new System.Drawing.Size(150, 40),
                };
                txtName.TextChanged += new System.EventHandler((sender, e) => TxtName_TextChanged(form, e));

                listViewCustomers = new ListView
                {
                    Location = new System.Drawing.Point(coluna1, linha4),
                    Name = "listViewCustomers",
                    Size = new System.Drawing.Size(500, 250),
                    UseCompatibleStateImageBehavior = false,
                };

                form.Controls.Add(btnBack);
                form.Controls.Add(btnCustomers);
                form.Controls.Add(listViewCustomers);
                form.Controls.Add(label1);
                form.Controls.Add(label2);
                form.Controls.Add(txtID);
                form.Controls.Add(txtName);

                // Atualizar o estado da variável indicando que o layout de clientes está ativo
                isCustomerLayout = true;
            }
        }

        private void btnBack_Click(Form form, EventArgs e)
        {
            // Restaurar o layout padrão da MainForm
            RestoreMainFormLayout(form);
        }

        private void RestoreMainFormLayout(Form form)
        {
            // Limpar todos os controles existentes na MainForm
            form.Controls.Clear();

            // Configurar os controles conforme o layout padrão
            //form.InitializeComponent();

            // Atualizar o estado da variável indicando que o layout de clientes não está ativo
            isCustomerLayout = false;
        }

        private void btnCustomers_Click(Form form, EventArgs e)
        {
            string customerId = txtID.Text;
            string customerName = txtName.Text;

            // Lógica para determinar se é uma busca por ID ou uma adição
            if (!string.IsNullOrWhiteSpace(customerId))
            {
                CustomerLogic.SearchCustomerById(form, customerId);
            }
            else if (!string.IsNullOrWhiteSpace(customerName))
            {
                CustomerLogic.AddCustomer(form, customerName);
            }
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonState(sender, e);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonState(sender, e);
        }

        private void UpdateButtonState(object sender, EventArgs e)
        {
            string customerId = txtID.Text;
            string customerName = txtName.Text;

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                btnCustomers.Text = "Buscar por ID";
            }
            else if (!string.IsNullOrWhiteSpace(customerName))
            {
                btnCustomers.Text = "Adicionar";
            }
            else
            {
                btnCustomers.Text = "Listar Clientes"; // Texto padrão quando nenhum campo está preenchido
            }

            CustomerLogic.ProcessCustomerData((Form)sender, customerId, customerName, btnCustomers.Text);
        }
    }
}
