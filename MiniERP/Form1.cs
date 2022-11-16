using MiniERP.Entidades;

namespace MiniERP
{
    public partial class Form1 : Form
    {
        string titulo;

        public Form1()
        {
            InitializeComponent();
            titulo = "";
        }

        public Form1(string usuario)
        {
            InitializeComponent();
            titulo = "Olá " + usuario + ", seja bem vind@";
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Produtos";
            titulo = lblTitulo.Text;
            lblTitulo.Visible = true;
            ConfigurarGradeProdutos();
            PopularGradeProdutos();
        }

        private void PopularGradeProdutos()
        {
            var listaProdutos = Produtos.GetListaProdutos();

            foreach (Produtos produto in listaProdutos)
            {
                listView1.Items.Add(new ListViewItem(new String[] {produto.Id.ToString(),
                produto.Nome, produto.QtdEstoque.ToString(), produto.Preco.ToString("N2"),
                produto.Fornecedor}));
            }
        }

        private void ConfigurarGradeProdutos()
        {
            listView1.Clear();
            listView1.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Nome", 120).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Qtd. Estoque", 120).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Preço", 120).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Fornecedor", 120).TextAlign = HorizontalAlignment.Center;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = true;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            lblTitulo.Text = "Fornecedores";
            titulo = lblTitulo.Text;
            lblTitulo.Visible = true;
            ConfigurarGradeFornecedores();
            PopularGradeFornecedore();

        }
        private void PopularGradeFornecedore()
        {
            var listaFornecedores = Fornecedores.GetListaFornecedores();

            foreach (Fornecedores Fornecedore in listaFornecedores)
            {
                listView1.Items.Add(new ListViewItem(new String[] {Fornecedore.Id.ToString(),
                Fornecedore.Nome, Fornecedore.Contato}));
            }
        }


        private void ConfigurarGradeFornecedores()
        {
            listView1.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Contato", 250).TextAlign = HorizontalAlignment.Center;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = true;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            lblTitulo.Text = "Clientes";
            titulo = lblTitulo.Text;
            lblTitulo.Visible = true;
            ConfigurarGradeClientes();
            PopularGradeCliente();
        }

        private void PopularGradeCliente()
        {
            var listaClientes = Clientes.GetListaClientes();

            foreach (Clientes cliente in listaClientes)
            {
                listView1.Items.Add(new ListViewItem(new String[] {cliente.Id.ToString(),
                cliente.Nome, cliente.Contato}));
            }
        }

        private void ConfigurarGradeClientes()
        {
            listView1.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Contato", 250).TextAlign = HorizontalAlignment.Center;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            titulo = lblTitulo.Text;
            lblTitulo.Text = "Cadastros";
            listView1.Visible = false;
            panelCadastro.Visible = true;
            panelCadastro.Enabled = true;
            panelMain.Enabled = false;
            btnCadastrar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
        private void Cancelar()
        {
            lblTitulo.Text = titulo;
            panelCadastro.Visible = false;
            panelCadastro.Enabled = false;
            listView1.Visible = true;
            panelMain.Enabled = true;
            btnCadastrar.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cancelar();
        }
    }
}