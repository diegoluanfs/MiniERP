namespace MiniERP.Forms.Forms
{
    partial class MainForm:Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCustomer
            // 
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.Location = new System.Drawing.Point(66, 176);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(150, 150);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Image = global::MiniERP.Forms.Properties.Resources.supplier_120x120;
            this.btnProduct.Location = new System.Drawing.Point(303, 176);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(150, 150);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Image = global::MiniERP.Forms.Properties.Resources.invoice_120x120;
            this.btnInvoice.Location = new System.Drawing.Point(546, 176);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(150, 150);
            this.btnInvoice.TabIndex = 2;
            this.btnInvoice.UseVisualStyleBackColor = true;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(107, 138);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(61, 20);
            this.lblCustomer.TabIndex = 3;
            this.lblCustomer.Text = "Clientes";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(344, 138);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(98, 20);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Fornecedores";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(592, 138);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(48, 20);
            this.lblInvoice.TabIndex = 5;
            this.lblInvoice.Text = "Notas";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnCustomer);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCustomer;
        private Button btnProduct;
        private Button btnInvoice;
        private Label lblCustomer;
        private Label lblProduct;
        private Label lblInvoice;
    }
}