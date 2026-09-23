Console.WriteLine("Mata in en rad med mestadels siffror: "); // Efterfrågar visst input
string input = Console.ReadLine(); // Skapar string utifrån input
long slutsumma = 0; // Skapar long variabel för slutsumman
Console.WriteLine(); // Skriver tom rad för att separera input från output

for (int startSiffra = 0; startSiffra < input.Length; startSiffra++) // Loopar igenom varje tecken i input
{
    if (!char.IsDigit(input[startSiffra])) // Fortsätter ovanstående loop om tecknet ej är en siffra
        continue;

    for (int slutSiffra = startSiffra + 1; slutSiffra < input.Length; slutSiffra++) // Loopar igenom nästkommande tecken efter likadan slutSiffra
    {
        if (input[slutSiffra] != input[startSiffra]) // Fortsätter ovanstående loop om slutSiffra =/= startSiffra
            continue;

        bool giltigDelsträng = true; // skapar bool för om start- och slutSiffra är lika och delsträngen således giltig

        for (int i = startSiffra + 1; i < slutSiffra; i++) // Loopar igenom tecknen mellan start- och slutSiffra
        {
            if (!char.IsDigit(input[i]) || input[i] == input[startSiffra]) // Ogiltigförklarar delsträngen och bryter loopen om tecknet ej är en siffra eller är samma som startSiffra (mellan start- och Slutsiffra)
            {
                giltigDelsträng = false;
                break;
            }
        }

        if (giltigDelsträng) // Körs om delsträngen är giltig
        {
            string talSträng = input.Substring(startSiffra, slutSiffra - startSiffra + 1); // Skapar en delsträng mellan startSiffra och Y och (slutSiffra X - startSiffra Y +1 ) antal tecken fram

            slutsumma += long.Parse(talSträng); // Adderar delsträngen som long till slutsumman

            Console.Write(input.Substring(0, startSiffra)); // Skriver ut tecknen fram till startSiffra (utan ny rad eller textfärg)
            Console.ForegroundColor = ConsoleColor.Magenta; // Ändrar textfärg till magenta
            Console.Write(talSträng); // Skriver ut delsträngen (i magenta)
            Console.ResetColor(); // Återställer textfärg till default
            Console.WriteLine(input.Substring(slutSiffra + 1)); // Skriver ut tecknen efter slutsiffra (följt av radbryt)
        }
        break; // Bryter loopen och återgår till ovanstående loop igen
    }
}

Console.Write($"\nSlutsumman blir: "); // Skriver ut vad slutsumman blir på ny rad, och slutsumman i magenta:)
Console.ForegroundColor = ConsoleColor.Magenta; // Ändrar färg på texten till magenta (igen)
Console.Write((slutsumma)); // Skriver ut slutsumman av alla giltiga delsträngar (i magenta)
Console.ResetColor(); // Återställer färgen på texten till default (igen)
Console.WriteLine(); // Avslutar med tom rad. Neat and tidy.