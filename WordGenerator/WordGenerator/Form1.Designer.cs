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
            this.btn_Check = new System.Windows.Forms.Button();
            this.lbl_Check = new System.Windows.Forms.Label();
            this.btn_Compare = new System.Windows.Forms.Button();
            this.lbl_Compare = new System.Windows.Forms.Label();
            this.btn_MatchingWords = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
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
            this.rtb_Words.Location = new System.Drawing.Point(216, 12);
            this.rtb_Words.Name = "rtb_Words";
            this.rtb_Words.Size = new System.Drawing.Size(226, 170);
            this.rtb_Words.TabIndex = 5;
            this.rtb_Words.Text = "";
            // 
            // btn_Check
            // 
            this.btn_Check.Enabled = false;
            this.btn_Check.Location = new System.Drawing.Point(373, 188);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(69, 24);
            this.btn_Check.TabIndex = 6;
            this.btn_Check.Text = "Check";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // lbl_Check
            // 
            this.lbl_Check.AutoSize = true;
            this.lbl_Check.Location = new System.Drawing.Point(213, 194);
            this.lbl_Check.Name = "lbl_Check";
            this.lbl_Check.Size = new System.Drawing.Size(154, 13);
            this.lbl_Check.TabIndex = 7;
            this.lbl_Check.Text = "Check if words contain letter \'g\'";
            // 
            // btn_Compare
            // 
            this.btn_Compare.Enabled = false;
            this.btn_Compare.Location = new System.Drawing.Point(373, 218);
            this.btn_Compare.Name = "btn_Compare";
            this.btn_Compare.Size = new System.Drawing.Size(69, 24);
            this.btn_Compare.TabIndex = 8;
            this.btn_Compare.Text = "Compare";
            this.btn_Compare.UseVisualStyleBackColor = true;
            this.btn_Compare.Click += new System.EventHandler(this.btn_Compare_Click);
            // 
            // lbl_Compare
            // 
            this.lbl_Compare.AutoSize = true;
            this.lbl_Compare.Location = new System.Drawing.Point(213, 224);
            this.lbl_Compare.Name = "lbl_Compare";
            this.lbl_Compare.Size = new System.Drawing.Size(138, 13);
            this.lbl_Compare.TabIndex = 9;
            this.lbl_Compare.Text = "Compare two random words";
            // 
            // btn_MatchingWords
            // 
            this.btn_MatchingWords.Location = new System.Drawing.Point(373, 279);
            this.btn_MatchingWords.Name = "btn_MatchingWords";
            this.btn_MatchingWords.Size = new System.Drawing.Size(69, 24);
            this.btn_MatchingWords.TabIndex = 10;
            this.btn_MatchingWords.Text = "Check";
            this.btn_MatchingWords.UseVisualStyleBackColor = true;
            this.btn_MatchingWords.Click += new System.EventHandler(this.btn_MatchingWords_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "The longest matching sequence of characters";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(213, 285);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(30, 13);
            this.lbl_Time.TabIndex = 12;
            this.lbl_Time.Text = "Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 325);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_MatchingWords);
            this.Controls.Add(this.lbl_Compare);
            this.Controls.Add(this.btn_Compare);
            this.Controls.Add(this.lbl_Check);
            this.Controls.Add(this.btn_Check);
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
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Label lbl_Check;
        private System.Windows.Forms.Button btn_Compare;
        private System.Windows.Forms.Label lbl_Compare;
        private System.Windows.Forms.Button btn_MatchingWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Time;
    }
}

