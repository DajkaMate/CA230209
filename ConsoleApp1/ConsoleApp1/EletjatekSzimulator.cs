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
        private int Szomszedokszam(int sk, int ok)
        {
            int szsz = 0;
            for (int s = sk - 1; s <= sk + 1 ; s++)
            {
                for (int o = ok - 1; o <= ok + 1; o++)
                {
                    if (s != sk || o != ok && Matrix[s, o] == 1)
                    {
                        szsz ++;
                    }
                }
            }
            return szsz;
        }
        public void Kovetkezoallapot() 
        {
            int[,] matrix = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            for (int s = 0; s < Matrix.GetLength(0) - 1; s++)
            {
                for (int o = 0; o < Matrix.GetLength(1) - 1; o++)
                {
                    int szsz = Szomszedokszam(o, s);
                    if (Matrix[s, o] == 1)
                    {
                        if (szsz == 2 || szsz == 3) matrix[s, o] = 1;
                        else matrix[s, o] = 0;
                    }
                    else
                    {
                        if (szsz == 3) matrix[s, o] = 1;
                        else matrix[s, o] = 0;
                    }
                }
            }
            MatrixCopy(matrix);
        }

        private void MatrixCopy(int[,] forras) 
        {
            for (int s = 0; s < forras.GetLength(0); s++)
            {
                for (int o = 0; o < forras.GetLength(1); o++)
                {
                    Matrix[s, o] = forras[s, o];
                }
            }
        }

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
        public void Run() 
        {
            Console.Clear();
            Mejelenit();
            Kovetkezoallapot();
            Thread.Sleep(500);
        }

        public EletjatekSzimulator(int sorokszama, int oszlopokszama)
        {
            OszlopokSzama = oszlopokszama;
            Sorokszama = sorokszama;

            Matrix = new int[Sorokszama +2 , OszlopokSzama +2];
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (Kulso(s, o))  Matrix[s, o] = 0;
                    else Matrix[s, o] = rnd.Next(2);
                }
            }
        }
    }
}
