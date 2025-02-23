

using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

bool isrunning = true;

double totalWeight = 0;
double totalWeightDivided = 0;
List<double> weightList = new List<double>();

while (isrunning)

{
    //Meny
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("[1]Lägg in vikt");
    Console.WriteLine("[2]Kolla medelvikt de senaste 7 dagarna");
    Console.WriteLine("[3]Kolla lägsta snittvikt");
    Console.WriteLine("[4]Kolla lägsta vikt");
    Console.WriteLine("[Q]Avsluta");
    Console.WriteLine("==============================================");

    string menyInput = Console.ReadLine();

    switch (menyInput)
    {
        // Saving input in list
        case "1":
            Console.WriteLine("Ange vikt eller skriv 'Q' för att go tillbaka till menyn:");
            Console.WriteLine("(Decimaltal bryts av med ett kommatecken!)");
            string input = Console.ReadLine();
            if (input.ToLower() == "q")
            {
                break;
            }
            else if (double.TryParse(input, out double weight))
            {
                weightList.Add(weight);
                Console.WriteLine($"Du lade in vikten {weight} i listan.");
                Console.WriteLine("Tryck 'D' för att ta bort den inlagda vikten eller 'B' för att bekräfta:");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "d")
                {
                    weightList.RemoveAt(weightList.Count - 1);
                    break;
                }
                else if (choice.ToLower() == "b")
                {
                    Console.WriteLine("Vikten lades in korrekt!");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, försök igen!");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
                Thread.Sleep(2000);

            }
            break;

        case "2":
            if (weightList.Count() >= 7)
            {
                List<double> lastSeven = weightList.GetRange(weightList.Count() -7, 7);
                foreach (double n in lastSeven)
                {
                    totalWeight = totalWeight + n;
                }
                totalWeightDivided = totalWeight / 7;
                Console.WriteLine(totalWeightDivided);
            }    
            else
            {
                
            }

            foreach (var w in weightList)
            { 
                Console.WriteLine(w);
            }
            
            Console.WriteLine("============================");
            Console.WriteLine("Tryck 'Enter' för att gå vidare");
            Console.ReadKey();
            break;

        case "3":
            break;

        case "4":
            break;

        case "q":
            break;
    }
}