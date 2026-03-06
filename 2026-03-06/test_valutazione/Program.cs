class Program
{
    static Random random = new();
    static List<Animale> listAnimale = [];
    public static void Main()
    {
        bool flag = true;

        while (flag)
        {
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto!\n\nSeleziona:\n1. Aggiungi (Mucca)\n2. Aggiungi (Gallina)\n3. Aggiungi (Pecora)\n" 
                    + $"4. Aggiungi (Maiale)\n5. Rimuovi (Animale)\n6. Visualizza info (Animali)\n7. (Esci)\n");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 7);

            switch (scelta)
            {
                case >= 1 and <= 4:
                    Console.Clear();
                    AddAnimal(scelta);
                    break;
                case 5:
                    Console.Clear();
                    RemoveAnimal();
                    break;
                case 6:
                    Console.Clear();
                    if (listAnimale.Count is 0) { Console.WriteLine("Lista animali attualmente vuota."); }
                    else { foreach(Animale animale in listAnimale) { animale.PrintInfo(); } }
                    ContinueAndClear();
                    break;
                case 7:
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    ContinueAndClear();
                    break;
            }
        }
    }

    public static void AddAnimal(int scelta)
    {
        // Verifico se il numero scelto
        if (!Enum.IsDefined(typeof(TipoAnimale), scelta)) {
            Console.WriteLine("Scelta non valida! L'animale non esiste in archivio.");
            return;
        } 
        
        // Facciamo il cast sicuro
        TipoAnimale tipoAnimale = (TipoAnimale)scelta;
        int id = random.Next();
        string nome;
        int eta;

        do {
            Console.Clear();
            Console.Write("Inserisci nome dell'animale: ");
            nome = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(nome));
        
        do {
            Console.Clear();
            Console.Write("Inserisci età dell'animale: ");
        } while (!int.TryParse(Console.ReadLine()!, out eta) || eta < 0);

        switch(tipoAnimale){
            case TipoAnimale.Mucca:
                Console.Clear();
                listAnimale.Add(new Mucca(id, nome, eta));
                Console.WriteLine("Animale aggiunto con successo.");
                ContinueAndClear();
                break;
            case TipoAnimale.Gallina:
                Console.Clear();
                listAnimale.Add(new Gallina(id, nome, eta));
                Console.WriteLine("Animale aggiunto con successo.");
                ContinueAndClear();
                break;
            case TipoAnimale.Pecora:
                Console.Clear();
                listAnimale.Add(new Pecora(id, nome, eta));
                Console.WriteLine("Animale aggiunto con successo.");
                ContinueAndClear();
                break;
            case TipoAnimale.Maiale:
                Console.Clear();
                listAnimale.Add(new Maiale(id, nome, eta));
                Console.WriteLine("Animale aggiunto con successo.");
                ContinueAndClear();
                break;
        }
        return;
    }

    public static void RemoveAnimal()
    {
        int id;
        int idx = -1;

        do {
            Console.Clear();
            Console.Write("Inserisci ID dell'animale: ");
        } while (!int.TryParse(Console.ReadLine()!, out id) || id < 0);

        for (int i = 0; i < listAnimale.Count; i++) { if (listAnimale[i].Id == id) { idx = i; } }

        if (idx is -1) { Console.Clear(); Console.WriteLine("ID non trovato."); }
        else { listAnimale.RemoveAt(idx); Console.WriteLine("Animale rimosso con successo."); }
        ContinueAndClear();
    }

    public static void ContinueAndClear()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3j");
        Console.Clear();
    }
}