// Esercizi IF

// 1
Console.WriteLine("Inserisci la tua età: ");
int età = int.Parse(Console.ReadLine()!);

if (età >= 18) { Console.WriteLine("Sei maggiorenne!"); }
if (età < 18) { Console.WriteLine("Sei minorenne!"); }

Console.WriteLine();

// 2
Console.WriteLine("Inserire il prezzo del prodotto: ");
int sconto = 10;
double prezzo = double.Parse(Console.ReadLine()!);

if (prezzo > 100)
{
    prezzo -= (prezzo / 100) * sconto;
    Console.WriteLine($"Prezzo finale (scontato): {prezzo}");
}

Console.WriteLine();

// 3
Console.WriteLine("Inserire il primo numero");
double num1 = double.Parse(Console.ReadLine()!);
Console.WriteLine("Inserire il secondo numero");
double num2 = double.Parse(Console.ReadLine()!);
Console.WriteLine("Inserire il terzo numero");
double num3 = double.Parse(Console.ReadLine()!);

double totale = num1 + num2 + num3;

if ((int)totale > 60) { Console.WriteLine("Hai superato la prova!"); }
if ((int)totale < 60) { Console.WriteLine("Prova fallita."); }

Console.WriteLine();

// Opzionale (Operatori logici) -> Si, molto nonsense.
Console.WriteLine("Inserire numeri maggiori di 100!");
Console.WriteLine("Primo numero: ");
double num1 = double.Parse(Console.ReadLine()!);
Console.WriteLine("Secondo numero: ");
double num2 = double.Parse(Console.ReadLine()!);
Console.WriteLine("Hai sbagliato nel rispettare i requisiti richiesti (true/false)?: ");
bool isWrong = bool.Parse(Console.ReadLine()!);

if ((num1 >= 100 && num2 >= 100) || !isWrong)
{
    Console.WriteLine("Ok!");
}

string a = Console.ReadKey