namespace WordGenerator
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
            this.btn_Generate = new System.Windows.Forms.Button();
            this.lbl_NumberOfWords = new System.Windows.Forms.Label();
            this.lbl_WordLength = new System.Windows.Forms.Label();
            this.num_NumberOfWords = new System.Windows.Forms.NumericUpDown();
            this.num_WordLength = new System.Windows.Forms.NumericUpDown();
            this.rtb_Words = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_NumberOfWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WordLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(32, 117);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(157, 24);
            this.btn_Generate.TabIndex = 0;
            this.btn_Generate.Text = "Generate";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // lbl_NumberOfWords
            // 
            this.lbl_NumberOfWords.AutoSize = true;
            this.lbl_NumberOfWords.Location = new System.Drawing.Point(29, 31);
            this.lbl_NumberOfWords.Name = "lbl_NumberOfWords";
            this.lbl_NumberOfWords.Size = new System.Drawing.Size(87, 13);
            this.lbl_NumberOfWords.TabIndex = 1;
            this.lbl_NumberOfWords.Text = "Number of words";
            // 
            // lbl_WordLength
            // 
            this.lbl_WordLength.AutoSize = true;
            this.lbl_WordLength.Location = new System.Drawing.Point(29, 74);
            this.lbl_WordLength.Name = "lbl_WordLength";
            this.lbl_WordLength.Size = new System.Drawing.Size(69, 13);
            this.lbl_WordLength.TabIndex = 2;
            this.lbl_WordLength.Text = "Word Length";
            // 
            // num_NumberOfWords
            // 
            this.num_NumberOfWords.Location = new System.Drawing.Point(136, 29);
            this.num_NumberOfWords.Name = "num_NumberOfWords";
            this.num_NumberOfWords.Size = new System.Drawing.Size(53, 20);
            this.num_NumberOfWords.TabIndex = 3;
            // 
            // num_WordLength
            // 
            this.num_WordLength.Location = new System.Drawing.Point(136, 72);
            this.num_WordLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_WordLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_WordLength.Name = "num_WordLength";
            this.num_WordLength.Size = new System.Drawing.Size(53, 20);
            this.num_WordLength.TabIndex = 4;
            this.num_WordLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rtb_Words
            // 
            this.rtb_Words.Location = new System.Drawing.Point(240, 12);
            this.rtb_Words.Name = "rtb_Words";
            this.rtb_Words.Size = new System.Drawing.Size(180, 170);
            this.rtb_Words.TabIndex = 5;
            this.rtb_Words.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 194);
            this.Controls.Add(this.rtb_Words);
            this.Controls.Add(this.num_WordLength);
            this.Controls.Add(this.num_NumberOfWords);
            this.Controls.Add(this.lbl_WordLength);
            this.Controls.Add(this.lbl_NumberOfWords);
            this.Controls.Add(this.btn_Generate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.num_NumberOfWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_WordLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Label lbl_NumberOfWords;
        private System.Windows.Forms.Label lbl_WordLength;
        private System.Windows.Forms.NumericUpDown num_NumberOfWords;
        private System.Windows.Forms.NumericUpDown num_WordLength;
        private System.Windows.Forms.RichTextBox rtb_Words;
    }
}

