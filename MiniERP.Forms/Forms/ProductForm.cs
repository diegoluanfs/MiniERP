using MiniERP.Forms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
            cBoxPClient.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cBoxPSupplier.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            // Adiciona o manipulador de evento KeyPress para aceitar apenas números no txtSID
            txtSID.KeyPress += TxtCID_KeyPress;

            // Define o texto inicial do botão com base nos valores dos campos de texto
            UpdateButtonText();

            // Adiciona o manipulador de evento Load
            this.Load += ProductForm_Load;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilita o botão btnClean sempre que houver uma mudança em qualquer ComboBox
            btnClean.Enabled = true;

            // Atualiza o texto do botão
            UpdateButtonText();

            // Obtém o ComboBox que acionou o evento
            ComboBox comboBox = sender as ComboBox;

            // Verifica se o ComboBox não é nulo
            if (comboBox != null)
            {
                // Exibe uma mensagem com o valor selecionado no ComboBox
                //MessageBox.Show($"Opção selecionada: {comboBox.SelectedItem}");
            }
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

                        // Adiciona a opção em branco
                        cBoxPClient.Items.Add(new Customer { CustomerId = 0, Name = "-" });

                        cBoxPClient.DisplayMember = "IdAndName"; // Define a propriedade DisplayMember
                        cBoxPClient.ValueMember = "CustomerId";

                        // Cria uma lista de strings formatadas como "ID - Nome" para exibição
                        var displayItems = customers.Select(c => $"{c.CustomerId} - {c.Name}").ToArray();
                        cBoxPClient.Items.AddRange(displayItems);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao carregar clientes: {response.StatusCode} - {response.ReasonPhrase}");
                    }

                    cBoxPClient.Enabled = true;
                    cBoxPClient.DropDownStyle = ComboBoxStyle.DropDownList;
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

                        // Adiciona a opção em branco
                        cBoxPSupplier.Items.Add(new Supplier { SupplierId = 0, Name = "-" });

                        cBoxPSupplier.DisplayMember = "IdAndName"; // Define a propriedade DisplayMember
                        cBoxPSupplier.ValueMember = "SupplierId";

                        // Cria uma lista de strings formatadas como "ID - Nome" para exibição
                        var displayItems = suppliers.Select(s => $"{s.SupplierId} - {s.Name}").ToArray();
                        cBoxPSupplier.Items.AddRange(displayItems);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao carregar fornecedores: {response.StatusCode} - {response.ReasonPhrase}");
                    }

                    cBoxPSupplier.Enabled = true;
                    cBoxPSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
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
            else if (textProduct == "Adicionar")
            {
                // Obter valores selecionados nos ComboBox
                var selectedClientId = !string.IsNullOrEmpty(cBoxPClient.Text) ? Int32.Parse(cBoxPClient.Text[0].ToString()) : 0;
                var selectedSupplierId = !string.IsNullOrEmpty(cBoxPSupplier.Text) ? Int32.Parse(cBoxPSupplier.Text[0].ToString()) : 0;

                await AddAsync(txtSName.Text, selectedClientId, selectedSupplierId);
            }
            else if (textProduct == "Editar")
            {
                // Obter valores selecionados nos ComboBox
                var selectedClientId = !string.IsNullOrEmpty(cBoxPClient.Text) ? Int32.Parse(cBoxPClient.Text[0].ToString()) : 0;
                var selectedSupplierId = !string.IsNullOrEmpty(cBoxPSupplier.Text) ? Int32.Parse(cBoxPSupplier.Text[0].ToString()) : 0;

                await EditAsync(txtSID.Text, txtSName.Text, selectedClientId, selectedSupplierId);
            }
        }

        private async Task AddAsync(string name, int clientId, int supplierId)
        {
            string apiUrl = "https://localhost:7056/api/product";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um novo objeto Product com os dados fornecidos
                    var newProduct = new Product { Name = name, CustomerId = clientId, SupplierId = supplierId };

                    string productDetails = $"Name: {newProduct.Name}\nCustomer ID: {newProduct.CustomerId}\nSupplier ID: {newProduct.SupplierId}";

                    // Serializa o objeto Product para JSON
                    string jsonProduct = JsonConvert.SerializeObject(newProduct);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                    // Envia a requisição HTTP POST para adicionar um novo produto
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Produto adicionado com sucesso.");
                        // Atualiza a lista de produtos após adicionar um novo produto

                        txtSName.Text = "";
                        txtSID.Text = "";
                        btnClean.Enabled = false;
                        cBoxPClient.SelectedIndex = 0;
                        cBoxPSupplier.SelectedIndex = 0;

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

        private async Task EditAsync(string id, string name, int clientId, int supplierId)
        {
            string apiUrl = "https://localhost:7056/api/product/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cria um objeto Product com os dados fornecidos
                    var updatedProduct = new Product { ProductId = int.Parse(id), Name = name, CustomerId = clientId, SupplierId = supplierId };

                    // Serializa o objeto Product para JSON
                    string jsonProduct = JsonConvert.SerializeObject(updatedProduct);

                    // Cria um conteúdo JSON para a requisição
                    var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                    // Envia a requisição HTTP PUT para editar o produto existente
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Produto editado com sucesso.");
                        // Atualiza a lista de produtos após editar um produto existente
                        txtSName.Text = "";
                        txtSID.Text = "";
                        btnClean.Enabled = false;
                        cBoxPClient.SelectedIndex = 0;
                        cBoxPSupplier.SelectedIndex = 0;

                        ListAllAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase} \n " + content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
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

                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("ID", typeof(int));
                        dataTable.Columns.Add("Nome", typeof(string));
                        //dataTable.Columns.Add("Preço", typeof(decimal));
                        dataTable.Columns.Add("Cliente", typeof(string));
                        dataTable.Columns.Add("Fornecedor", typeof(string));

                        foreach (var product in products)
                        {
                            string customerInfo = $"{product.Customer.CustomerId} - {product.Customer.Name}";
                            string supplierInfo = $"{product.Supplier.SupplierId} - {product.Supplier.Name}";

                            dataTable.Rows.Add(product.ProductId, product.Name, customerInfo, supplierInfo);
                        }

                        dataGridViewProduct.DataSource = dataTable;
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

        private void DataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma célula válida e não no cabeçalho
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém os dados da linha clicada
                DataGridViewRow row = dataGridViewProduct.Rows[e.RowIndex];

                // Obtém os valores das colunas desejadas
                string productId = row.Cells["Id"].Value.ToString();
                string name = row.Cells["Nome"].Value.ToString();
                string customerId = row.Cells["Cliente"].Value.ToString();
                string supplierId = row.Cells["Fornecedor"].Value.ToString();

                // Atribui os valores aos campos de texto
                txtSID.Text = productId;
                txtSName.Text = name;

                // Seleciona os itens nos ComboBox correspondentes
                SelectItemInComboBox(cBoxPClient, customerId);
                SelectItemInComboBox(cBoxPSupplier, supplierId);
            }
        }

        // Método auxiliar para selecionar um item no ComboBox com base no valor
        private void SelectItemInComboBox(ComboBox comboBox, string value)
        {
            foreach (var item in comboBox.Items)
            {
                // Assumindo que o formato do item é "ID - Nome"
                if (item.ToString().StartsWith(value))
                {
                    comboBox.SelectedItem = item;
                    break;
                }
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
            bool isCBoxPClientSelected = cBoxPClient.SelectedItem != null && cBoxPClient.SelectedIndex != 0; // Verifica se não é a opção em branco
            bool isCBoxPSupplierSelected = cBoxPSupplier.SelectedItem != null && cBoxPSupplier.SelectedIndex != 0; // Verifica se não é a opção em branco

            if (isCIDEmpty && !isCNameEmpty && isCBoxPClientSelected && isCBoxPSupplierSelected)
            {
                btnMakeProduct.Text = "Adicionar";
                btnClean.Enabled = true;
            }
            else if (!isCIDEmpty && !isCNameEmpty && isCBoxPClientSelected && isCBoxPSupplierSelected)
            {
                btnMakeProduct.Text = "Editar";
                btnClean.Enabled = true;
            }
            else
            {
                btnMakeProduct.Text = "Listar";
                btnClean.Enabled = false;
            }
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

            // Limpa os ComboBoxes
            cBoxPClient.SelectedIndex = 0; // Opção em branco
            cBoxPSupplier.SelectedIndex = 0; // Opção em branco

            // Atualiza o estado do botão btnClean
            UpdateButtonText();
        }

    }
}
