namespace Isola
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
            this.lbSize = new System.Windows.Forms.Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.cbTurn = new System.Windows.Forms.ComboBox();
            this.lbTurn = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.cbPlayerVs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(28, 78);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(27, 13);
            this.lbSize.TabIndex = 1;
            this.lbSize.Text = "Size";
            // 
            // cbSize
            // 
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new System.Drawing.Point(73, 75);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(121, 21);
            this.cbSize.TabIndex = 2;
            // 
            // cbTurn
            // 
            this.cbTurn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurn.FormattingEnabled = true;
            this.cbTurn.Location = new System.Drawing.Point(73, 116);
            this.cbTurn.Name = "cbTurn";
            this.cbTurn.Size = new System.Drawing.Size(121, 21);
            this.cbTurn.TabIndex = 3;
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Location = new System.Drawing.Point(28, 119);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(29, 13);
            this.lbTurn.TabIndex = 4;
            this.lbTurn.Text = "Turn";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(96, 158);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // cbPlayerVs
            // 
            this.cbPlayerVs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayerVs.FormattingEnabled = true;
            this.cbPlayerVs.Location = new System.Drawing.Point(73, 31);
            this.cbPlayerVs.Name = "cbPlayerVs";
            this.cbPlayerVs.Size = new System.Drawing.Size(121, 21);
            this.cbPlayerVs.TabIndex = 6;
            this.cbPlayerVs.SelectedIndexChanged += new System.EventHandler(this.cbPlayers_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(247, 218);
            this.Controls.Add(this.cbPlayerVs);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.cbTurn);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.lbSize);
            this.Name = "Form1";
            this.Text = "Isola";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChildForm_Closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.ComboBox cbTurn;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ComboBox cbPlayerVs;
    }
}

