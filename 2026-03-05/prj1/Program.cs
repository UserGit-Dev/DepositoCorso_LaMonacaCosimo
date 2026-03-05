enum TipoOperatore
{
    Amministratore,
    Dipendente
}

class Program : IConsoleUtility
{
    static List<Dipendente> listDipendente = [];
    public static void Main()
    {
        bool flag = true;
        while (flag)
        {
            int scelta;
            
            do {
                Console.Clear();
                Console.WriteLine("Seleziona:\n1. Amministratore\n2. Dipendente\n3. (Esci)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 3);

            switch (scelta)
            {
                case 1:
                    Console.Clear();
                    Validazione(TipoOperatore.Amministratore);
                    ContinueAndClear();
                    break;
                case 2:
                    Console.Clear();
                    Validazione(TipoOperatore.Dipendente);
                    ContinueAndClear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    ContinueAndClear();
                    break;
            }
        }
    }

    public static void ValidazioneAmministratore() { Console.WriteLine("OK!"); Console.ReadKey(true); }

    public static void ValidazioneDipendente(TipoOperatore tipoOperatore)
    {
        if (listDipendente.Count is 0) {
            Console.Clear();
            Console.WriteLine("Problema interno del server. Processo di validazione annullata.");
            ContinueAndClear();
            return;
        }

        bool isDataCorrect;
        string badgeCode;
        string password;
        
        do {
            Console.Clear();
            Console.WriteLine("Inserisci il codice codice del tuo badge: ");
            badgeCode = Console.ReadLine()!.ToUpper();
        } while (string.IsNullOrWhiteSpace(badgeCode));
        
        do {
            Console.Clear();
            Console.WriteLine("Inserisci la tua password: ");
            password = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(password));

        foreach(Dipendente dipendente in listDipendente)
        {
            if (dipendente.BadgeCode is badgeCode and dipendente.Password is password) { isDataCorrect = true; break; }
        }

        if (!isDataCorrect) { 
            Console.Clear();
            Console.WriteLine("Errore, i dati forniti non sono corretti.");
            break;
        }
    }
}