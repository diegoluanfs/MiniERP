using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.Conectar();
        }

        private string conexaoString;
        private void Conectar()
        {
            try
            {
                string usuario = textBoxUsuario.Text;
                string senha = textBoxSenha.Text;
                conexaoString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=aula;" +
                    "User ID=" + usuario + ";" +
                    "password=" + senha + ";" +
                    "language=Portuguese";
                SqlConnection conexao = new SqlConnection(conexaoString);
                conexao.Open();

                this.Visible = false;

                Form1 forms = new Form1(conexaoString);
                forms.ShowDialog();

                this.Visible = true;

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexão com o Banco " + ex.Message, "Alerta");
            }
        }
    }
}
