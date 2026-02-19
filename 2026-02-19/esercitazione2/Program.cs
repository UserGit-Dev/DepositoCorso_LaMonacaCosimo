class Program
{
    static void Main(string[] args)
    {
        StampaSaluta();  
        CheckPariDispari();
        CalcoloPotenza();
    }
    
    public static void StampaSaluta()
    {
        string nome;

        Console.Write("\nInserisci il nome da salutare: ");
        nome = Console.ReadLine()!;
        Console.WriteLine($"Ciao {nome}!");
    }

    public static void CheckPariDispari()
    {
        int num;

        Console.Write("\nInserisci il numero da verificare: ");
        num = int.Parse(Console.ReadLine()!);

        if (num % 2 == 0) { Console.WriteLine($"Il numero è pari!"); }
        else { Console.WriteLine($"Il numero è dispari!"); }
    }

    public static void CalcoloPotenza()
    {
        int num;
        int pwr;

        Console.Write("\nInserisci il numero da cui calcolare: ");
        num = int.Parse(Console.ReadLine()!);
        Console.Write("Inserisci la potenza: ");
        pwr = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"{num} ^ {pwr} = {Math.Pow(num, pwr)}");
    }
}