namespace Matrixok
{
    internal class Program
    {
        static int sorokSzama = 10;
        static int oszlopokSzama = 6;
        static int[,] szamokMatrix = new int[sorokSzama, oszlopokSzama]; //sorokSzama, oszlopokSzama
        static int[,] negyzetesMatrix = new int[10, 10];//10 sor, 10 oszlop
        static Random r = new Random();

        static void F01(int[,] matrix, int min, int max)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) //i --> sorokon megy végig
            {
                for (int j = 0; j < matrix.GetLength(1); j++) //j --> oszlopokon megy végig
                {
                    matrix[i, j] = r.Next(min, max + 1); //10-99 közötti számokkal töltöm fel a mátrixot
                }
            }
        }

        static void F02(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) //i = 0;   matrix.GetLength(0) --> a mátrix sorainak számát adja vissza
            {
                for (int j = 0; j < matrix.GetLength(1); j++) //amíg a belső for le nem fut, a külső nem lép tovább
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static void F03()
        {
            int ossz = 0;

            for (int i = 0; i < sorokSzama; i++) //i = 0
            {
                for (int j = 0; j < oszlopokSzama; j++) //amíg a belső for le nem fut, a külső nem lép tovább
                {
                    ossz += szamokMatrix[i, j];
                }
            }
            Console.WriteLine($"A mátrixban lévő elemek összege: {ossz}");

        }

        static void F04()
        {
            for (int i = 0; i < sorokSzama; i++)
            {
                int ossz = 0;
                for (int j = 0; j < oszlopokSzama; j++)
                {
                    ossz += szamokMatrix[i, j];
                }
                Console.WriteLine($"{i + 1}. sor összege: {ossz}");
            }
        }

        static void F05()
        {
            for (int j = 0; j < oszlopokSzama; j++)
            {
                int ossz = 0;
                for (int i = 0; i < sorokSzama; i++)
                {
                    ossz += szamokMatrix[i, j];
                }
                Console.WriteLine($"{j + 1}. oszlop összege: {ossz}");
            }
        }

        static void BalAtloOsszeg(int[,] matrix)
        {
            int ossz = 0;
            Console.WriteLine("Az átló: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write($"{matrix[i, i],5}");
                ossz += matrix[i, i];
            }
            Console.WriteLine();
            Console.WriteLine($"A mátrix bal átlójának összege: {ossz}");
        }

        static void JobbAtloOsszeg(int[,] matrix)
        {
            int ossz = 0;
            int j = matrix.GetLength(1) - 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write($"{matrix[i, j],5}");
                ossz += matrix[i, j];
                j--;
            }
            Console.WriteLine();
            Console.WriteLine($"A mátrix jobb átlójának összege: {ossz}");
        }

        static void Main(string[] args)
        {
            F01(szamokMatrix, 10, 99); // kap egy referenciacímet, ahol a mátrix van tárolva, és ott tölti fel a számokat
            F02(szamokMatrix);
            F03();
            F04();
            F05();
            Console.WriteLine("--------------------------------------------------");
            F01(negyzetesMatrix, -100, 100);
            F02(negyzetesMatrix);
            BalAtloOsszeg(negyzetesMatrix);
            JobbAtloOsszeg(negyzetesMatrix);

            int[,] masolat = negyzetesMatrix; //másolat megkapja a négyzetesmátrix referenciacímét
            masolat[0, 0] = 100;
            Console.WriteLine("A másolat elemei: ");
            F02(masolat);
            Console.WriteLine("A négyzetesmátrix: ");
            F02(negyzetesMatrix);
        }
    }
}
