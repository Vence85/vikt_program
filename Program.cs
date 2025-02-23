

using System.Text.Json;

// Metod för att spara viktlistan i en JSON-fil
void SaveWeightList(List<double> weightList, string filePath)
{
    // Serialisera listan till en JSON-sträng
    string jsonString = JsonSerializer.Serialize(weightList);
    // Skriv JSON-strängen till filen
    File.WriteAllText(filePath, jsonString);
}

// Metod för att läsa in viktlistan från en JSON-fil
List<double> LoadWeightList(string filePath)
{
    if (File.Exists(filePath))
    {
        // Läs in hela filen som en sträng
        string jsonString = File.ReadAllText(filePath);
        // Deserialisera strängen till en lista med double
        return JsonSerializer.Deserialize<List<double>>(jsonString);
    }
    else
    {
        // Om filen inte finns, returnera en tom lista
        return new List<double>();
    }
}

// Exempel på hur du kan använda dessa metoder i ditt program
string filePath = "weights.json";

// Vid programmets start, försök läsa in sparad data
List<double> weightList = LoadWeightList(filePath);

bool isrunning = true;

double totalWeight = 0;

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
        // Saving input to list
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
                Console.WriteLine("Tryck 'D' för att göra om eller 'B' för att bekräfta:");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "d")
                {
                    break;
                }
                else if (choice.ToLower() == "b")
                {
                    weightList.Add(weight);
                    Console.WriteLine($"Du lade in vikten {weight} i listan.");
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
                List<double> lastSeven = weightList.GetRange(weightList.Count() - 7, 7);
                foreach (double n in lastSeven)
                {
                    totalWeight = totalWeight + n;
                }
                double totalWeightDivided = totalWeight / 7;
                Console.WriteLine($"Din genomsittsvikt de senaste sju dagarna är {totalWeightDivided:0.0}!");
                totalWeight = 0;
            }
            else if (weightList.Count() > 0)
            {
                int count = weightList.Count();
                foreach (double n in weightList)
                {
                    totalWeight = totalWeight + n;
                }
                double totalWeightDividedX = totalWeight / count;
                Console.WriteLine($"Du har {count} vägningar och ditt genomsnitt är {totalWeightDividedX:0.0}");
            }

            else
            {
                Console.WriteLine("Det finns inga vägningar sparade!");
                Console.WriteLine("Tryck 'Enter' för att gå vidare");
                Console.ReadKey();
                break;
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
            isrunning = false;
            break;
    }
    SaveWeightList(weightList, filePath);
}