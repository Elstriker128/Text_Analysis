using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Text_Analysis
{
    internal class InOut
    {
        public static void PrintRepetitions(string fout, LettersFrequency letters)
        {
            using(var writer = File.CreateText(fout))
            {
                
                    for (char ch = 'a'; ch <= 'z'; ch++)
                        writer.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", ch,
                       letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
                }               
            }
        public static void Repetitions(string fin, LettersFrequency letters)
        {
            using (StreamReader reader = new StreamReader(fin))
            {
                string line;
                while((line=reader.ReadLine())!=null)
                {
                    letters.line = line;
                    letters.Count();
                }
            }
        }
        public static void SortedRepetitions(string fout, LettersFrequency letters)
        {
            using(var writer = File.CreateText(fout))
            {
                char[] sorted = letters.Sort();
                foreach(char ch in sorted)
                {
                    if(letters.line.Contains(ch) || letters.line.Contains(Char.ToUpper(ch)))
                    {
                        writer.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", ch,
                    letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
                    }
                }
            }
        }
    }
}
