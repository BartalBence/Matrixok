namespace Ijaszverseny
{
    internal class Program
    {
        static int[,] jatekosokPontjai; //globális változó
        static Random r = new Random(); // 0-25 ig kapnak pontot

        static string[] JatekosokNevei(int jatekosokSzama)
        {
            string[] nevek = { "Anna", "Bence", "Csaba", "Dóra", "Eszter", "Ferenc", "Gábor", "Hanna", "István", "Judit", "Katalin", "László", "Márk", "Nóra", "Orsolya", "Péter", "Réka", "Sándor", "Tamás", "Viktória", "Zoltán", "Ádám", "Balázs", "Cecília", "Dávid", "Emese", "Flóra", "György", "Levente", "Mihály" };
            string[] jatekosok = new string[jatekosokSzama];
            for (int i = 0; i < jatekosokSzama; i++)
            {
                int index = r.Next(0, nevek.Length);
                jatekosok[i] = nevek[index];
            }
            return jatekosok;
        }

        private static int[,] Feltolt(int jatekosokSzama)
        {
            int[,] matrix = new int[jatekosokSzama, 5];
            for (int i = 0; i < jatekosokSzama; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = r.Next(0, 26);
                }
            }
            return matrix;
        }

        static void Gyoztes(int[,] matrix)
        {
            int gyoztesPont = 0;
            int gyoztesindex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int ossz = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    ossz += matrix[i, j];
                }
                if (ossz > gyoztesPont)
                {
                    gyoztesPont = ossz;
                    gyoztesindex = i;
                }
            }

            Console.WriteLine($"A győztes a(z) {gyoztesindex + 1}. versenyző, {gyoztesPont} ponttal. Neve: {jatekosok[gyoztesindex]}");
        }


        static void Main(string[] args)
        {
            Console.Write("Játékosok száma: ");
            int jatekosokSzama = Convert.ToInt32(Console.ReadLine());
            jatekosokPontjai = Feltolt(jatekosokSzama);
            string[] jatekosok = JatekosokNevei(jatekosokSzama);
            //foreach (var item in jatekosok)
            //{
            //    Console.WriteLine(item);
            //}



            for (int i = 0; i < jatekosokPontjai.GetLength(1); i++)
            {
                Console.Write($"Az {i + 1} játékos: {jatekosok[i],-8}\t pontjai: ");
                for (int j = 0; j < jatekosokPontjai.GetLength(1); j++)
                {
                    Console.Write($"{jatekosokPontjai[i, j],4}");
                }
                Console.WriteLine();

            }
            Console.WriteLine();


            Gyoztes(jatekosokPontjai);
        }
    }
}
