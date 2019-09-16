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
            string[] words = GenerateWords(num_WordLength.Value);
            int randomNumber;

            for (int i = 0; i < num_NumberOfWords.Value; i++)
            {
                randomNumber = random.Next(0, 15);
                rtb_Words.Text += words[randomNumber] + Environment.NewLine;
            }
        }

        private string[] GenerateWords(decimal wordLength)
        { 
            string fileName = $@"D:\Programming\Internship\WordGenerator\WordGenerator\Resources\{wordLength}letterWords.txt";

            string[] words = File.ReadAllLines(fileName);

            return words;
        }
    }
}
