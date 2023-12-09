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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();

            // Adiciona o manipulador de evento para o clique em uma célula do DataGridView
            dataGridViewProduct.CellClick += DataGridViewProduct_CellClick;
            // Define o modo de somente leitura para o DataGridView
            dataGridViewProduct.ReadOnly = true;

            // Adiciona os manipuladores de evento TextChanged para os campos de texto
            txtSID.TextChanged += TxtCID_TextChanged;
            txtSName.TextChanged += TxtCName_TextChanged;

            // Adiciona o manipulador de evento KeyPress para aceitar apenas números no txtSID
            txtSID.KeyPress += TxtCID_KeyPress;

            // Define o texto inicial do botão com base nos valores dos campos de texto
            UpdateButtonText();

            // Adiciona o manipulador de evento Load
            this.Load += ProductForm_Load;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Fechar a janela ao clicar em "Voltar"
            this.Close();
        }


        private async void ProductForm_Load(object sender, EventArgs e)
        {
            // Carrega os dados dos clientes no ComboBox cBoxPClient
            await LoadCustomers();

            // Carrega os dados dos fornecedores no ComboBox cBoxPSupplier
            await LoadSuppliers();
        }

        private async Task LoadCustomers()
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

                        // Limpa e adiciona os clientes ao ComboBox
                        cBoxPClient.Items.Clear();
                        cBoxPClient.DisplayMember = "Name";
                        cBoxPClient.ValueMember = "CustomerId";
                        cBoxPClient.Items.AddRange(customers);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao carregar clientes: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}");
            }
        }

        private async Task LoadSuppliers()
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

                        // Limpa e adiciona os fornecedores ao ComboBox
                        cBoxPSupplier.Items.Clear();
                        cBoxPSupplier.DisplayMember = "Name";
                        cBoxPSupplier.ValueMember = "SupplierId";
                        cBoxPSupplier.Items.AddRange(suppliers);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao carregar fornecedores: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}");
            }
        }

        private async void btnMakeProduct_Click(object sender, EventArgs e)
        {
            string textProduct = btnMakeProduct.Text;

            if (textProduct == "Listar")
            {
                ListAllAsync();
            }
            else if (textProduct == "Buscar por Id")
            {
                ListByIdAsync(txtSID.Text);
            }
            else if (textProduct == "Adicionar")
            {
                await AddAsync(txtSName.Text);
            }
            else if (textProduct == "Editar")
            {
                await EditAsync(txtSID.Text, txtSName.Text);
            }
        }

        private async void ListByIdAsync(string id)
        {
            string apiUrl = "https://localhost:7056/api/product/" + id;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserializa o JSON para um objeto Product
                        var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

                        // Verifica se o objeto não é nulo
                        if (product != null)
                        {
                            // Obtém a fonte de dados atual do DataGridView, se existir
                            var dataSource = dataGridViewProduct.DataSource as List<Product>;

                            // Se não houver uma fonte de dados, crie uma nova lista
                            if (dataSource == null)
                            {
                                dataSource = new List<Product>();
                            }

                            // Adiciona o novo fornecedor à fonte de dados
                            dataSource.Add(product);

                            // Atualiza a fonte de dados do DataGridView
                            dataGridViewProduct.DataSource = null;
                            dataGridViewProduct.DataSource = dataSource;
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
            string apiUrl = "https://localhost:7056/api/product";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var products = JsonConvert.DeserializeObject<Product[]>(await response.Content.ReadAsStringAsync());
                        dataGridViewProduct.DataSource = products;
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
            string apiUrl = "https://localhost:7056/api/product";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um novo objeto Product com o nome fornecido
                    var newProduct = new Product { Name = name };

                    // Serializa o objeto Product para JSON
                    string jsonProduct = JsonConvert.SerializeObject(newProduct);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

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
            string apiUrl = "https://localhost:7056/api/product/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um objeto Product com o ID e o novo nome fornecidos
                    var updatedProduct = new Product { ProductId = int.Parse(id), Name = name };

                    // Serializa o objeto Product para JSON
                    string jsonProduct = JsonConvert.SerializeObject(updatedProduct);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

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
        private void DataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula válida e não no cabeçalho
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém os dados da linha clicada
                DataGridViewRow row = dataGridViewProduct.Rows[e.RowIndex];
                txtSID.Text = row.Cells["ProductId"].Value.ToString();
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
                btnMakeProduct.Text = "Listar";
            }
            else if (!isCIDEmpty && isCNameEmpty)
            {
                btnMakeProduct.Text = "Buscar por Id";
            }
            else if (isCIDEmpty && !isCNameEmpty)
            {
                btnMakeProduct.Text = "Adicionar";
            }
            else
            {
                btnMakeProduct.Text = "Editar";
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
