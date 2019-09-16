using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            SortingWords();
        }

        public static void SortingWords()
        {
            string[] content;
            int wordLength;
            string sourceFile = @"../../Resources/1000-most-common-words-in-english.txt";

            using (StreamReader streamReader = new StreamReader(sourceFile))
                content = streamReader.ReadToEnd().Split('\n');

            foreach (var item in content)
            {
                wordLength = item.Length - 1;
                using(StreamWriter streamWriter = File.AppendText($@"../../../WordGenerator/Resources/{wordLength}letterWords.txt"))
                    streamWriter.Write(item);
            }
        }
    }
}
