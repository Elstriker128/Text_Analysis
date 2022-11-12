using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Text_Analysis
{
    internal class LettersFrequency
    {
        private const int CMAX = 256;
        private int[] Freqeuncy;
        public string line { get; set; }
        public LettersFrequency()
        {
            line = "";
            Freqeuncy = new int[CMAX];
            for (int i = 0; i < CMAX; i++)
            {
                Freqeuncy[i] = 0;
            }
        }
        public int Get(char character)
        {
            return Freqeuncy[character];
        }
        public void Count()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (('a' <= line[i] && line[i] <= 'z') || ('A' <= line[i] && line[i] <= 'Z'))
                {
                    Freqeuncy[line[i]]++;
                }
            }
        }
        public int MaxLetter()
        {
            int max = 0;
            for (int i = 0; i < line.Length; i++)
            {
                int current = this.Get(line[i]);
                if (current > max)
                {
                    max = current;
                }
            }
            return max;
        }
        public List<int> AllMaxLetters()
        {
            int max = MaxLetter();
            List<int> Biggest = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                int current = this.Get(line[i]);
                if (current == max)
                {
                    Biggest.Add(current);
                }

            }
            return Biggest;
        }
        public char[] FromLineToChar()
        {
            char[] letterString = new char[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                for (char ch = 'a'; ch < 'z'; ch++)
                {
                    if(!letterString.Contains(ch) && (line.Contains(ch) || line.Contains(Char.ToUpper(ch))))
                    {
                        letterString[i] = ch;
                        break;
                    }
                }
            }
            return letterString;
        }
        public char[] Sort()
        {
            char[] letterString = this.FromLineToChar();
            for (int i = 0; i < letterString.Length - 1; i++)
                for (int j = 0; j < letterString.Length - 1 - i; j++)
                {
                    // lhs - left hand side, rhs - right hand side
                    int sumlhs = this.Get(letterString[j]) + this.Get(Char.ToUpper(letterString[j]));
                    int sumrhs = this.Get(letterString[j + 1]) + this.Get(Char.ToUpper(letterString[j + 1]));

                    // Swap
                    if (sumlhs < sumrhs)
                    {
                        char temp = letterString[j];
                        letterString[j] = letterString[j + 1];
                        letterString[j + 1] = temp;
                    }
                }

            return letterString;
        }

    }
}
