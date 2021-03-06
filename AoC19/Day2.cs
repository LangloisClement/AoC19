﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC19
{
    class Day2
    {
        public static int[] ReadIntCode(string InputAddr)
        {
            int[] r;
            if (!System.IO.File.Exists(InputAddr)) r = new int[0];
            else
            {
                string raw = System.IO.File.ReadAllText(InputAddr);
                string[] temp = raw.Split(',');
                r = new int[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    r[i] = Int32.Parse(temp[i]);
                }
            }
            return r;
        }

        static void OpCode(int[] intCode)
        {
            bool boucle = true;
            for (int i = 0; i < intCode.Length; i += 4)
            {
                switch (intCode[i])
                {
                    case 1:
                        intCode[intCode[i + 3]] = intCode[intCode[i + 1]] + intCode[intCode[i + 2]];
                        break;
                    case 2:
                        intCode[intCode[i + 3]] = intCode[intCode[i + 1]] * intCode[intCode[i + 2]];
                        break;
                    case 99:
                        i = intCode.Length;
                        break;
                    default:
                        Console.WriteLine("!!ERROR!!");
                        boucle = false;
                        break;
                }
                if (!boucle) break;
            }
        }

        static void AfficheIntCode(int[] intCode)
        {
            for (int i = 0; i < intCode.Length; i += 4)
            {
                for (int j = 0; j < 4 && i + j < intCode.Length; j++)
                {
                    Console.Write(intCode[i + j] + ",");
                }
                Console.WriteLine();
            }
        }

        static int[] CopieTab(int[] t)
        {
            int[] r = new int[t.Length];
            for (int i = 0; i < t.Length; i++) r[i] = t[i];
            return r;
        }

        public static int TestCode(int[] intCode, int value)
        {
            int r = -1;
            int[] copie;
            bool boucle = true;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    copie = CopieTab(intCode);
                    copie[1] = i;
                    copie[2] = j;
                    OpCode(copie);
                    Console.WriteLine(100 * i + j);
                    if (copie[0] == value)
                    {
                        r = i * 100 + j;
                        boucle = false;
                        break;
                    }
                }
                if (!boucle) break;
            }
            return r;
        }
    }
}
