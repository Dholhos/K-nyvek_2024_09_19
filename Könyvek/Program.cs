using Könyvek;
using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Linq;

namespace Konyvek
{
    public class Konyv
    {
        public string cim { get; set; }
        public string szerzo { get; set; }
        public string mufaj { get; set; }
        public int megJelenes { get; set; }
        public int oldalSzam { get; set; }


    }
    internal class Program
    {
          static  List<Konyv> konyvek = new List<Konyv>();
        static void Main(string[] args)
        {
             Beolvasas();
             //FeladatMasodik();
             //FeladatHarmadik();
             //FeladatNegyedik();
             FeleadatOtodik();
        }  
           static void Beolvasas() { 
            StreamReader sr = new StreamReader("konyvek.txt");
                string sor;
                while (!sr.EndOfStream)
                {
                    sor = sr.ReadLine();
                    string[] adatok = sor.Split(',');
                    Konyv film = new Konyv()
                    { 
                        cim = adatok[0],
                        szerzo = adatok[1],
                        megJelenes = int.Parse(adatok[2]),
                        oldalSzam = int.Parse(adatok[3]),
                        mufaj = adatok[4]
                    };
                    konyvek.Add(film);
                }
            }

            static void FeladatMasodik()
            {
                Console.WriteLine("2.feladat\n");
                Console.Write("Írjon be egy szerzőt: ");
                string szerzo = Console.ReadLine();
                foreach (var item in konyvek)
                {
                    if (item.szerzo == szerzo)
                    {
                        Console.Write($"\t{item.cim}\t");
                    }
                }
            }   

            static void FeladatHarmadik()
            {
                Console.WriteLine("\n3.feladat\n");
                int legnagyobbOldalszam = 0;
                string leghosszabbKonyv = "";
                foreach (var item in konyvek)
                {
                    if (legnagyobbOldalszam < item.oldalSzam)
                    {
                        legnagyobbOldalszam = item.oldalSzam;
                        leghosszabbKonyv = item.cim;
                    }
                }
                Console.WriteLine($"\n Ez a leghosszabb könyv{leghosszabbKonyv}");
            }

            static void FeladatNegyedik(){
                Console.WriteLine("4.feladat\n");
                int sorSzam = 0;
                var lista = konyvek.OrderBy(x => x.megJelenes).ToList();
                foreach (var item in lista)
                {
                    Console.WriteLine($"cím: {item.cim} Kiadás éve: {item.megJelenes}");
                }
            }

            static void FeleadatOtodik()
            {
                var mufajok = konyvek.GroupBy(x => x.mufaj);

                foreach (var item in mufajok)
                {
                    Console.WriteLine($"\nműfaj: {item.Key}, Könyvek száma: {item.Count()}");
                    foreach (var konyv in item)
                    {
                        Console.WriteLine($"{konyv.cim}, {konyv.szerzo}, {konyv.mufaj}, {konyv.oldalSzam}, {konyv.megJelenes}");
                    }
                }
            }
        }
    }