namespace FurnitureShop
{
    partial class SaleUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pSales = new System.Windows.Forms.Panel();
            this.tbInvoice = new System.Windows.Forms.TextBox();
            this.btnAddMore = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbClient = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.pSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // pSales
            // 
            this.pSales.AutoScroll = true;
            this.pSales.Controls.Add(this.tbDate);
            this.pSales.Controls.Add(this.tbClient);
            this.pSales.Controls.Add(this.tbInvoice);
            this.pSales.Controls.Add(this.btnAddMore);
            this.pSales.Controls.Add(this.numQuantity);
            this.pSales.Controls.Add(this.lblQuantity);
            this.pSales.Controls.Add(this.cbProduct);
            this.pSales.Controls.Add(this.lblProduct);
            this.pSales.Controls.Add(this.label6);
            this.pSales.Controls.Add(this.label9);
            this.pSales.Controls.Add(this.label10);
            this.pSales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pSales.Location = new System.Drawing.Point(0, 42);
            this.pSales.Name = "pSales";
            this.pSales.Size = new System.Drawing.Size(388, 187);
            this.pSales.TabIndex = 24;
            // 
            // tbInvoice
            // 
            this.tbInvoice.Enabled = false;
            this.tbInvoice.Location = new System.Drawing.Point(112, 69);
            this.tbInvoice.MaxLength = 10;
            this.tbInvoice.Name = "tbInvoice";
            this.tbInvoice.Size = new System.Drawing.Size(253, 20);
            this.tbInvoice.TabIndex = 20;
            // 
            // btnAddMore
            // 
            this.btnAddMore.Location = new System.Drawing.Point(314, 101);
            this.btnAddMore.Name = "btnAddMore";
            this.btnAddMore.Size = new System.Drawing.Size(51, 23);
            this.btnAddMore.TabIndex = 23;
            this.btnAddMore.Text = "Add..";
            this.btnAddMore.UseVisualStyleBackColor = true;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(252, 101);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(56, 20);
            this.numQuantity.TabIndex = 22;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(200, 105);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 19;
            this.lblQuantity.Text = "Quantity";
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(112, 101);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(79, 21);
            this.cbProduct.TabIndex = 21;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(23, 102);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 17;
            this.lblProduct.Text = "Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Invoice";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Client";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Date";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(267, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 21);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbClient
            // 
            this.tbClient.Enabled = false;
            this.tbClient.Location = new System.Drawing.Point(112, 43);
            this.tbClient.MaxLength = 10;
            this.tbClient.Name = "tbClient";
            this.tbClient.Size = new System.Drawing.Size(253, 20);
            this.tbClient.TabIndex = 24;
            // 
            // tbDate
            // 
            this.tbDate.Enabled = false;
            this.tbDate.Location = new System.Drawing.Point(112, 13);
            this.tbDate.MaxLength = 10;
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(253, 20);
            this.tbDate.TabIndex = 25;
            // 
            // SaleUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(388, 229);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pSales);
            this.Name = "SaleUpdateForm";
            this.Text = "Sale Update";
            this.pSales.ResumeLayout(false);
            this.pSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSales;
        private System.Windows.Forms.TextBox tbInvoice;
        private System.Windows.Forms.Button btnAddMore;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.TextBox tbClient;
    }
}