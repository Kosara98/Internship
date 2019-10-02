namespace FurnitureShop
{
    partial class Add
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
            this.rbProduct = new System.Windows.Forms.RadioButton();
            this.rbSales = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tbNameProduct = new System.Windows.Forms.TextBox();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.pProduct = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pSales = new System.Windows.Forms.Panel();
            this.btnAddMore = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbInvoice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pClient = new System.Windows.Forms.Panel();
            this.cbVat = new System.Windows.Forms.ComboBox();
            this.tbNameClient = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbClient = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.pProduct.SuspendLayout();
            this.pSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.pClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbProduct
            // 
            this.rbProduct.AutoSize = true;
            this.rbProduct.Location = new System.Drawing.Point(42, 26);
            this.rbProduct.Name = "rbProduct";
            this.rbProduct.Size = new System.Drawing.Size(62, 17);
            this.rbProduct.TabIndex = 0;
            this.rbProduct.TabStop = true;
            this.rbProduct.Text = "Product";
            this.rbProduct.UseVisualStyleBackColor = true;
            this.rbProduct.CheckedChanged += new System.EventHandler(this.rbProduct_CheckedChanged);
            // 
            // rbSales
            // 
            this.rbSales.AutoSize = true;
            this.rbSales.Location = new System.Drawing.Point(209, 26);
            this.rbSales.Name = "rbSales";
            this.rbSales.Size = new System.Drawing.Size(46, 17);
            this.rbSales.TabIndex = 2;
            this.rbSales.TabStop = true;
            this.rbSales.Text = "Sale";
            this.rbSales.UseVisualStyleBackColor = true;
            this.rbSales.CheckedChanged += new System.EventHandler(this.rbSales_CheckedChanged);
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(128, 26);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(51, 17);
            this.rbClient.TabIndex = 3;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 108);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(23, 79);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(23, 49);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(47, 13);
            this.lblBarcode.TabIndex = 7;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(212, 79);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            // 
            // tbNameProduct
            // 
            this.tbNameProduct.Location = new System.Drawing.Point(112, 13);
            this.tbNameProduct.MaxLength = 35;
            this.tbNameProduct.Name = "tbNameProduct";
            this.tbNameProduct.Size = new System.Drawing.Size(256, 20);
            this.tbNameProduct.TabIndex = 9;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Location = new System.Drawing.Point(112, 46);
            this.tbBarcode.MaxLength = 13;
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(256, 20);
            this.tbBarcode.TabIndex = 11;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(248, 77);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 20);
            this.numPrice.TabIndex = 13;
            // 
            // numWeight
            // 
            this.numWeight.DecimalPlaces = 2;
            this.numWeight.Location = new System.Drawing.Point(112, 76);
            this.numWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(94, 20);
            this.numWeight.TabIndex = 14;
            // 
            // pProduct
            // 
            this.pProduct.Controls.Add(this.richTextBox1);
            this.pProduct.Controls.Add(this.numWeight);
            this.pProduct.Controls.Add(this.numPrice);
            this.pProduct.Controls.Add(this.tbBarcode);
            this.pProduct.Controls.Add(this.tbNameProduct);
            this.pProduct.Controls.Add(this.lblPrice);
            this.pProduct.Controls.Add(this.lblBarcode);
            this.pProduct.Controls.Add(this.lblWeight);
            this.pProduct.Controls.Add(this.lblDescription);
            this.pProduct.Controls.Add(this.lblName);
            this.pProduct.Location = new System.Drawing.Point(16, 56);
            this.pProduct.Name = "pProduct";
            this.pProduct.Size = new System.Drawing.Size(391, 184);
            this.pProduct.TabIndex = 15;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(112, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(256, 66);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // pSales
            // 
            this.pSales.Controls.Add(this.cbClient);
            this.pSales.Controls.Add(this.btnAddMore);
            this.pSales.Controls.Add(this.numQuantity);
            this.pSales.Controls.Add(this.lblQuantity);
            this.pSales.Controls.Add(this.cbProduct);
            this.pSales.Controls.Add(this.lblProduct);
            this.pSales.Controls.Add(this.dateTimePicker1);
            this.pSales.Controls.Add(this.tbInvoice);
            this.pSales.Controls.Add(this.label6);
            this.pSales.Controls.Add(this.label9);
            this.pSales.Controls.Add(this.label10);
            this.pSales.Location = new System.Drawing.Point(17, 56);
            this.pSales.Name = "pSales";
            this.pSales.Size = new System.Drawing.Size(441, 212);
            this.pSales.TabIndex = 17;
            // 
            // btnAddMore
            // 
            this.btnAddMore.Location = new System.Drawing.Point(316, 100);
            this.btnAddMore.Name = "btnAddMore";
            this.btnAddMore.Size = new System.Drawing.Size(51, 23);
            this.btnAddMore.TabIndex = 21;
            this.btnAddMore.Text = "Add..";
            this.btnAddMore.UseVisualStyleBackColor = true;
            this.btnAddMore.Click += new System.EventHandler(this.btnAddMore_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(252, 101);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(56, 20);
            this.numQuantity.TabIndex = 20;
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
            this.cbProduct.Items.AddRange(new object[] {
            "yes"});
            this.cbProduct.Location = new System.Drawing.Point(112, 101);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(79, 21);
            this.cbProduct.TabIndex = 18;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(254, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // tbInvoice
            // 
            this.tbInvoice.Location = new System.Drawing.Point(112, 69);
            this.tbInvoice.MaxLength = 9;
            this.tbInvoice.Name = "tbInvoice";
            this.tbInvoice.Size = new System.Drawing.Size(254, 20);
            this.tbInvoice.TabIndex = 15;
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
            // pClient
            // 
            this.pClient.Controls.Add(this.cbVat);
            this.pClient.Controls.Add(this.tbNameClient);
            this.pClient.Controls.Add(this.textBox1);
            this.pClient.Controls.Add(this.textBox5);
            this.pClient.Controls.Add(this.tbAdress);
            this.pClient.Controls.Add(this.label1);
            this.pClient.Controls.Add(this.label2);
            this.pClient.Controls.Add(this.label3);
            this.pClient.Controls.Add(this.label4);
            this.pClient.Controls.Add(this.label5);
            this.pClient.Location = new System.Drawing.Point(16, 56);
            this.pClient.Name = "pClient";
            this.pClient.Size = new System.Drawing.Size(413, 177);
            this.pClient.TabIndex = 18;
            // 
            // cbVat
            // 
            this.cbVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVat.FormattingEnabled = true;
            this.cbVat.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbVat.Location = new System.Drawing.Point(315, 72);
            this.cbVat.Name = "cbVat";
            this.cbVat.Size = new System.Drawing.Size(53, 21);
            this.cbVat.TabIndex = 17;
            // 
            // tbNameClient
            // 
            this.tbNameClient.Location = new System.Drawing.Point(112, 13);
            this.tbNameClient.MaxLength = 9;
            this.tbNameClient.Name = "tbNameClient";
            this.tbNameClient.Size = new System.Drawing.Size(256, 20);
            this.tbNameClient.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 101);
            this.textBox1.MaxLength = 35;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 20);
            this.textBox1.TabIndex = 15;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(112, 72);
            this.textBox5.MaxLength = 9;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(159, 20);
            this.textBox5.TabIndex = 11;
            // 
            // tbAdress
            // 
            this.tbAdress.Location = new System.Drawing.Point(112, 42);
            this.tbAdress.MaxLength = 100;
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(256, 20);
            this.tbAdress.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bulstat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Adress";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(312, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 21);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Items.AddRange(new object[] {
            "yes"});
            this.cbClient.Location = new System.Drawing.Point(112, 40);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(253, 21);
            this.cbClient.TabIndex = 22;
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 252);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rbClient);
            this.Controls.Add(this.rbSales);
            this.Controls.Add(this.rbProduct);
            this.Controls.Add(this.pSales);
            this.Controls.Add(this.pClient);
            this.Controls.Add(this.pProduct);
            this.Name = "Add";
            this.Text = "Add new";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.pProduct.ResumeLayout(false);
            this.pProduct.PerformLayout();
            this.pSales.ResumeLayout(false);
            this.pSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.pClient.ResumeLayout(false);
            this.pClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbProduct;
        private System.Windows.Forms.RadioButton rbSales;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbNameProduct;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.Panel pProduct;
        private System.Windows.Forms.Panel pSales;
        private System.Windows.Forms.TextBox tbInvoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel pClient;
        private System.Windows.Forms.TextBox tbNameClient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox tbAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cbVat;
        private System.Windows.Forms.Button btnAddMore;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cbClient;
    }
}