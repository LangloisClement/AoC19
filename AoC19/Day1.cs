using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC19
{
    class Day1
    {
        static int CalculCarburant(int poids)
        {
            return (poids / 3) - 2;
        }

        static int CalculCarburantInclue(int poids)
        {
            int a = CalculCarburant(poids);
            if (poids <= 8) return 0;
            return a + CalculCarburantInclue(a);
        }

        static int CalculCarburantTotal(string listeModule)
        {
            if (!System.IO.File.Exists(listeModule)) return -1;
            int memo = 0;
            string[] list = System.IO.File.ReadAllLines(listeModule);
            foreach (string s in list)
            {
                memo += CalculCarburant(Int32.Parse(s));
            }
            return memo;
        }

        static int CalculCarburantTotalInclu(string listeModule)
        {
            if (!System.IO.File.Exists(listeModule)) return -1;
            int memo = 0;
            string[] list = System.IO.File.ReadAllLines(listeModule);
            foreach (string s in list)
            {
                memo += CalculCarburantInclue(Int32.Parse(s));
            }
            return memo;
        }
    }
}
