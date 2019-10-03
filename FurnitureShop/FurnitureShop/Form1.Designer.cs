namespace FurnitureShop
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 51);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(537, 228);
            this.dataGridView1.TabIndex = 3;
            // 
            // cbTables
            // 
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Items.AddRange(new object[] {
            "Products",
            "Clients",
            "Sales"});
            this.cbTables.Location = new System.Drawing.Point(289, 12);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(141, 21);
            this.cbTables.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newClientToolStripMenuItem,
            this.newProductToolStripMenuItem,
            this.newSaleToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newClientToolStripMenuItem
            // 
            this.newClientToolStripMenuItem.Name = "newClientToolStripMenuItem";
            this.newClientToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newClientToolStripMenuItem.Text = "New client";
            this.newClientToolStripMenuItem.Click += new System.EventHandler(this.newClientToolStripMenuItem_Click);
            // 
            // newProductToolStripMenuItem
            // 
            this.newProductToolStripMenuItem.Name = "newProductToolStripMenuItem";
            this.newProductToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newProductToolStripMenuItem.Text = "New product";
            this.newProductToolStripMenuItem.Click += new System.EventHandler(this.newProductToolStripMenuItem_Click);
            // 
            // newSaleToolStripMenuItem
            // 
            this.newSaleToolStripMenuItem.Name = "newSaleToolStripMenuItem";
            this.newSaleToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newSaleToolStripMenuItem.Text = "New sale";
            this.newSaleToolStripMenuItem.Click += new System.EventHandler(this.newSaleToolStripMenuItem_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(443, 11);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(537, 279);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cbTables);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSaleToolStripMenuItem;
        private System.Windows.Forms.Button btnShow;
    }
}

