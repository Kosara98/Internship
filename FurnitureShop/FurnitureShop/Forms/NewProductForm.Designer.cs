namespace FurnitureShop
{
    partial class NewProductForm
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
            this.pProduct = new System.Windows.Forms.Panel();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.tbNameProduct = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // pProduct
            // 
            this.pProduct.Controls.Add(this.rtbDescription);
            this.pProduct.Controls.Add(this.numWeight);
            this.pProduct.Controls.Add(this.numPrice);
            this.pProduct.Controls.Add(this.tbBarcode);
            this.pProduct.Controls.Add(this.tbNameProduct);
            this.pProduct.Controls.Add(this.lblPrice);
            this.pProduct.Controls.Add(this.lblBarcode);
            this.pProduct.Controls.Add(this.lblWeight);
            this.pProduct.Controls.Add(this.lblDescription);
            this.pProduct.Controls.Add(this.lblName);
            this.pProduct.Location = new System.Drawing.Point(12, 38);
            this.pProduct.Name = "pProduct";
            this.pProduct.Size = new System.Drawing.Size(391, 184);
            this.pProduct.TabIndex = 16;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(112, 108);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(256, 66);
            this.rtbDescription.TabIndex = 15;
            this.rtbDescription.Text = "";
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
            this.numWeight.TabIndex = 13;
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
            this.numPrice.TabIndex = 14;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Location = new System.Drawing.Point(112, 46);
            this.tbBarcode.MaxLength = 13;
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(256, 20);
            this.tbBarcode.TabIndex = 11;
            // 
            // tbNameProduct
            // 
            this.tbNameProduct.Location = new System.Drawing.Point(112, 13);
            this.tbNameProduct.MaxLength = 35;
            this.tbNameProduct.Name = "tbNameProduct";
            this.tbNameProduct.Size = new System.Drawing.Size(256, 20);
            this.tbNameProduct.TabIndex = 9;
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
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(23, 49);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(47, 13);
            this.lblBarcode.TabIndex = 7;
            this.lblBarcode.Text = "Barcode";
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
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 108);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(282, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 21);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // NewProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(402, 227);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pProduct);
            this.Name = "NewProductForm";
            this.Text = "NewProduct";
            this.pProduct.ResumeLayout(false);
            this.pProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pProduct;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.TextBox tbNameProduct;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAdd;
    }
}