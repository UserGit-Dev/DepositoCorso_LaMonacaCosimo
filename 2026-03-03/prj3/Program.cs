
class Program
{
    public static void Main()
    {
        List<Soldato> listSoldati = [];
        bool flag = true;
        while(flag)
        {
            
            int scelta;
            do {
                Console.Clear();
                Console.WriteLine($"Opzioni:\n1. Aggiungi Fante\n2. Aggiungi Artigliere\n3. Visualizza Esercito\n0. (Esci)");
            } while(!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 3);

            switch (scelta)
            {
                case 1:
                    string c1nome;
                    string c1grado;
                    int c1anniServizio;
                    string c1arma;

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci il nome: ");
                        c1nome = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1nome));

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci il grado: ");
                        c1grado = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1grado));

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci anni di servizio: ");
                    } while(!int.TryParse(Console.ReadLine()!, out c1anniServizio) || c1anniServizio is < 0);

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci l'arma: ");
                        c1arma = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1arma));

                    listSoldati.Add(new Fante(c1nome, c1grado, c1anniServizio, c1arma));
                    Console.WriteLine("Fante aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 2:
                    string c2nome;
                    string c2grado;
                    int c2anniServizio;
                    string c2calibro;

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci il nome: ");
                        c2nome = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2nome));

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci il grado: ");
                        c2grado = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2grado));

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci anni di servizio: ");
                    } while(!int.TryParse(Console.ReadLine()!, out c2anniServizio) || c2anniServizio is < 0);

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci l'arma: ");
                        c2calibro = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2calibro));

                    listSoldati.Add(new Artigliere(c2nome, c2grado, c2anniServizio, c2calibro));
                    Console.WriteLine("Artigliere aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 3:
                    Console.Clear();
                    if (listSoldati.Count is 0) { Console.WriteLine("Esercito attualmente privo di soldati."); }
                    else {
                        foreach(Soldato soldato in listSoldati)
                        {
                            if (soldato is Fante fante) fante.Descrizione();
                            if (soldato is Artigliere artigliere) artigliere.Descrizione();
                        }
                    }
                    ContinueAndClear();
                    break;
                case 0:
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    ContinueAndClear();
                    break;
            }
        }
    }

    public static void ContinueAndClear()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3j");
        Console.Clear();
    }
}