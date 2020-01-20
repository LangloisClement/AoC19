using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC19
{
    class Day1
    {
        static int calculCarburant(int poids)
        {
            return (poids / 3) - 2;
        }

        static int calculCarburantInclue(int poids)
        {
            int a = calculCarburant(poids);
            if (poids <= 8) return 0;
            return a + calculCarburantInclue(a);
        }

        static int calculCarburantTotal(string listeModule)
        {
            if (!System.IO.File.Exists(listeModule)) return -1;
            int memo = 0;
            string[] list = System.IO.File.ReadAllLines(listeModule);
            foreach (string s in list)
            {
                memo += calculCarburant(Int32.Parse(s));
            }
            return memo;
        }

        static int calculCarburantTotalInclu(string listeModule)
        {
            if (!System.IO.File.Exists(listeModule)) return -1;
            int memo = 0;
            string[] list = System.IO.File.ReadAllLines(listeModule);
            foreach (string s in list)
            {
                memo += calculCarburantInclue(Int32.Parse(s));
            }
            return memo;
        }



    }
}
