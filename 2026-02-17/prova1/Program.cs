Console.WriteLine("Inserisci il primo numero: ");
int a = int.Parse(Console.ReadLine()!);
Console.WriteLine("Inserisci il secondo numero: ");
int b = int.Parse(Console.ReadLine()!);

if (a > b)
{
    Console.WriteLine($"{a} è più grande di {b}");
} else
{
    Console.WriteLine($"{b} è più grande di {a}");
}