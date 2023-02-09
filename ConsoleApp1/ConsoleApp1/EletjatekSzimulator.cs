using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EletjatekSzimulator
    {
        static Random rnd = new();
        public int[,] Matrix { get; set; }
        public int OszlopokSzama { get; set; }
        public int Sorokszama { get; set; }
        private bool Kulso(int s, int o) => s == 0 || o == 0 || s == Matrix.GetLength(0) - 1 || o == Matrix.GetLength(1) - 1;

        public void Kovetkezoallapot() { }
        public void Mejelenit() 
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (Kulso(s, o)) Console.Write('X');
                    else if (Matrix[s, o] == 1) Console.Write('S');
                    else Console.Write(' ');
                }
                Console.Write('\n');
            }
        }
        public void Run() { }

        public EletjatekSzimulator(int sorokszama, int oszlopokszama)
        {
            OszlopokSzama = oszlopokszama;
            Sorokszama = sorokszama;

            Matrix = new int[Sorokszama +2 , OszlopokSzama +2];
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (Kulso(s, o))
                    {
                        Matrix[s, o] = 0;
                    }
                    else
                    {
                        Matrix[s, o] = rnd.Next(2);
                    }
                }
            }
        }
    }
}
