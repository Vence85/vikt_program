

using System.ComponentModel;

bool isrunning = true;

List<double> viktlista = new List<double>();
while (isrunning)

{
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("[1]Lägg in vikt");
    Console.WriteLine("[2]Kolla medelvikt de senaste 7 dagarna");
    Console.WriteLine("[3]Kolla lägsta vikt");
    Console.WriteLine("[Q]Avsluta");
    Console.WriteLine("==============================================");

    string menyInput = Console.ReadLine();

    switch (menyInput)
    {
        case "1":
            Console.WriteLine("Ange vikt eller skriv 'Q' för att go tillbaka till menyn:");
            string input = Console.ReadLine();
            if (input.ToLower() == "q")
            {
                break;
            }
            if (double.TryParse(input, out double vikt))
            {
                viktlista.Add(vikt);
                Console.WriteLine($"Du lade in vikten {vikt} i listan.");
                Console.WriteLine("Tryck 'D' för att ta bort den inlagda vikten eller 'B' för att bekrafta:");

                                  
            }
            else
            {
                Console.WriteLine("Felaktig inmatning, försök igen!");
            }            
            break;

        case "2":
            break;

        case "3":
            break;

        case "q":
            break;
    }
}