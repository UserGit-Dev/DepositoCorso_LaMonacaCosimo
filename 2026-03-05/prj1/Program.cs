class Program : ConsoleUtility
{
    static List<Dipendente> listDipendente = [
        new Dipendente("DEBUG", "NULL", "NULL", DateOnly.Parse("2000-01-01"), 1, TipoFigura.Amministratore, "1", "1", "NULL", 0),
        new Dipendente("Francesco", "Landi", "FRNLND00", DateOnly.Parse("2000-12-12"), 2, TipoFigura.Dipendente, "2", "2", "Mattina", 1500),
    ];

    static Dictionary<long, Queue<string>> dLog = [];

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
                    ValidazioneDipendente(TipoFigura.Amministratore);
                    break;
                case 2:
                    Console.Clear();
                    ValidazioneDipendente(TipoFigura.Dipendente);                
                    break;
                case 3:
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    ContinueAndClear();
                    break;
            }
        }
    }

    public static void ValidazioneDipendente(TipoFigura tipoScelto)
    {
        if (listDipendente.Count is 0) {
            Console.Clear();
            Console.WriteLine("Problema interno del server. Processo di validazione interrotta.");
            ContinueAndClear();
            return;
        }

        Dipendente? dipendeteTrovato = null;
        string badgeCode; // Amministratore/Dipendente
        string password; // Amministratore (Ulteriore controllo)
        
        do {
            Console.Clear();
            Console.WriteLine("Inserisci il codice codice del tuo badge (0: Uscire): ");
            badgeCode = Console.ReadLine()!.ToUpper();
        } while (string.IsNullOrWhiteSpace(badgeCode));
        
        if (badgeCode is "0") {
            Console.Clear();
            Console.WriteLine("Processo di validazione annullata.");
            ContinueAndClear();
            return;
        }

        if (tipoScelto is TipoFigura.Amministratore) {
            do {
                Console.Clear();
                Console.WriteLine("Inserisci la tua password: ");
                password = Console.ReadLine()!;
            } while (string.IsNullOrWhiteSpace(password));
            
            foreach(Dipendente dipendente in listDipendente)
            {
                if (dipendente.Ruolo is TipoFigura.Amministratore 
                    && string.Equals(dipendente.BadgeCode, badgeCode, StringComparison.OrdinalIgnoreCase) 
                    && string.Equals(dipendente.Password,password)) 
                { 
                    dipendeteTrovato = dipendente;
                    break; 
                }
            }
        } else if (tipoScelto is TipoFigura.Dipendente) {
            foreach(Dipendente dipendente in listDipendente)
            {
                if (dipendente.Ruolo is TipoFigura.Dipendente 
                    && string.Equals(dipendente.BadgeCode, badgeCode, StringComparison.OrdinalIgnoreCase)) 
                { 
                    dipendeteTrovato = dipendente;
                    break; 
                }
            }
        }

        if (dipendeteTrovato is null) { 
            Console.Clear();
            Console.WriteLine("Errore, i dati forniti non sono corretti.");
            ContinueAndClear();
            return;
        }

        switch (dipendeteTrovato.Ruolo)
        {
            case TipoFigura.Amministratore:
                dipendeteTrovato.IsActive = true;
                dipendeteTrovato.LastLoginUpdate();
                AddLog(dipendeteTrovato, TipoLog.Login);
                Console.Clear();
                Console.WriteLine("Protocollo di accesso sicuro terminato con successo.");
                ContinueAndClear();
                DashboardAmministratore(dipendeteTrovato);
                break;
            case TipoFigura.Dipendente:
                dipendeteTrovato.IsActive = true;
                dipendeteTrovato.LastLoginUpdate();
                AddLog(dipendeteTrovato, TipoLog.Login);
                Console.Clear();
                Console.WriteLine("Integrità del badge verificata. Accesso concesso.");
                ContinueAndClear();
                DashboardDipendente(dipendeteTrovato);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Errore, tipo figura non riconosciuta dal sistema.");
                ContinueAndClear();
                break;
        }
    }

    public static void DashboardDipendente(Dipendente dipendente)
    {
        bool flag = true;

        while(flag)
        {
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine(new string('*', 5) + " TERMINALE " + new string('*', 5));
                Console.WriteLine(dipendente.ToPrintToDash());
                Console.WriteLine("\nSeleziona:\n1. Modifica (Dati)\n2. Visualizza (Profilo)\n3. Visualizza (Log)\n4. (Logout)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 4);

            switch (scelta)
            {
                case 1:
                    // Incompleto.
                    Console.Clear();
                    Console.WriteLine("Profilo modificato con successo.");
                    AddLog(dipendente, TipoLog.LetturaInfoPersonali);
                    ContinueAndClear();
                    break;
                case 2:
                    Console.Clear();
                    foreach (Dipendente info in listDipendente) { if(info.Id == dipendente.Id) { Console.WriteLine(info.ToPrintAnagraficaCompleta()); } }
                    AddLog(dipendente, TipoLog.LetturaInfoPersonali);
                    ContinueAndClear();
                    break;
                case 3:
                    Console.Clear();
                    if (!dLog.TryGetValue(dipendente.Id, out var coda) || coda.Count is 0) { Console.WriteLine("Storico log attualmente vuoto."); }
                    else { foreach(string log in coda) { Console.WriteLine(log); } }
                    AddLog(dipendente, TipoLog.LetturaLog);
                    ContinueAndClear();
                    break;
                case 4:
                    Console.Clear();
                    flag = false;
                    Logout(dipendente);
                    ContinueAndClear();
                    break;
            }
        }
    }

    public static void DashboardAmministratore(Dipendente dipendente)
    {
        bool flag = true;

        while(flag)
        {
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine(new string('*', 5) + " TERMINALE " + new string('*', 5));
                Console.WriteLine(dipendente.ToPrintToDash());
                Console.WriteLine("\nSeleziona:\n1. Aggiungi dipendente\n2. Visualizza (Profilo)\n3. Visualizza (Dipendenti)\n4. Visualizza (Log)\n5. (Logout)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 5);

            switch (scelta)
            {
                case 1:
                    Random random = new();
                    string nome;
                    string cognome;
                    string codiceFiscale;
                    DateOnly dataNascita;
                    long id = random.NextInt64();
                    TipoFigura ruolo;
                    string badgeCode;
                    string password;
                    string turno;
                    decimal salario;

                    do {
                        Console.Clear();
                        Console.Write("Inserisci il nome: ");
                        nome = Console.ReadLine()!;
                    } while (string.IsNullOrWhiteSpace(nome));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il cognome: ");
                        cognome = Console.ReadLine()!;
                    } while (string.IsNullOrWhiteSpace(cognome));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il codice fiscale: ");
                        codiceFiscale = Console.ReadLine()!;
                    } while (string.IsNullOrWhiteSpace(codiceFiscale));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la data di nascita: ");
                    } while (!DateOnly.TryParse(Console.ReadLine()!, out dataNascita));
                    do {
                        Console.Clear();
                        Console.WriteLine("Seleziona il ruolo:\n1. Amministratore\n2. Dipendente");
                    } while (!Enum.TryParse<TipoFigura>(Console.ReadLine(), true, out ruolo) 
                            || !Enum.IsDefined(typeof(TipoFigura), ruolo));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il codice univoco del badge: ");
                        badgeCode = Console.ReadLine()!;
                    } while (string.IsNullOrWhiteSpace(badgeCode));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la password: ");
                        password = Console.ReadLine()!;
                    } while (string.IsNullOrWhiteSpace(password));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il turno: ");
                        turno = Console.ReadLine()!;
                    } while (string.IsNullOrWhiteSpace(turno));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il salario: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out salario) || salario < 0);
                    listDipendente.Add(new Dipendente(nome, cognome, codiceFiscale, dataNascita, id, ruolo, badgeCode, password, turno, salario));
                    Console.WriteLine("Dipendente aggiunto con successo.");
                    AddLog(dipendente, TipoLog.CreazioneDipendente);
                    ContinueAndClear();
                    break;
                case 2:
                    Console.Clear();
                    foreach (Dipendente info in listDipendente) { if(info.Id == dipendente.Id) { Console.WriteLine(info.ToPrintAnagraficaCompleta()); } }
                    AddLog(dipendente, TipoLog.LetturaInfoPersonali);
                    ContinueAndClear();
                    break;
                case 3:
                    int c2scelta;
                    
                    do {
                        Console.Clear();
                        Console.WriteLine("Seleziona:\n1. Lista info (Persone)\n2. Lista info (Dipendenti)\n3. Lista info (Persone/Dipendenti)\n4. (Annulla)");
                    } while (!int.TryParse(Console.ReadLine()!, out c2scelta) || c2scelta is < 1 or > 4);
                    
                    switch (c2scelta)
                    {
                        case 1:
                            Console.Clear();
                            for (int i = 0; i < listDipendente.Count; i++)
                            {
                                Console.WriteLine($"{i+1}: {listDipendente[i].ToPrintAnagraficaPersona()}");
                            }
                            AddLog(dipendente, TipoLog.LetturaInfoPersone);
                            ContinueAndClear();
                            break;
                        case 2:
                            Console.Clear();
                            for (int i = 0; i < listDipendente.Count; i++)
                            {
                                Console.WriteLine($"{i+1}: {listDipendente[i].ToPrintAnagraficaDipendente()}");
                            }
                            AddLog(dipendente, TipoLog.LetturaInfoDipendenti);
                            ContinueAndClear();
                            break;
                        case 3:
                            Console.Clear();
                            for (int i = 0; i < listDipendente.Count; i++)
                            {
                                Console.WriteLine($"{i+1}: {listDipendente[i].ToPrintAnagraficaCompleta()}");
                            }
                            AddLog(dipendente, TipoLog.LetturaInfoPersoneAndDipendenti);
                            ContinueAndClear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Procedura di visualizzazione annullata.");
                            ContinueAndClear();
                            break;
                    }
                    break;
                case 4:
                    Console.Clear();
                    if (!dLog.TryGetValue(dipendente.Id, out var coda) || coda.Count is 0) { Console.WriteLine("Storico log attualmente vuoto."); }
                    else { foreach(string log in coda) { Console.WriteLine(log); } }
                    AddLog(dipendente, TipoLog.LetturaLog);
                    ContinueAndClear();
                    break;
                case 5:
                    Console.Clear();
                    flag = false;
                    AddLog(dipendente, TipoLog.Logout);
                    Logout(dipendente);
                    break;
            }
        }
    }

    public static void Logout(Dipendente dipendente)
    {
        dipendente.IsActive = false;
        dipendente.LastLogoutUpdate();
        Console.Clear();
        Console.WriteLine("Logout effettuato con successo.");
    }

    public static void AddLog(Dipendente dipendente, TipoLog type)
    {
        string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        
        if (!dLog.TryGetValue(dipendente.Id, out var coda)) 
        { 
            coda = new Queue<string>();
            dLog[dipendente.Id] = coda;
        }

        if(coda.Count >= 15) { coda.Dequeue(); }

        switch (type)
        {
            case TipoLog.Login:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato il login.");
                break;
            case TipoLog.Logout:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato il logout.");
                break;
            case TipoLog.CreazioneDipendente:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato creazione dipendente.");
                break;
            case TipoLog.ModificaDipendente:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato modifica dipendente.");
                break;
            case TipoLog.ModificaDatiPersonali:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato modifica dati personali.");
                break;
            case TipoLog.LetturaLog:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato lettura log.");
                break;
            case TipoLog.LetturaInfoPersonali:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato lettura info personali.");
                break;
            case TipoLog.LetturaInfoPersone:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato info persone.");
                break;
            case TipoLog.LetturaInfoDipendenti:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato info dipendenti.");
                break;
            case TipoLog.LetturaInfoPersoneAndDipendenti:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\tEffettuato info persone+dipendenti.");
                break;
            default:
                coda.Enqueue($"{coda.Count+1}. Data: {timestamp}\t===>\t[ERRORE] Tipo log non riconosciuto.");
                break;
        }
    }
}