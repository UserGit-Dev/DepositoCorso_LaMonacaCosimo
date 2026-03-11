class Program
{
    private static ITorta? torta;
    static void Main()
    {
        bool flag = true;

        while(flag) 
        {
            int scelta;

            do {
                Console.Clear();
                Console.WriteLine(new string('=', 5) + " Terminale (Pasticceria) " + new string('=', 5));
                Console.WriteLine("Seleziona:\n1. Crea torta (Cioccolato)\n2, Crea torta (Vaniglia)\n3. Crea torta (Frutta)\n4. (Esci)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 4);

            switch (scelta)
            {
                case >= 1 and <= 3:
                    Console.Clear();
                    CreaTorta(scelta);
                    ContinueAndClear();
                    break;
                case 4:
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    ContinueAndClear();
                    break;
            }
        }
    }

    public static void CreaTorta(int scelta)
    {
        string tipoTorta = scelta switch { 1 => "Cioccolato", 2 => "Vaniglia", 3 => "Frutta", _ => string.Empty };
        //TortaFactory tortaFactory = new();
        //torta = tortaFactory.CreaTorta(tipoTorta);
        torta = TortaFactory.Instance.CreaTorta(tipoTorta);

        if (torta is null) { Console.WriteLine("Errore durante creazione della torta."); return; }

        bool flag = true;
        while (flag) {
            ConsoleKeyInfo continuare;
            
            do {
                Console.Clear();
                Console.WriteLine("Vuoi aggiungere altro? (S/N): ");
                continuare = Console.ReadKey(true);
            } while (continuare.Key is not (ConsoleKey.S or ConsoleKey.N));

            if (continuare.Key is ConsoleKey.N) { Console.WriteLine("Pronta! => " + torta?.Descrizione()); return; }
            
            do {
                Console.Clear();
                Console.WriteLine($"Torta base selezionata: {tipoTorta}\n");
                Console.WriteLine("Cos'altro vuoi aggiungere?\nA. Panna\nB. Fragole\nC. Glassa");
                continuare = Console.ReadKey(true);
            } while (continuare.Key is not (ConsoleKey.A or ConsoleKey.B or ConsoleKey.C));

            if (continuare.Key is ConsoleKey.A) { torta = new ConPanna(torta); }
            if (continuare.Key is ConsoleKey.B) { torta = new ConFragole(torta); }
            if (continuare.Key is ConsoleKey.C) { torta = new ConGlassa(torta); }
            
            Console.Clear();
            Console.WriteLine("Ingrediente aggiunto con successo.");
            ContinueAndClear();
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