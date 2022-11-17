using MiniERP.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace MiniERP
{
    public partial class Form1 : Form
    {
        string conexaoString;
        string titulo;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string conexao)
        {
            InitializeComponent();
            conexaoString = conexao;
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

            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = "select * from tb_products";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                listViewMain.Items.Clear();
                int i = 0;
                while (leitor.Read())
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = leitor["id"].ToString();
                    item.SubItems.Add(leitor["name"].ToString());
                    item.SubItems.Add(leitor["quantity"].ToString());
                    item.SubItems.Add(leitor["price"].ToString());
                    item.SubItems.Add(leitor["id_provider"].ToString());
                    listViewMain.Items.Add(item);

                    i++;
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void ConfigurarGradeProdutos()
        {
            listViewMain.Clear();
            listViewMain.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Nome", 120).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Qtd. Estoque", 120).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Preço", 120).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Fornecedor", 120).TextAlign = HorizontalAlignment.Center;

            listViewMain.View = View.Details;
            listViewMain.FullRowSelect = true;
            listViewMain.GridLines = true;
            listViewMain.MultiSelect = true;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            listViewMain.Clear();
            lblTitulo.Text = "Fornecedores";
            titulo = lblTitulo.Text;
            lblTitulo.Visible = true;
            ConfigurarGradeFornecedores();

            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = "select * from tb_providers";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                listViewMain.Items.Clear();
                int i = 0;
                while (leitor.Read())
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = leitor["id"].ToString();
                    item.SubItems.Add(leitor["name"].ToString());
                    item.SubItems.Add(leitor["contact"].ToString());
                    listViewMain.Items.Add(item);

                    i++;
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void ConfigurarGradeFornecedores()
        {
            listViewMain.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Contato", 250).TextAlign = HorizontalAlignment.Center;

            listViewMain.View = View.Details;
            listViewMain.FullRowSelect = true;
            listViewMain.GridLines = true;
            listViewMain.MultiSelect = true;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            listViewMain.Clear();
            lblTitulo.Text = "Clientes";
            titulo = lblTitulo.Text;
            lblTitulo.Visible = true;
            ConfigurarGradeClientes();
            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = "select * from tb_clients";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                listViewMain.Items.Clear();
                int i = 0;
                while (leitor.Read())
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = leitor["id"].ToString();
                    item.SubItems.Add(leitor["name"].ToString());
                    item.SubItems.Add(leitor["contact"].ToString());
                    listViewMain.Items.Add(item);

                    i++;
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void ConfigurarGradeClientes()
        {
            listViewMain.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listViewMain.Columns.Add("Contato", 250).TextAlign = HorizontalAlignment.Center;

            listViewMain.View = View.Details;
            listViewMain.FullRowSelect = true;
            listViewMain.GridLines = true;
            listViewMain.MultiSelect = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            titulo = lblTitulo.Text;
            lblTitulo.Text = "Cadastros";
            listViewMain.Visible = false;
            panelCadastro.Visible = true;
            panelCadastro.Enabled = true;
            panelMain.Enabled = false;
            btnCadastrar.Enabled = false;

            PegarFornecedores();

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
            listViewMain.Visible = true;
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

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            string nome = tBProdutoNome.Text;
            string qtd = tBProdutoQtd.Text;
            string preco = tBProdutoPreco.Text;
            int fornecedor = Int32.Parse(cBoxFornecedor.Text);

            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"INSERT INTO TB_PRODUCTS([NAME], [QUANTITY], [PRICE], [ID_PROVIDER])
                VALUES('" + nome + "','" + qtd + "','" + preco + "','" + fornecedor + "')";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                conexao.Close();

                tBProdutoNome.Clear();
                tBProdutoQtd.Clear();
                tBProdutoPreco.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nome = tBFornecedorNome.Text;
            string contato = tBFornecedorContato.Text;

            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = "INSERT INTO TB_PROVIDERS([NAME], [CONTACT])VALUES('"+nome+"','"+contato+"')";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                conexao.Close();

                tBFornecedorNome.Clear();
                tBFornecedorContato.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = tBClienteNome.Text;
            string contato = tBClienteContato.Text;

            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"INSERT INTO TB_CLIENTS([NAME], [CONTACT])VALUES('" + nome + "','" + contato + "')";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                conexao.Close();

                tBClienteNome.Clear();
                tBClienteContato.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void cBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cBoxFornecedor_Click(object sender, EventArgs e)
        {
            PegarFornecedores();
        }

        private void PegarFornecedores()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"SELECT CONCAT(ID, ' - ',  NAME) AS NAME FROM TB_PROVIDERS";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(leitor);
                cBoxFornecedor.DisplayMember = "NAME";
                cBoxFornecedor.DataSource = dt;

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }
    }
}