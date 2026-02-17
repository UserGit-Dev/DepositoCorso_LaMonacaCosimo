// 1.
bool statoCiclo1 = true;
int totale = 0;

while (statoCiclo1)
{
    Console.WriteLine("Inserire numeri interi: ");
    int num = int.Parse(Console.ReadLine()!);

    if (num > 0) { 
        totale += num;
        Console.Clear();
        Console.WriteLine("Numero memorizzato, vai col prossimo.");
        Console.WriteLine();
    } else { 
        statoCiclo1 = false;
        Console.Clear();
        Console.WriteLine($"Totale: {totale}"); 
    }
}

Console.WriteLine();

// 2.
bool statoCiclo2 = true;
int numeroSegreto = 777;

while (statoCiclo2)
{
    Console.WriteLine("Indovina il numero segreto!");
    Console.WriteLine("Inserisci numero (int): ");
    int num = int.Parse(Console.ReadLine()!);

    if (num == numeroSegreto)
    {
        Console.Clear();
        Console.WriteLine("Indovinato!");
        statoCiclo2 = false;
    } else
    {
        Console.Clear();
        Console.WriteLine("Ritenta, sarai più fortunato");
        Console.WriteLine();
    }
}