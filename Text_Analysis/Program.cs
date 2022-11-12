using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Analysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            const string CFrSorted = "Rezultatai_Sorted.txt";
            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);
            InOut.SortedRepetitions(CFrSorted, letters);
            InOut.PrintRepetitions(CFr, letters);

        }
    }
}
