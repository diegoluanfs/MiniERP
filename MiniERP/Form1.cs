using MiniERP.Entidades;
using System.CodeDom;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using System.Drawing.Printing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;

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
            listViewMain.Visible = true;
            painelNotas.Visible = false;

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

        private void ConfigurarGradeNotas()
        {
            listViewNotas.Clear();
            listViewNotas.Columns.Add("Id", 50).TextAlign = HorizontalAlignment.Center;
            listViewNotas.Columns.Add("Cliente", 120).TextAlign = HorizontalAlignment.Center;
            listViewNotas.Columns.Add("Produto", 120).TextAlign = HorizontalAlignment.Center;
            listViewNotas.Columns.Add("Quantidade", 120).TextAlign = HorizontalAlignment.Center;
            listViewNotas.Columns.Add("Preço", 120).TextAlign = HorizontalAlignment.Center;
            listViewNotas.Columns.Add("Total", 120).TextAlign = HorizontalAlignment.Center;

            listViewNotas.View = View.Details;
            listViewNotas.FullRowSelect = true;
            listViewNotas.GridLines = true;
            listViewNotas.MultiSelect = true;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            listViewMain.Clear();
            lblTitulo.Text = "Fornecedores";
            titulo = lblTitulo.Text;
            lblTitulo.Visible = true;
            listViewMain.Visible = true;
            painelNotas.Visible = false;

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
            listViewMain.Visible = true;
            painelNotas.Visible = false;

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
            panelCadastros.Visible = true;
            panelCadastros.Enabled = true;
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

            String[] strlist = cBoxFornecedor.Text.Split("-");

            int fornecedor = Int32.Parse(strlist[0]);

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

                string sqlTexto = "INSERT INTO TB_PROVIDERS([NAME], [CONTACT])VALUES('" + nome + "','" + contato + "')";
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

        private void PegarClientes()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"SELECT CONCAT(ID, ' - ',  NAME) AS NAME FROM TB_CLIENTS";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(leitor);
                cBoxClientesNotas.DisplayMember = "NAME";
                cBoxClientesNotas.DataSource = dt;

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void PegarProdutos()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"SELECT CONCAT(ID, ' - ',  NAME) AS NAME FROM TB_PRODUCTS";
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(leitor);
                cBoxProdutosNotas.DisplayMember = "NAME";
                cBoxProdutosNotas.DataSource = dt;

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            id = 0;
            titulo = lblTitulo.Text;
            lblTitulo.Text = "Notas";
            listViewMain.Visible = false;
            panelCadastro.Visible = false;
            panelCadastro.Enabled = false;
            panelMain.Enabled = true;
            painelNotas.Visible = true;
            painelNotas.Enabled = true;

            PegarClientes();
            PegarProdutos();

            ConfigurarGradeNotas();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxProdutosNotas.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTitulo.Text = "Notas";
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

        private void cBProdutosNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tBQtdNotas.Enabled = true;
        }

        private void tBQtdNotas_TextChanged(object sender, EventArgs e)
        {
            btnLancarNotas.Enabled = true;
        }

        int id = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            string clientes;
            string produtos;
            int qtd = Int32.Parse(tBQTDNota.Text.ToString());

            int verificaQTD = PegarQtd(Int32.Parse(cBoxProdutosNotas.Text.Split(' ')[0]));

            if (qtd > verificaQTD)
            {
                throw new Exception();
            }
            try
            {
                decimal valor = 0;

                ListViewItem item = new ListViewItem();
                item.Text = id.ToString();
                item.SubItems.Add(cBoxClientesNotas.Text.ToString());
                item.SubItems.Add(cBoxProdutosNotas.Text.ToString());
                item.SubItems.Add(qtd.ToString());
                int idProduto = Int32.Parse(cBoxProdutosNotas.Text.Split(' ')[0]);
                valor = PegarValor(idProduto);
                item.SubItems.Add(valor.ToString());
                item.SubItems.Add((valor * qtd).ToString());
                //item.SubItems.Add(leitor["id_provider"].ToString());
                listViewNotas.Items.Add(item);
                id++;
            }
            catch
            {

            }
        }
        private int PegarQtd(int idProduto)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"SELECT QUANTITY FROM TB_PRODUCTS WHERE ID = " + idProduto;
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                int valor = 0;
                string strValor = "";

                while (leitor.Read())
                {
                    strValor = leitor["quantity"].ToString();
                }

                valor = Int32.Parse(strValor);

                conexao.Close();
                return valor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quantidade solicitada maior que a quantidade no estoque", "Alerta");
                return -1;
            }
        }

        private decimal PegarValor(int id)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                string sqlTexto = @"SELECT PRICE FROM TB_PRODUCTS WHERE ID = " + id;
                SqlCommand comando = new SqlCommand(sqlTexto, conexao);
                SqlDataReader leitor = comando.ExecuteReader();

                decimal valor = 0;
                string strValor = "";

                while (leitor.Read())
                {
                    strValor = leitor["price"].ToString();
                }

                valor = decimal.Parse(strValor);

                conexao.Close();
                return valor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
                return -1;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int qtdDados = listViewNotas.Items.Count;
            ImprimirArquivo();
        }

        private void ImprimirArquivo()
        {
            Document doc = new Document(PageSize.A4);//criando e
            //estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o
            //espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //caminho onde sera criado o pdf + nome desejado
            //OBS: o nome sempre deve ser terminado com .pdf
            string caminho = @"C:\Atos\" + "teste.pdf";

            //criando o arquivo pdf embranco, passando como parametro
            //da variavel
            //doc criada acima e a variavel caminho
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new
            FileStream(caminho, FileMode.Create));

            doc.Open();

            //criando uma string vazia
            string dados = "";

            //criando a variavel para paragrafo
            Paragraph paragrafo = new Paragraph(dados);
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
            //Alinhamento Justificado
            //adicioando texto
            paragrafo.Add("Nota do cliente " + listViewNotas.Items[1]);
            int cont = 0;

            do
            {
                string frase = "Produto: " + listViewNotas.Items[0] +
                    "; Quantidade: " + listViewNotas.Items[1] +
                    "; Valor: " + listViewNotas.Items[2];

                paragrafo.Add(frase);

            } while (listViewNotas.Items.Count > cont) ;

            //acidionado paragrafo ao documento
            doc.Add(paragrafo);
            //fechando documento para que seja salva as
            //alteraçoes.
            doc.Close();

        }
    }
}