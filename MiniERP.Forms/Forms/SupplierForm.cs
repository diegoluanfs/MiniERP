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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();

            // Adiciona o manipulador de evento para o clique em uma célula do DataGridView
            dataGridViewSupplier.CellClick += DataGridViewSupplier_CellClick;
            // Define o modo de somente leitura para o DataGridView
            dataGridViewSupplier.ReadOnly = true;

            // Adiciona os manipuladores de evento TextChanged para os campos de texto
            txtSID.TextChanged += TxtCID_TextChanged;
            txtSName.TextChanged += TxtCName_TextChanged;

            // Adiciona o manipulador de evento KeyPress para aceitar apenas números no txtSID
            txtSID.KeyPress += TxtCID_KeyPress;

            // Define o texto inicial do botão com base nos valores dos campos de texto
            UpdateButtonText();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Fechar a janela ao clicar em "Voltar"
            this.Close();
        }

        private async void btnMakeSupplier_Click(object sender, EventArgs e)
        {
            string textSupplier = btnMakeSupplier.Text;

            if (textSupplier == "Listar")
            {
                ListAllAsync();
            }
            else if (textSupplier == "Buscar por Id")
            {
                ListByIdAsync(txtSID.Text);
            }
            else if (textSupplier == "Adicionar")
            {
                await AddAsync(txtSName.Text);
            }
            else if (textSupplier == "Editar")
            {
                await EditAsync(txtSID.Text, txtSName.Text);
            }
        }

        private async void ListByIdAsync(string id)
        {
            string apiUrl = "https://localhost:7056/api/supplier/" + id;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserializa o JSON para um objeto Supplier
                        var supplier = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());

                        // Verifica se o objeto não é nulo
                        if (supplier != null)
                        {
                            // Obtém a fonte de dados atual do DataGridView, se existir
                            var dataSource = dataGridViewSupplier.DataSource as List<Supplier>;

                            // Se não houver uma fonte de dados, crie uma nova lista
                            if (dataSource == null)
                            {
                                dataSource = new List<Supplier>();
                            }

                            // Adiciona o novo fornecedor à fonte de dados
                            dataSource.Add(supplier);

                            // Atualiza a fonte de dados do DataGridView
                            dataGridViewSupplier.DataSource = null;
                            dataGridViewSupplier.DataSource = dataSource;
                        }
                        else
                        {
                            MessageBox.Show("Fornecedor não encontrado.");
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
            string apiUrl = "https://localhost:7056/api/supplier";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var suppliers = JsonConvert.DeserializeObject<Supplier[]>(await response.Content.ReadAsStringAsync());
                        dataGridViewSupplier.DataSource = suppliers;
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
            string apiUrl = "https://localhost:7056/api/supplier";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um novo objeto Supplier com o nome fornecido
                    var newSupplier = new Supplier { Name = name };

                    // Serializa o objeto Supplier para JSON
                    string jsonSupplier = JsonConvert.SerializeObject(newSupplier);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonSupplier, Encoding.UTF8, "application/json");

                    // Envia a requisição HTTP POST para adicionar um novo fornecedor
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Fornecedor adicionado com sucesso.");
                        // Atualiza a lista de fornecedores após adicionar um novo fornecedor
                        txtSName.Text = "";
                        txtSID.Text = "";
                        btnClean.Enabled = false;

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
            string apiUrl = "https://localhost:7056/api/supplier/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um objeto Supplier com o ID e o novo nome fornecidos
                    var updatedSupplier = new Supplier { SupplierId = int.Parse(id), Name = name };

                    // Serializa o objeto Supplier para JSON
                    string jsonSupplier = JsonConvert.SerializeObject(updatedSupplier);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonSupplier, Encoding.UTF8, "application/json");

                    // Envia a requisição HTTP PUT para editar o fornecedor existente
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Fornecedor editado com sucesso.");
                        // Atualiza a lista de fornecedors após editar um fornecedor existente
                        txtSName.Text = "";
                        txtSID.Text = "";
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
        private void DataGridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula válida e não no cabeçalho
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém os dados da linha clicada
                DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];
                txtSID.Text = row.Cells["SupplierId"].Value.ToString();
                txtSName.Text = row.Cells["Name"].Value.ToString();
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
            bool isCIDEmpty = string.IsNullOrWhiteSpace(txtSID.Text);
            bool isCNameEmpty = string.IsNullOrWhiteSpace(txtSName.Text);

            if (isCIDEmpty && isCNameEmpty)
            {
                btnMakeSupplier.Text = "Listar";
            }
            else if (!isCIDEmpty && isCNameEmpty)
            {
                btnMakeSupplier.Text = "Buscar por Id";
            }
            else if (isCIDEmpty && !isCNameEmpty)
            {
                btnMakeSupplier.Text = "Adicionar";
            }
            else
            {
                btnMakeSupplier.Text = "Editar";
            }

            // Habilita ou desabilita o botão btnClean com base nos campos txtSID e txtSName
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
            txtSName.Text = "";
            txtSID.Text = "";

            // Atualiza o estado do botão btnClean
            UpdateButtonText();
        }

    }
}
