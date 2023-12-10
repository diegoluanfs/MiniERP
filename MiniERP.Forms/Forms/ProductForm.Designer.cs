namespace MiniERP.Forms.Forms
{
    partial class ProductForm:Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMakeProduct = new System.Windows.Forms.Button();
            this.lblCID = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.btnClean = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxPClient = new System.Windows.Forms.ComboBox();
            this.cBoxPSupplier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(23, 23);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 50);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMakeProduct
            // 
            this.btnMakeProduct.Location = new System.Drawing.Point(416, 112);
            this.btnMakeProduct.Name = "btnMakeProduct";
            this.btnMakeProduct.Size = new System.Drawing.Size(162, 29);
            this.btnMakeProduct.TabIndex = 3;
            this.btnMakeProduct.Text = "Listar";
            this.btnMakeProduct.UseVisualStyleBackColor = true;
            this.btnMakeProduct.Click += new System.EventHandler(this.btnMakeProduct_Click);
            // 
            // lblCID
            // 
            this.lblCID.AutoSize = true;
            this.lblCID.Location = new System.Drawing.Point(40, 84);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new System.Drawing.Size(24, 20);
            this.lblCID.TabIndex = 4;
            this.lblCID.Text = "ID";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(123, 85);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(129, 20);
            this.lblCName.TabIndex = 5;
            this.lblCName.Text = "Nome do Produto";
            // 
            // txtSID
            // 
            this.txtSID.Location = new System.Drawing.Point(40, 113);
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(50, 27);
            this.txtSID.TabIndex = 6;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(123, 114);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(272, 27);
            this.txtSName.TabIndex = 7;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(40, 157);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.RowHeadersWidth = 51;
            this.dataGridViewProduct.RowTemplate.Height = 29;
            this.dataGridViewProduct.Size = new System.Drawing.Size(715, 260);
            this.dataGridViewProduct.TabIndex = 8;
            // 
            // btnClean
            // 
            this.btnClean.Enabled = false;
            this.btnClean.Location = new System.Drawing.Point(593, 112);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(162, 29);
            this.btnClean.TabIndex = 9;
            this.btnClean.Text = "Limpar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fornecedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cliente";
            // 
            // cBoxPClient
            // 
            this.cBoxPClient.FormattingEnabled = true;
            this.cBoxPClient.Location = new System.Drawing.Point(416, 45);
            this.cBoxPClient.Name = "cBoxPClient";
            this.cBoxPClient.Size = new System.Drawing.Size(339, 28);
            this.cBoxPClient.TabIndex = 14;
            // 
            // cBoxPSupplier
            // 
            this.cBoxPSupplier.FormattingEnabled = true;
            this.cBoxPSupplier.Location = new System.Drawing.Point(123, 45);
            this.cBoxPSupplier.Name = "cBoxPSupplier";
            this.cBoxPSupplier.Size = new System.Drawing.Size(272, 28);
            this.cBoxPSupplier.TabIndex = 15;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cBoxPSupplier);
            this.Controls.Add(this.cBoxPClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.txtSName);
            this.Controls.Add(this.txtSID);
            this.Controls.Add(this.lblCName);
            this.Controls.Add(this.lblCID);
            this.Controls.Add(this.btnMakeProduct);
            this.Controls.Add(this.btnBack);
            this.Name = "ProductForm";
            this.Text = "Product Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnBack;
        private Button btnSalvar;
        private Button btnMakeProduct;
        private Label lblCID;
        private Label lblCName;
        private TextBox txtSID;
        private TextBox txtSName;
        private DataGridView dataGridViewProduct;
        private Button btnClean;
        private Label label1;
        private Label label2;
        private ComboBox cBoxPClient;
        private ComboBox cBoxPSupplier;
    }
}