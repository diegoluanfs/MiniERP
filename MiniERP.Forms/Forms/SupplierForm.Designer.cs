namespace MiniERP.Forms.Forms
{
    partial class SupplierForm:Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMakeSupplier = new System.Windows.Forms.Button();
            this.lblCID = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.dataGridViewSupplier = new System.Windows.Forms.DataGridView();
            this.btnClean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplier)).BeginInit();
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
            // btnMakeSupplier
            // 
            this.btnMakeSupplier.Location = new System.Drawing.Point(416, 112);
            this.btnMakeSupplier.Name = "btnMakeSupplier";
            this.btnMakeSupplier.Size = new System.Drawing.Size(162, 29);
            this.btnMakeSupplier.TabIndex = 3;
            this.btnMakeSupplier.Text = "Listar";
            this.btnMakeSupplier.UseVisualStyleBackColor = true;
            this.btnMakeSupplier.Click += new System.EventHandler(this.btnMakeSupplier_Click);
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
            // txtSID
            // 
            this.txtSID.Location = new System.Drawing.Point(40, 114);
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
            // dataGridViewSupplier
            // 
            this.dataGridViewSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSupplier.Location = new System.Drawing.Point(40, 157);
            this.dataGridViewSupplier.Name = "dataGridViewSupplier";
            this.dataGridViewSupplier.RowHeadersWidth = 51;
            this.dataGridViewSupplier.RowTemplate.Height = 29;
            this.dataGridViewSupplier.Size = new System.Drawing.Size(715, 260);
            this.dataGridViewSupplier.TabIndex = 8;
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
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.dataGridViewSupplier);
            this.Controls.Add(this.txtSName);
            this.Controls.Add(this.txtSID);
            this.Controls.Add(this.lblCName);
            this.Controls.Add(this.lblCID);
            this.Controls.Add(this.btnMakeSupplier);
            this.Controls.Add(this.btnBack);
            this.Name = "SupplierForm";
            this.Text = "Supplier Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnBack;
        private Button btnSalvar;
        private Button btnMakeSupplier;
        private Label lblCID;
        private Label lblCName;
        private TextBox txtSID;
        private TextBox txtSName;
        private DataGridView dataGridViewSupplier;
        private Button btnClean;
    }
}