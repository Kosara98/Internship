using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGenerator
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            rtb_Words.Text = null;
            string[] words = GenerateWords((int)num_WordLength.Value);
            int randomNumber;

            if (num_NumberOfWords.Value > words.Length)
            {
                MessageBox.Show("Don't have so much words");
                num_NumberOfWords.Value = words.Length;
            }

            for (int i = 0; i < num_NumberOfWords.Value; i++)
            {
                randomNumber = random.Next(0, words.Length);
                rtb_Words.Text += words[randomNumber];
            }
        }

        private string[] GenerateWords(int wordLength)
        {
            string fileName = $@"../../Resources/{wordLength}letterWords.txt";
            string[] words = ReadAllWords(fileName);
            return words;
        }

        private string[] ReadAllWords(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string[] content = streamReader.ReadToEnd().Split('\n');
                return content;
            }
        }
    }
}
