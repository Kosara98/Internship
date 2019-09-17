﻿using System;
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
            string[] words = GenerateWords((int)num_WordLength.Value);
            int randomNumber;
            
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
                rtb_Words.Text += words[randomNumber] + Environment.NewLine;
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

            foreach (var item in words)
            {
                if (item.ToLower().Contains('g'))
                {
                    rtb_Words.Text = null;
                    rtb_Words.Text += item + Environment.NewLine;
                }
            }
        }

        private void btn_Compare_Click(object sender, EventArgs e)
        {
            string[] words = rtb_Words.Text.Split('\n', '\r');
            char[] firstWord = words[random.Next(1, 21)].ToCharArray();
            char[] secondWord = words[random.Next(1, 21)].ToCharArray();
            rtb_Words.Text = null;

            List<char> result = CompareTwoWords(firstWord, secondWord);

            foreach (var item in result)
                rtb_Words.Text += item + Environment.NewLine;
        }

        private void btn_MatchingWords_Click(object sender, EventArgs e)
        {
            sw.Start();
            string[] words = rtb_Words.Text.Split('\n', '\r');
            List<char> matching;
            List<char> result = new List<char>();

            foreach (var item in words)
            {
                char[] firstWord = item.ToCharArray();

                foreach (var i in words)
                {
                    char[] secondWord = i.ToCharArray();

                    if (item.Equals(i))
                        continue;
                    else
                    {
                        matching = CompareTwoWords(firstWord, secondWord);
                        if (matching.Count > result.Count)
                        {
                            result.Clear();
                            for (int index = 0; index < matching.Count; index++)
                                result.Add(matching[index]);
                        }     
                    }  
                }
            }
            rtb_Words.Text = null;

            foreach (var item in result)
                rtb_Words.Text += item;

            sw.Stop();
            lbl_Time.Text = "" + sw.Elapsed;
        }

        private List<char> CompareTwoWords(char[] firstWord, char[] secondWord)
        {
            List<char> result = new List<char>();
            List<char> index = new List<char>();

            foreach (var item in firstWord)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    if (item.Equals(secondWord[i]))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
