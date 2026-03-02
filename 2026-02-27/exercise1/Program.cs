class Program()
{
    public static void Main(string[] args)
    {
        ExerciseOne();
        ExerciseTwo();
        ExerciseThree();

        Dictionary<int, string> esempio = new();
        esempio.Add(1, "a");
        Console.WriteLine(esempio[1]);
        Console.ReadKey();
    }

    public static void Continue()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey();
        Console.Write("\x1b[3j");
        Console.Clear();
    }

    public static void ExerciseOne()
    {
        Studente studente1 = new("Franco", 1, 10);
        Studente studente2 = new("Paolo", 2, 5);

        Console.WriteLine(new string('=', 50) + $"\nLista studenti\n" + new string('-', 15));
        Console.WriteLine($"Nome: {studente1.nome, -7} Matricola: {studente1.matricola, -2} Media: {studente1.mediaVoti}");
        Console.WriteLine($"Nome: {studente2.nome, -7} Matricola: {studente2.matricola, -2} Media: {studente2.mediaVoti}");
        Console.WriteLine(new string('=', 50));
        Continue();
    }

    public static void ExerciseTwo()
    {
        Persona persona1 = new("Franco", "Amendola", 2010);
        Persona persona2 = new("Paolo", "Venditti", 2009);

        Console.WriteLine(new string('=', 50) + $"\nLista persone\n" + new string('-', 15));
        Console.WriteLine($"Nome: {persona1.nome, -7} Cognome: {persona1.cognome, -9} Nato il: {persona1.annoNascita}");
        Console.WriteLine($"Nome: {persona2.nome, -7} Cognome: {persona2.cognome, -9} Nato il: {persona2.annoNascita}");
        Console.WriteLine(new string('=', 50));
        Continue();
    }

    public static void ExerciseThree()
    {
        Operazioni operazione = new();
        int num1;
        int num2;

        do {
            Console.Clear();
            Console.WriteLine("Risultato di somma e moltiplicazione...");
            Console.Write("Inserisci il primo numero: ");
        } while(!int.TryParse(Console.ReadLine()!, out num1));
        
        do {
            Console.Clear();
            Console.WriteLine("Risultato di somma e moltiplicazione...");
            Console.Write("Inserisci il secondo numero: ");
        } while(!int.TryParse(Console.ReadLine()!, out num2));

        int somma = operazione.Somma(num1, num2);
        int moltiplicazione = operazione.Moltiplica(num1, num2);
        operazione.StampaRisultato("Somma", somma);
        operazione.StampaRisultato("Moltiplicazione", moltiplicazione);

        Continue();
    }
}