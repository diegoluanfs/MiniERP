namespace MiniERP.Forms.Forms
{
    partial class CustomerForm:Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMakeCustomer = new System.Windows.Forms.Button();
            this.lblCID = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.btnClean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
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
            // btnMakeCustomer
            // 
            this.btnMakeCustomer.Location = new System.Drawing.Point(416, 112);
            this.btnMakeCustomer.Name = "btnMakeCustomer";
            this.btnMakeCustomer.Size = new System.Drawing.Size(162, 29);
            this.btnMakeCustomer.TabIndex = 3;
            this.btnMakeCustomer.Text = "Listar";
            this.btnMakeCustomer.UseVisualStyleBackColor = true;
            this.btnMakeCustomer.Click += new System.EventHandler(this.btnMakeCustomer_Click);
            // 
            // lblCID
            // 
            this.lblCID.AutoSize = true;
            this.lblCID.Location = new System.Drawing.Point(40, 81);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new System.Drawing.Size(24, 20);
            this.lblCID.TabIndex = 4;
            this.lblCID.Text = "ID";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(123, 81);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(50, 20);
            this.lblCName.TabIndex = 5;
            this.lblCName.Text = "Nome";
            // 
            // txtCID
            // 
            this.txtCID.Location = new System.Drawing.Point(40, 114);
            this.txtCID.Name = "txtCID";
            this.txtCID.Size = new System.Drawing.Size(50, 27);
            this.txtCID.TabIndex = 6;
            // 
            // txtCName
            // 
            this.txtCName.Location = new System.Drawing.Point(123, 114);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(272, 27);
            this.txtCName.TabIndex = 7;
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(40, 157);
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.RowHeadersWidth = 51;
            this.dataGridViewCustomer.RowTemplate.Height = 29;
            this.dataGridViewCustomer.Size = new System.Drawing.Size(715, 260);
            this.dataGridViewCustomer.TabIndex = 8;
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
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.dataGridViewCustomer);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.txtCID);
            this.Controls.Add(this.lblCName);
            this.Controls.Add(this.lblCID);
            this.Controls.Add(this.btnMakeCustomer);
            this.Controls.Add(this.btnBack);
            this.Name = "CustomerForm";
            this.Text = "Customer Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnBack;
        private Button btnSalvar;
        private Button btnMakeCustomer;
        private Label lblCID;
        private Label lblCName;
        private TextBox txtCID;
        private TextBox txtCName;
        private DataGridView dataGridViewCustomer;
        private Button btnClean;
    }
}