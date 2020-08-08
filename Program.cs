using System;

namespace Testing_Area
{
    class Program
    {
        static void CreateTitle()
        {
            char[] mainText;
            string sMainText = ("TERVETULOA ARVONTAKONEESEEN!");
            
            string empty = " ";
            int c = 0;

            mainText = sMainText.ToCharArray();

            foreach (char letter in sMainText)
            {
                c++;
            }

            for (int i = 0; i < Console.WindowWidth / 2 - c; i++)
            {
                Console.Write(empty);
            }

            foreach (char letter in mainText)
            {
                Console.Write(letter);
                Console.Write(empty);
            }
        }
        static void EmptySpace(string aText)
        {
            string empty = " ";
            int c = 0;

            foreach (char letter in aText)
            {
                c++;
            }

            for (int i = 0; i < Console.WindowWidth / 2 - c / 2; i++)
            {
                Console.Write(empty);
            }
        }
        static void MainMenu()
        {
            Console.Clear();

            Console.Write(Environment.NewLine);

            string sSubText = ("Valitse toiminto");
            string sFirst = ("1. Arvontantakone");
            string sSecond = ("2. Deathroll");
            string sThird = ("3. Mikä on Deathroll?");
            string sFourth = ("4. Lopeta ohjelma");
            string prompt = (": ");

            int choice;

            CreateTitle();
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            EmptySpace(sSubText);
            Console.WriteLine(sSubText);
            Console.Write(Environment.NewLine);
            EmptySpace(sFirst);
            Console.WriteLine(sFirst);
            EmptySpace(sSecond);
            Console.WriteLine(sSecond);
            EmptySpace(sThird);
            Console.WriteLine(sThird);
            EmptySpace(sFourth);
            Console.WriteLine(sFourth);
            Console.Write(Environment.NewLine);
            EmptySpace(prompt);
            Console.Write(prompt);
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                StartArvontakone();
            }
            else if (choice == 2)
            {
                StartDeathroll();
            }
            else if (choice == 3)
            {
                ExplainDeathroll();
            }
            else if (choice == 4)
            {
                return;
            }
            else
            {
                MainMenu();
            }

        }
        static void Main()
        {
            MainMenu();
        }
        
        static void StartArvontakone()
        {
            Console.Clear();
            PrintNumber(RandomizeNumber(AskNumber()));
        }

        static void StartDeathroll()
        {
            Console.Clear();
            PrintDeathRollTable(RandomizeTillDone(AskNumber()));
        }

        static void ExplainDeathroll()
        {
            Console.Clear();

            char key = 'a';

            Console.WriteLine("Deathroll tarkoittaa sitä, että valitset numeron.\n" +
                "Kone arpoo numeron 1 ja valitsemasi numeron väliltä.\n" +
                "Seuraavaksi kone arpoo numeron 1 ja viimeksi arvotun numeron väliltä.\n" +
                "Tämä jatkuu kunnes arpa osuu ykköseen");
            Console.Write(Environment.NewLine);
            Console.Write("Palaa päävalikkoon painamalla mitä tahansa näppäintä");
            Console.ReadKey();
            if (key != '0')
            {
                MainMenu();
            }
        }

        static int AskNumber()
        {
            int numero;

            Console.Write("Anna numero 0-5000000: ");
            numero = int.Parse(Console.ReadLine());
            return numero;
        }

        static int RandomizeNumber(int aNumero)
        {
            Random rng = new Random();

            aNumero = rng.Next(0, aNumero);
            return aNumero;
        }

        static int[] RandomizeTillDone(int aNumero)
        {
            int[] table = new int[aNumero];

            int i = 0;
            int j = 0;

            while (i != 1)
            {
                Random rng = new Random();
                table[j] = rng.Next(1, aNumero);
                i = table[j];
                aNumero = i;
                j++;
            }

            Array.Resize(ref table, j);

            return table;
        }

        static void PrintNumber(int aNumero)
        {
            int pChoice;

            Console.WriteLine("Rollasit: " + aNumero);
            Console.Write(Environment.NewLine);
            Console.WriteLine("1. Rollaa uudelleen!");
            Console.WriteLine("2. Palaa päävalikkoon");
            Console.Write(Environment.NewLine);
            Console.Write(": ");
            pChoice = int.Parse(Console.ReadLine());

            if (pChoice == 1)
            {
                StartArvontakone();
            }
            else
            {
                MainMenu();
            }
        }

        static void PrintDeathRollTable(int[] aTable)
        {
            int dRTable;

            for (int i = 0; i < aTable.Length; i++)
            {
                Console.WriteLine(aTable[i]);
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine("1. Arvo uudelleen!");
            Console.WriteLine("2. Palaa päävalikkoon");
            Console.Write(Environment.NewLine);
            Console.Write(": ");
            dRTable = int.Parse(Console.ReadLine());

            if (dRTable == 1)
            {
                StartDeathroll();
            }
            else
            {
                MainMenu();
            }
        }
    }
}