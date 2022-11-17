namespace MiniERP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnFornecedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelCadastro = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tBFornecedorNome = new System.Windows.Forms.TextBox();
            this.tBFornecedorContato = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tBClienteNome = new System.Windows.Forms.TextBox();
            this.tBClienteContato = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.tBProdutoPreco = new System.Windows.Forms.TextBox();
            this.cBoxFornecedor = new System.Windows.Forms.ComboBox();
            this.tBProdutoNome = new System.Windows.Forms.TextBox();
            this.tBProdutoQtd = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelCadastro.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(0, 155);
            this.btnProdutos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(234, 40);
            this.btnProdutos.TabIndex = 0;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnFornecedores
            // 
            this.btnFornecedores.Location = new System.Drawing.Point(0, 195);
            this.btnFornecedores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFornecedores.Name = "btnFornecedores";
            this.btnFornecedores.Size = new System.Drawing.Size(234, 40);
            this.btnFornecedores.TabIndex = 1;
            this.btnFornecedores.Text = "Fornecedores";
            this.btnFornecedores.UseVisualStyleBackColor = true;
            this.btnFornecedores.Click += new System.EventHandler(this.btnFornecedores_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(0, 235);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(234, 40);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMain.Controls.Add(this.btnSair);
            this.panelMain.Controls.Add(this.btnClientes);
            this.panelMain.Controls.Add(this.btnProdutos);
            this.panelMain.Controls.Add(this.btnFornecedores);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(234, 599);
            this.panelMain.TabIndex = 6;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(0, 559);
            this.btnSair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(234, 40);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // listViewMain
            // 
            this.listViewMain.Location = new System.Drawing.Point(245, 155);
            this.listViewMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(659, 443);
            this.listViewMain.TabIndex = 7;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Enabled = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(245, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(205, 89);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.Visible = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(746, 69);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(155, 49);
            this.btnCadastrar.TabIndex = 9;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelCadastro
            // 
            this.panelCadastro.Controls.Add(this.groupBox3);
            this.panelCadastro.Controls.Add(this.groupBox2);
            this.panelCadastro.Controls.Add(this.groupBox1);
            this.panelCadastro.Enabled = false;
            this.panelCadastro.Location = new System.Drawing.Point(243, 143);
            this.panelCadastro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCadastro.Name = "panelCadastro";
            this.panelCadastro.Size = new System.Drawing.Size(661, 447);
            this.panelCadastro.TabIndex = 10;
            this.panelCadastro.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.tBFornecedorNome);
            this.groupBox3.Controls.Add(this.tBFornecedorContato);
            this.groupBox3.Location = new System.Drawing.Point(334, 217);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(321, 161);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fornecedores";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(61, 85);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(194, 85);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "Salvar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tBFornecedorNome
            // 
            this.tBFornecedorNome.Location = new System.Drawing.Point(8, 29);
            this.tBFornecedorNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBFornecedorNome.Name = "tBFornecedorNome";
            this.tBFornecedorNome.PlaceholderText = "Nome";
            this.tBFornecedorNome.Size = new System.Drawing.Size(138, 27);
            this.tBFornecedorNome.TabIndex = 0;
            // 
            // tBFornecedorContato
            // 
            this.tBFornecedorContato.Location = new System.Drawing.Point(171, 29);
            this.tBFornecedorContato.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBFornecedorContato.Name = "tBFornecedorContato";
            this.tBFornecedorContato.PlaceholderText = "Contato";
            this.tBFornecedorContato.Size = new System.Drawing.Size(138, 27);
            this.tBFornecedorContato.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tBClienteNome);
            this.groupBox2.Controls.Add(this.tBClienteContato);
            this.groupBox2.Location = new System.Drawing.Point(6, 217);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(321, 161);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clientes";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 85);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(194, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 40);
            this.button2.TabIndex = 4;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tBClienteNome
            // 
            this.tBClienteNome.Location = new System.Drawing.Point(8, 29);
            this.tBClienteNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBClienteNome.Name = "tBClienteNome";
            this.tBClienteNome.PlaceholderText = "Nome";
            this.tBClienteNome.Size = new System.Drawing.Size(138, 27);
            this.tBClienteNome.TabIndex = 0;
            // 
            // tBClienteContato
            // 
            this.tBClienteContato.Location = new System.Drawing.Point(171, 29);
            this.tBClienteContato.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBClienteContato.Name = "tBClienteContato";
            this.tBClienteContato.PlaceholderText = "Contato";
            this.tBClienteContato.Size = new System.Drawing.Size(138, 27);
            this.tBClienteContato.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnSalvarProduto);
            this.groupBox1.Controls.Add(this.tBProdutoPreco);
            this.groupBox1.Controls.Add(this.cBoxFornecedor);
            this.groupBox1.Controls.Add(this.tBProdutoNome);
            this.groupBox1.Controls.Add(this.tBProdutoQtd);
            this.groupBox1.Location = new System.Drawing.Point(5, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(653, 161);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produtos";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(389, 87);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.Location = new System.Drawing.Point(522, 87);
            this.btnSalvarProduto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(114, 40);
            this.btnSalvarProduto.TabIndex = 4;
            this.btnSalvarProduto.Text = "Salvar";
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
            this.btnSalvarProduto.Click += new System.EventHandler(this.btnSalvarProduto_Click);
            // 
            // tBProdutoPreco
            // 
            this.tBProdutoPreco.Location = new System.Drawing.Point(335, 29);
            this.tBProdutoPreco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBProdutoPreco.Name = "tBProdutoPreco";
            this.tBProdutoPreco.PlaceholderText = "Preço";
            this.tBProdutoPreco.Size = new System.Drawing.Size(138, 27);
            this.tBProdutoPreco.TabIndex = 2;
            // 
            // cBoxFornecedor
            // 
            this.cBoxFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxFornecedor.FormattingEnabled = true;
            this.cBoxFornecedor.Location = new System.Drawing.Point(498, 29);
            this.cBoxFornecedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxFornecedor.Name = "cBoxFornecedor";
            this.cBoxFornecedor.Size = new System.Drawing.Size(138, 28);
            this.cBoxFornecedor.TabIndex = 3;
            this.cBoxFornecedor.SelectedIndexChanged += new System.EventHandler(this.cBoxFornecedor_SelectedIndexChanged);
            // 
            // tBProdutoNome
            // 
            this.tBProdutoNome.Location = new System.Drawing.Point(8, 29);
            this.tBProdutoNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBProdutoNome.Name = "tBProdutoNome";
            this.tBProdutoNome.PlaceholderText = "Nome";
            this.tBProdutoNome.Size = new System.Drawing.Size(138, 27);
            this.tBProdutoNome.TabIndex = 0;
            // 
            // tBProdutoQtd
            // 
            this.tBProdutoQtd.Location = new System.Drawing.Point(171, 29);
            this.tBProdutoQtd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBProdutoQtd.Name = "tBProdutoQtd";
            this.tBProdutoQtd.PlaceholderText = "Quantidade";
            this.tBProdutoQtd.Size = new System.Drawing.Size(138, 27);
            this.tBProdutoQtd.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelCadastro);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMain.ResumeLayout(false);
            this.panelCadastro.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnProdutos;
        private Button btnFornecedores;
        private Button btnClientes;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Panel panelMain;
        private Button btnSair;
        private ListView listViewMain;
        private Label lblTitulo;
        private Button btnCadastrar;
        private OpenFileDialog openFileDialog1;
        private Panel panelCadastro;
        private TextBox tBProdutoQtd;
        private TextBox tBProdutoNome;
        private GroupBox groupBox1;
        private Button btnCancelar;
        private Button btnSalvarProduto;
        private TextBox tBProdutoPreco;
        private ComboBox cBoxFornecedor;
        private GroupBox groupBox3;
        private Button button3;
        private Button button4;
        private TextBox tBFornecedorNome;
        private TextBox tBFornecedorContato;
        private GroupBox groupBox2;
        private Button button1;
        private Button button2;
        private TextBox tBClienteNome;
        private TextBox tBClienteContato;
    }
}