class Program
{
    static void Main()
    {
        // Effettuo il seeding degli iscritti
        SeedObs();

        // Nome cliente
        string nomeCliente;

        // Scelta che effettuerà
        int scelta;
        
        // Chiedo all'utente di inserire il suo nome
        do {
            Console.Clear();
            Console.WriteLine(new string('=', 10) + " Terminale " + new string('=', 10));
            Console.Write("Benvenuto!\n\nCome ti chiami?: ");
            nomeCliente = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(nomeCliente));

        // Pulisco console e mostro come gli iscritti vengono avvisati del nuovo cliente per poi chiedere di continuare
        Console.Clear();
        Console.WriteLine("*** Soggetto che avvisa i suoi iscritti del nuovo cliente... ***");
        Subject.Instance.NomeCliente = nomeCliente;
        ContinueAndClear();

        // Chiedo al cliente di effettuare una scelta
        do {
            Console.Clear();
            Console.WriteLine(new string('=', 10) + " Terminale " + new string('=', 10));
            Console.WriteLine("\nSeleziona:\n1. Mangia (Pizza)\n2. Mangia (Hamburger)\n3. Mangia (Insalata)\n4. (Esci)");
        } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 4);

        switch (scelta)
        {
            // 1 a 3 => Sta effettuando un'ordine
            case >= 1 and <= 3:
                Ordina(scelta);
                ContinueAndClear();
                break;
            // Termino la procedura e gli chiedo di premere un tasto per continuare
            case 4:
                Console.Clear();
                Console.WriteLine("Sessione terminata.");
                ContinueAndClear();
                break;
        }
    }
#region // Da commentare...
    public static void Ordina(int scelta)
    {
        // Istanzio (ma non inizializzo) due oggetti
        IPiatto? piatto;
        Chef chef; // Strategy pattern (definirò successivamente in che modo cucinerà il piatto)

        // Memorizzo stringa effettiva dell'ordine selezionato per poi passarla al metodo factory.
        string sceltaEffettiva = scelta switch { 1 => "Pizza", 2 => "Hamburger", 3 => "Insalata", _ => string.Empty };
        // Controllo se la scelta effettiva non sia null o con spazi bianchi. Se così fosse, avvisa dell'errore ed esci.
        if (string.IsNullOrWhiteSpace(sceltaEffettiva)) { Console.Clear(); Console.WriteLine("Errore durante la selezone del piatto."); return; }
        
        // Procedo a creare il piatto effettivo attraverso un oggetto factory.
        piatto = PiattoFactory.CreaPiatto(sceltaEffettiva);
        // Se al ritorno del metodo la variabile 'piatto' è 'null', avvisa dell'errore ed esci.
        if (piatto is null) { Console.WriteLine("Errore durante il processamento della richiesta."); return; }

        // Chiedo se vuole aggiungere altri ingredienti
        ConsoleKeyInfo sceltaExtra;
        do {
            Console.Clear();
            Console.WriteLine($"Piatto attuale: {piatto.Descrizione()}");
            Console.WriteLine($"\nAggiungere altri ingredienti? (S/N)");
            sceltaExtra = Console.ReadKey(true)!;
        } while (sceltaExtra.Key is not (ConsoleKey.S or ConsoleKey.N));

        // Se si...
        if (sceltaExtra.Key is ConsoleKey.S)
        {   
            // Ciclo fino a quando il cliente non vorrà più
            bool flag = true;
            while (flag) {
                ConsoleKeyInfo tipoIngrediente;
                do {
                    Console.Clear();
                    Console.WriteLine($"Piatto attuale: {piatto.Descrizione()}");
                    Console.WriteLine("\nIngredienti da aggiungere:\n1. Formaggio\n2. Bacon\n3. Salsa");
                    tipoIngrediente = Console.ReadKey(true);
                } while (tipoIngrediente.Key is not (ConsoleKey.D1 or ConsoleKey.D2 or ConsoleKey.D3));

                // Riassegno 'piatto' a se stesso "decorato"
                piatto = tipoIngrediente.Key switch {
                    ConsoleKey.D1 => new ConFormaggio(piatto),
                    ConsoleKey.D2 => new ConBacon(piatto),
                    ConsoleKey.D3 => new ConSalsa(piatto),
                    _ => piatto
                };
                
                // Qui chiedo effettivamente se desidera aggiungere altro
                Console.Clear();
                Console.WriteLine("Ingrediente aggiunto! Vuoi continuare ad aggiungere? (S/N)");
                if (Console.ReadKey(true).Key is ConsoleKey.N) flag = false;
            }
        }
        
        // Alla fine, chiedo il tipo di cottura
        ConsoleKeyInfo tipoCottura;
        do {
            Console.Clear();
            Console.WriteLine("Tipo cottura:\n1. Fritto\n2. Al forno\n3. Alla griglia");
            tipoCottura = Console.ReadKey(true)!;
        } while (tipoCottura.Key is not (ConsoleKey.D1 or ConsoleKey.D2 or ConsoleKey.D3));

        // In base al tipo di input, associo il tipo di strategia allo chef
        if(tipoCottura.Key is ConsoleKey.D1) chef = new Chef(new Fritto());
        else if(tipoCottura.Key is ConsoleKey.D2) chef = new Chef(new AlForno());
        else if(tipoCottura.Key is ConsoleKey.D3) chef = new Chef(new AllaGriglia());
        else { Console.WriteLine("Errore durante la selezione della frittura."); return; }

        Console.Clear();
        // Chiamo i metodi 'decorati' di 'piatto'
        Console.WriteLine(piatto.Descrizione() + " => " + piatto.Prepara());
        chef.PreparaPiatto();
    }

    // Metodo per gener
    public static void SeedObs()
    {
        Subject.Instance.Attach(new Observer("Aldo"));
        Subject.Instance.Attach(new Observer("Giovanni"));
        Subject.Instance.Attach(new Observer("Giacomo"));
    }

    // Metodo per chiedere l'utente di proseguire assieme alla pulizia della console
    public static void ContinueAndClear()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3j");
        Console.Clear();
    }
    #endregion
}
