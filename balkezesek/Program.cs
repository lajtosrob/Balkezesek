using System.Security.Cryptography.X509Certificates;
using balkezesek;
// See https://aka.ms/new-console-template for more information

namespace balkezesek;
class Program
{
    static List<Balkezes> balkezesek = new List<Balkezes>();
    static void Main(string[] args)
    {

        //2. adatbeolvasás 

        /* string[] sorok = File.ReadAllLines("DataSource\\balkezesek.csv");


        for (int i = 1; i < sorok.Length; i++)
        {

            string[] adatok = sorok[i].Split(';');

            string nev = adatok[0];
            DateTime elso = DateTime.Parse(adatok[1]);
            DateTime utolso = DateTime.Parse(adatok[2]);
            int suly = Convert.ToInt32(adatok[3]);
            int magassag = Convert.ToInt32(adatok[4]);

            Balkezes balkezesSor = new(nev, elso, utolso, suly, magassag);

            balkezesek.Add(balkezesSor);
        } */

        StreamReader sr = new StreamReader("Datasource\\balkezesek.csv");

        string headerLine = sr.ReadLine();

        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(';');

            Balkezes BalkezesDatas = new Balkezes(
                line[0],
                DateTime.Parse(line[1]),
                DateTime.Parse(line[2]),
                int.Parse(line[3]),
                int.Parse(line[4])
                );

            balkezesek.Add( BalkezesDatas );
        }

        //3.

        Console.WriteLine("3. feladat: " + balkezesek.Count());

        //4. 

        Console.WriteLine("4. feladat: ");
        foreach (var person in balkezesek)
        {
            if(person.Utolso <= DateTime.Parse("1999. 10. 31.") && person.Utolso >= DateTime.Parse("1999. 10. 01 "))
            {
                Console.WriteLine($"\t{person.Nev}, {Math.Round(person.Magassag *2.54, 1)} cm");
            }
        }

        Console.WriteLine();
        List<Balkezes> ujbalkezesek =  balkezesek.Where(x => x.Utolso >= DateTime.Parse("1999. 10. 01") && x.Utolso <= DateTime.Parse("1999. 10 31"))
            .ToList();

        ujbalkezesek.ForEach(x => Console.WriteLine($"\t{ x.Nev} {Math.Round(x.Magassag * 2.54, 1)}"));

        //5.

        int evszam;
        bool rosszSzam = true;
        Console.Write("5. feladat: \nKérek egy 1990 és 1999 közötti évszámot!: ");
        do
        {
            evszam =  int.Parse(Console.ReadLine());
            if (evszam > 1999 || evszam < 1990)
            {
                Console.Write("Hibás adat! Kérek egy 1990 és 1999 közötti évszámot!: ");
            }
            else
            {
                rosszSzam = false;
            }
        } while (rosszSzam);

        //6. 

        List<Balkezes> evszamBalkezes = balkezesek.Where(x => x.Elso.Year <= evszam && x.Utolso.Year >= evszam).ToList();

        Console.WriteLine($"6. feladat: {Math.Round(evszamBalkezes.Average(x => (x.Suly)), 2)} font");

        
    }
}