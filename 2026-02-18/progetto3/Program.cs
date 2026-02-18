// 1. 
Console.Write("Inserisci il numero da moltiplicare: ");
int num = int.Parse(Console.ReadLine()!);

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{num} * {i} = {num * i}");
}

Console.WriteLine();

Console.Write("Inserire il quantitativo di numeri per calcolare la loro media: ");
int qnt = int.Parse(Console.ReadLine()!);
int totale = 0;

for (int i = 1; i <= qnt; i++)
{
    Console.Write($"Inserire {i}° numero: ");
    totale += int.Parse(Console.ReadLine()!);
    Console.Clear();
}

Console.WriteLine($"Media: {totale / qnt}");
Console.WriteLine();

// 3.
Console.Write("Inserisci un numero intero positivo: ");
int num = int.Parse(Console.ReadLine()!);

if(num > 0) {
    for (int i = num - 1; i > 0; i--) {
        num *= i;
    }
    
    Console.WriteLine($"Risultato del fattoriale: {num}");
}
else {
    Console.WriteLine("Numero inserito non valido");
}
