using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            rtb_Words.Text = null;
            btn_Check.Enabled = false;
            lbl_FirstWord.Text = null;
            lbl_SecondWord.Text = null;
            string[] words = GenerateWords((int)num_WordLength.Value);
            int randomNumber;
            string prevWord = null;


            if (num_NumberOfWords.Value > words.Length)
            {
                MessageBox.Show("Don't have so much words");
                num_NumberOfWords.Value = words.Length - 1;

                foreach (var item in words)
                    Console.WriteLine(item);
                    
            }

            for (int i = 0; i < num_NumberOfWords.Value; i++)
            {
                randomNumber = random.Next(0, words.Length);

                if (words[randomNumber].Equals(prevWord))
                    continue;
                if (words[randomNumber] == null)
                    continue;

                rtb_Words.Text += words[randomNumber] + Environment.NewLine;
                prevWord = words[randomNumber];
            }

            if (num_NumberOfWords.Value == 5)
                btn_Check.Enabled = true;

            if (num_NumberOfWords.Value == 20)
                btn_Compare.Enabled = true;
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
                string[] content = streamReader.ReadToEnd().Split('\r');
                return content;
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            string[] words = rtb_Words.Text.Split('\n','\r');
            rtb_Words.Text = null;

            foreach (var item in words)
            {
                if (item.ToLower().Contains('g'))
                    rtb_Words.Text += item + Environment.NewLine;
            }

            if(rtb_Words.Text == "")
                rtb_Words.Text = "There is no words that contain 'g'";
        }

        private void btn_Compare_Click(object sender, EventArgs e)
        {
            string[] words = rtb_Words.Text.Split('\n', '\r');
            string firstWord = words[random.Next(1, 19)];
            string secondWord = words[random.Next(1, 19)];
            rtb_Words.Text = null;
            lbl_FirstWord.Text = firstWord;
            lbl_SecondWord.Text = secondWord;

            if (firstWord.Equals(secondWord))
                secondWord = words[random.Next(1, 19)];

            HashSet<char> result = CompareTwoWords(firstWord, secondWord);

            if (result.Count == 0)
                rtb_Words.Text = "There is no characters that appear in both words.";
            

            foreach (var item in result)
                rtb_Words.Text += item + Environment.NewLine;
        }

        private void btn_MatchingWords_Click(object sender, EventArgs e)
        {
            sw.Start();
            string[] words = rtb_Words.Text.Split('\n', '\r');
            List<char> matching = new List<char>();
            List<char> result = new List<char>();
            int startIndex = -1;
            int currentIndex;
            string fWord = null;
            string sWord = null;

            foreach (var firstWord in words)
            {
                foreach (var secondWord in words)
                {
                    if (firstWord.Equals(secondWord))
                        continue;
                    else
                    {
                        for (int firstIndex = 0; firstIndex < firstWord.Length; firstIndex++)
                        {
                            for (int wordIndex = 0; wordIndex < secondWord.Length; wordIndex++)
                            {
                                if (firstWord[firstIndex].Equals(secondWord[wordIndex]))
                                {
                                    matching.Add(firstWord[firstIndex]);
                                    currentIndex = firstIndex;
                                    int fIndex = firstIndex + 1;

                                    if (fIndex < firstWord.Length)
                                    {
                                        for (int sIndex = wordIndex + 1; sIndex < secondWord.Length; sIndex++)
                                        {
                                            if (firstWord[fIndex].Equals(secondWord[sIndex]))
                                            {
                                                matching.Add(firstWord[fIndex]);

                                                if (fIndex == firstWord.Length - 1)
                                                    break;

                                                fIndex++;
                                            }
                                            else
                                                break;
                                        }
                                    }
                                    
                                    if (matching.Count > result.Count)
                                    {
                                        result.Clear();
                                        result.AddRange(matching);
                                        startIndex = currentIndex + 1;
                                        fWord = firstWord;
                                        sWord = secondWord;
                                    }
                                    matching.Clear();
                                }
                            }
                        }
                    }  
                }
            }
            rtb_Words.Text = "" + startIndex + Environment.NewLine;

            foreach (var item in result)
                rtb_Words.Text += item;

            sw.Stop();

            lbl_Time.Text = "" + sw.Elapsed;
            lbl_FirstWord.Text = fWord;
            lbl_SecondWord.Text = sWord;
        }

        private HashSet<char> CompareTwoWords(string firstWord, string secondWord)
        {
            HashSet<char> result = new HashSet<char>();

            foreach (var item in firstWord)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    if (item.Equals(secondWord[i]))
                        result.Add(item);
                }
            }
            return result;
        }
    }
}
