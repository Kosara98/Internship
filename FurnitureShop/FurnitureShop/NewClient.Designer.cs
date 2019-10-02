namespace FurnitureShop
{
    partial class NewClient
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
            this.pClient = new System.Windows.Forms.Panel();
            this.cbVat = new System.Windows.Forms.ComboBox();
            this.tbNameClient = new System.Windows.Forms.TextBox();
            this.tbMol = new System.Windows.Forms.TextBox();
            this.tbBulstat = new System.Windows.Forms.TextBox();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pClient
            // 
            this.pClient.Controls.Add(this.cbVat);
            this.pClient.Controls.Add(this.tbNameClient);
            this.pClient.Controls.Add(this.tbMol);
            this.pClient.Controls.Add(this.tbBulstat);
            this.pClient.Controls.Add(this.tbAdress);
            this.pClient.Controls.Add(this.label1);
            this.pClient.Controls.Add(this.label2);
            this.pClient.Controls.Add(this.label3);
            this.pClient.Controls.Add(this.label4);
            this.pClient.Controls.Add(this.label5);
            this.pClient.Location = new System.Drawing.Point(19, 39);
            this.pClient.Name = "pClient";
            this.pClient.Size = new System.Drawing.Size(413, 147);
            this.pClient.TabIndex = 19;
            // 
            // cbVat
            // 
            this.cbVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVat.FormattingEnabled = true;
            this.cbVat.Items.AddRange(new object[] {
            "N",
            "Y"});
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
            // tbMol
            // 
            this.tbMol.Location = new System.Drawing.Point(110, 101);
            this.tbMol.MaxLength = 35;
            this.tbMol.Name = "tbMol";
            this.tbMol.Size = new System.Drawing.Size(258, 20);
            this.tbMol.TabIndex = 15;
            // 
            // tbBulstat
            // 
            this.tbBulstat.Location = new System.Drawing.Point(112, 72);
            this.tbBulstat.MaxLength = 9;
            this.tbBulstat.Name = "tbBulstat";
            this.tbBulstat.Size = new System.Drawing.Size(159, 20);
            this.tbBulstat.TabIndex = 11;
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
            this.btnAdd.Location = new System.Drawing.Point(289, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 21);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // NewClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 189);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pClient);
            this.Name = "NewClient";
            this.Text = "NewClient";
            this.pClient.ResumeLayout(false);
            this.pClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pClient;
        private System.Windows.Forms.ComboBox cbVat;
        private System.Windows.Forms.TextBox tbNameClient;
        private System.Windows.Forms.TextBox tbMol;
        private System.Windows.Forms.TextBox tbBulstat;
        private System.Windows.Forms.TextBox tbAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
    }
}