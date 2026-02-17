// 4. Somma tra Intero e Float
Console.WriteLine("Inserisci numero intero (int): ");
int num1 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Inserisci un numero con la virgola (float)");
float num2 = float.Parse(Console.ReadLine()!);
Console.WriteLine("Risultato: " + (num2 + num1));

Console.WriteLine();

// 5. Età e Altezza con Casting
Console.WriteLine("Inserisci la tua età (int): ");
int età = int.Parse(Console.ReadLine()!);
Console.WriteLine("Inserisci la tua altezza (float): ");
float altezza = float.Parse(Console.ReadLine()!);
Console.WriteLine(altezza + età);

Console.WriteLine();

// 6. Operatori
Console.Write("Inserisci età: ");
int eta = int.Parse(Console.ReadLine()!);
Console.Write("Ha la patente? (true/false): ");
bool patente = bool.Parse(Console.ReadLine()!);
Console.Write("È accompagnato? (true/false): ");
bool accompagnato = bool.Parse(Console.ReadLine()!);
Console.Write("È sospeso dalla guida? (true/false): ");
bool sospeso = bool.Parse(Console.ReadLine()!);
Console.WriteLine("Risultato: " + ((eta >= 18 && patente || accompagnato) && !sospeso));
