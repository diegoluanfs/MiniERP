using MiniERP.Forms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.Forms.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();

            // Adiciona o manipulador de evento para o clique em uma célula do DataGridView
            dataGridViewCustomer.CellClick += DataGridViewCustomer_CellClick;
            // Define o modo de somente leitura para o DataGridView
            dataGridViewCustomer.ReadOnly = true;

            // Adiciona os manipuladores de evento TextChanged para os campos de texto
            txtCID.TextChanged += TxtCID_TextChanged;
            txtCName.TextChanged += TxtCName_TextChanged;

            // Adiciona o manipulador de evento KeyPress para aceitar apenas números no txtCID
            txtCID.KeyPress += TxtCID_KeyPress;

            // Define o texto inicial do botão com base nos valores dos campos de texto
            UpdateButtonText();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Fechar a janela ao clicar em "Voltar"
            this.Close();
        }

        private async void btnMakeCustomer_Click(object sender, EventArgs e)
        {
            string textCustomer = btnMakeCustomer.Text;

            if (textCustomer == "Listar")
            {
                ListAllAsync();
            }
            else if (textCustomer == "Buscar por Id")
            {
                ListByIdAsync(txtCID.Text);
            }
            else if (textCustomer == "Adicionar")
            {
                await AddAsync(txtCName.Text);
            }
            else if (textCustomer == "Editar")
            {
                await EditAsync(txtCID.Text, txtCName.Text);
            }
        }

        private async void ListByIdAsync(string id)
        {
            string apiUrl = "https://localhost:7056/api/customer/" + id;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserializa o JSON para um objeto Customer
                        var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());

                        // Verifica se o objeto não é nulo
                        if (customer != null)
                        {
                            // Obtém a fonte de dados atual do DataGridView, se existir
                            var dataSource = dataGridViewCustomer.DataSource as List<Customer>;

                            // Se não houver uma fonte de dados, crie uma nova lista
                            if (dataSource == null)
                            {
                                dataSource = new List<Customer>();
                            }

                            // Adiciona o novo cliente à fonte de dados
                            dataSource.Add(customer);

                            // Atualiza a fonte de dados do DataGridView
                            dataGridViewCustomer.DataSource = null;
                            dataGridViewCustomer.DataSource = dataSource;
                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private async void ListAllAsync()
        {
            string apiUrl = "https://localhost:7056/api/customer";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var customers = JsonConvert.DeserializeObject<Customer[]>(await response.Content.ReadAsStringAsync());
                        dataGridViewCustomer.DataSource = customers;
                    }
                    else
                    {
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private async Task AddAsync(string name)
        {
            string apiUrl = "https://localhost:7056/api/customer";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um novo objeto Customer com o nome fornecido
                    var newCustomer = new Customer { Name = name };

                    // Serializa o objeto Customer para JSON
                    string jsonCustomer = JsonConvert.SerializeObject(newCustomer);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                    // Envia a requisição HTTP POST para adicionar um novo cliente
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cliente adicionado com sucesso.");
                        // Atualiza a lista de clientes após adicionar um novo cliente
                        ListAllAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private async Task EditAsync(string id, string name)
        {
            string apiUrl = "https://localhost:7056/api/customer/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um objeto Customer com o ID e o novo nome fornecidos
                    var updatedCustomer = new Customer { CustomerId = int.Parse(id), Name = name };

                    // Serializa o objeto Customer para JSON
                    string jsonCustomer = JsonConvert.SerializeObject(updatedCustomer);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                    // Envia a requisição HTTP PUT para editar o cliente existente
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cliente editado com sucesso.");
                        // Atualiza a lista de clientes após editar um cliente existente
                        txtCName.Text = "";
                        txtCID.Text = "";
                        btnClean.Enabled = false;

                        ListAllAsync();

                    }
                    else
                    {
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase} \n "+ content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        // Manipulador de evento para o clique em uma célula do DataGridView
        private void DataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula válida e não no cabeçalho
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém os dados da linha clicada
                DataGridViewRow row = dataGridViewCustomer.Rows[e.RowIndex];
                txtCID.Text = row.Cells["CustomerId"].Value.ToString();
                txtCName.Text = row.Cells["Name"].Value.ToString();
            }
        }

        private void TxtCID_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonText();
        }

        private void TxtCName_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonText();
        }
        private void UpdateButtonText()
        {
            bool isCIDEmpty = string.IsNullOrWhiteSpace(txtCID.Text);
            bool isCNameEmpty = string.IsNullOrWhiteSpace(txtCName.Text);

            if (isCIDEmpty && isCNameEmpty)
            {
                btnMakeCustomer.Text = "Listar";
            }
            else if (!isCIDEmpty && isCNameEmpty)
            {
                btnMakeCustomer.Text = "Buscar por Id";
            }
            else if (isCIDEmpty && !isCNameEmpty)
            {
                btnMakeCustomer.Text = "Adicionar";
            }
            else
            {
                btnMakeCustomer.Text = "Editar";
            }

            // Habilita ou desabilita o botão btnClean com base nos campos txtCID e txtCName
            btnClean.Enabled = !isCIDEmpty || !isCNameEmpty;
        }

        private void TxtCID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e tecla Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtCName.Text = "";
            txtCID.Text = "";

            // Atualiza o estado do botão btnClean
            UpdateButtonText();
        }

    }
}
