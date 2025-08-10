using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    internal class Program
    {
        static Dictionary<string, int> scores = new Dictionary<string, int>
            {
            {"Emma", 18},
            {"Liam", 19 },
            {"Noah", 17 },
            {"Olivia", 20 }

            };





        static void Main(string[] args)
        {




            Console.WriteLine("Welkom bij het Klassement Beheer Systeem!");
            Console.WriteLine("Kies een optie uit het menu:");

            Console.WriteLine("");
            int inputUser;
            do
            {
                Console.WriteLine("1. Toon het klassement");
                Console.WriteLine("2. Zoek de score van een deelnemer");
                Console.WriteLine("3. Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
                Console.WriteLine("4. Toon de gemiddelde score ");
                Console.WriteLine("5. Toon de deelnemer met de hoogste score ");
                Console.WriteLine("6. Stop het programma ");
                Console.WriteLine("Maak uw keuze: ");

                inputUser = int.Parse(Console.ReadLine());

                switch (inputUser)
                {
                    case 1:
                        foreach (var item in scores)
                        {
                            Console.WriteLine($"- {item.Key}: {item.Value} punten");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Geef de naam van een deelnemer: ");
                        string gekozenNaam = Console.ReadLine();
                        bool validNam = scores.TryGetValue(gekozenNaam, out int punten);
                        if (validNam)
                        {
                            Console.WriteLine($"{gekozenNaam} heeft {punten} punten");
                        }
                        else
                        {
                            Console.WriteLine($"{gekozenNaam} staat niet in het klassement!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Geef de naam van een deelnemer:");
                        string deelNemer = Console.ReadLine();
                        bool exists = scores.ContainsKey(deelNemer);

                        if (exists)
                        {
                            Console.Write("Geef de nieuwe score");
                            int score = int.Parse(Console.ReadLine());
                            scores[deelNemer] = score;
                            Console.WriteLine($"De score van {deelNemer} is bijgewerkt naar {score} punten.");
                        }
                        else
                        {
                            Console.Write("Geef de naam van een nieuwe deelnemer: ");
                            string nieuweDeelnemer = Console.ReadLine();
                            Console.WriteLine("Geef de score van een nieuwe deelnemer: ");
                            int score = int.Parse(Console.ReadLine());
                            scores.Add(nieuweDeelnemer, score);
                            Console.WriteLine(nieuweDeelnemer + "is toegevoegd aan het klassement met " + score + " punten.");
                        }
                        break;

                    case 4:
                        int avgScore = 0;
                        foreach (var score in scores.Values)
                        {
                            avgScore += score;
                        }

                        avgScore /= scores.Count();

                        Console.WriteLine("De gemiddelde score is" + "" + avgScore);
                        break;

                    case 5:
                        int hoogsteScore = 0;
                        string deelnemerMetHoogsteScore = "";

                        foreach (var score in scores)
                        {
                            if (score.Value > hoogsteScore)
                            {
                                hoogsteScore = score.Value;
                                deelnemerMetHoogsteScore = score.Key;

                            }
                        }

                        Console.WriteLine("Hoogste score is " + hoogsteScore + " en is behaald door" + " " + deelnemerMetHoogsteScore);

                        break;

                    case 6:
                        Console.WriteLine("Bedankt om het systeem te gebruiken. Tot ziens");
                        Console.ReadLine();
                        break;


                }
            }
            while (inputUser != 6);



        }
    }
}
