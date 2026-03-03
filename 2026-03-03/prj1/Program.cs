class Program
{
    public static void ContinueAndClear()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3j");
        Console.Clear();
    }
    
    public static void Main()
    {
        List<CorsoBase> listCorsi = [];
        listCorsi.Add(new CorsoMusica("Test Musica", 100, "Francesco", "Chitarra"));
        listCorsi.Add(new CorsoPittura("Test Pittura", 100, "Simone", "Pennello"));
        listCorsi.Add(new CorsoDanza("Test Danza", 100, "Claudio", "Macarena"));

        bool flag = true;
        while (flag)
        {
            int scelta;
            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto!\nOpzioni:\n1. Aggiungi corso Musica\n2. Aggiungi corso Pittura\n3. Aggiungi corso Danza\n" 
                + "4. Aggiungi studente a un corso\n5. Visualizza corsi\n6. Cerca corsi per nome docente\n7. Esegui metodo speciale di un corso\n0. (Esci)");
            } while(!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 7);

            switch (scelta)
            {
                case 1:
                    string c1nomeCorso;
                    int c1durataOre;
                    string c1nomeDocente;
                    string c1strumento;

                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome corso: ");
                        c1nomeCorso = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1nomeCorso));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci durata corso (Ore): ");
                    } while(!int.TryParse(Console.ReadLine()!, out c1durataOre) || c1durataOre is < 0 or > 500);
                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome docente: ");
                        c1nomeDocente = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1nomeDocente));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome strumento: ");
                        c1strumento = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1strumento));

                    listCorsi.Add(new CorsoMusica(c1nomeCorso, c1durataOre, c1nomeDocente, c1strumento));
                    Console.WriteLine("Corso aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 2:
                    string c2nomeCorso;
                    int c2durataOre;
                    string c2nomeDocente;
                    string c2tecnica;

                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome corso: ");
                        c2nomeCorso = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2nomeCorso));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci durata corso (Ore): ");
                    } while(!int.TryParse(Console.ReadLine()!, out c2durataOre) || c2durataOre is < 1 or > 500);
                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome docente: ");
                        c2nomeDocente = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2nomeDocente));
                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome tecnica: ");
                        c2tecnica = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2tecnica));

                    listCorsi.Add(new CorsoPittura(c2nomeCorso, c2durataOre, c2nomeDocente, c2tecnica));
                    Console.WriteLine("Corso aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 3:
                    string c3nomeCorso;
                    int c3durataOre;
                    string c3nomeDocente;
                    string c3stile;

                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome corso: ");
                        c3nomeCorso = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c3nomeCorso));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci durata corso (Ore): ");
                    } while(!int.TryParse(Console.ReadLine()!, out c3durataOre) || c3durataOre is < 0 or > 500);
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome docente: ");
                        c3nomeDocente = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c3nomeDocente));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci nome stile: ");
                        c3stile = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c3stile));

                    listCorsi.Add(new CorsoDanza(c3nomeCorso, c3durataOre, c3nomeDocente, c3stile));
                    Console.WriteLine("Corso aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 4:
                    if (listCorsi.Count is 0) {
                        Console.Clear();
                        Console.WriteLine("Lista attualmente vuota.");
                        ContinueAndClear();
                        break;
                    }

                    int c4scelta;
                    bool c4isCorsoExist = false;
                    int c4qntCorsiMusica = 0;
                    int c4qntCorsiPittura = 0;
                    int c4qntCorsiDanza = 0;
                    int c4sceltaCorso = -1;
                    string c4nomeStudente;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Opzioni:\n1. Musica\n2. Pittura\n3. Danza\n0. (Esci)");
                    } while(!int.TryParse(Console.ReadLine()!, out c4scelta) || c4scelta is < 0 or > 3);

                    do {
                        Console.Clear();
                        for(int i = 0; i < listCorsi.Count; i++)
                        {
                            if (c4scelta is 1 && listCorsi[i] is CorsoMusica musica) {
                                c4isCorsoExist = true;
                                c4qntCorsiMusica++;
                                Console.WriteLine($"{i+1}. Nome corso: {musica.nomeCorso}\tDurata ore: {musica.durataOre}\tDocente: {musica.docente}\tStrumento: {musica.strumento}");
                            }     
                            if (c4scelta is 2 && listCorsi[i] is CorsoPittura pittura) {
                                c4isCorsoExist = true;
                                c4qntCorsiPittura++;
                                Console.WriteLine($"{i+1}. Nome corso: {pittura.nomeCorso}\tDurata ore: {pittura.durataOre}\tDocente: {pittura.docente}\tTecnica: {pittura.tecnica}");
                            }
                            if (c4scelta is 3 && listCorsi[i] is CorsoDanza danza) {
                                c4isCorsoExist = true;
                                c4qntCorsiDanza++;
                                Console.WriteLine($"{i+1}. Nome corso: {danza.nomeCorso}\tDurata ore: {danza.durataOre}\tDocente: {danza.docente}\tStile: {danza.stile}");
                            }
                        }

                        if (!c4isCorsoExist) { break; }

                        Console.Write("Inserisci indice corso: ");
                        if (int.TryParse(Console.ReadLine()!, out c4sceltaCorso))
                        {
                            if (c4scelta == 1 && c4sceltaCorso > 0 && c4sceltaCorso <= c4qntCorsiMusica) {
                                break;
                            }
                            else if (c4scelta == 2 && c4sceltaCorso > 0 && c4sceltaCorso <= c4qntCorsiPittura) {
                                break;
                            }
                            else if (c4scelta == 3 && c4sceltaCorso > 0 && c4sceltaCorso <= c4qntCorsiDanza) {
                                break;
                            }
                        }
                    } while(true);

                    if (!c4isCorsoExist) {
                        Console.Clear();
                        Console.WriteLine("Attualmente non è attivo alcun corso per tipo selezionato.");
                        ContinueAndClear();
                        break;
                    }

                    do
                    {
                        Console.Clear();
                        Console.Write("Inserisci il nome dello studente: ");
                        c4nomeStudente = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c4nomeStudente));

                    switch (c4scelta)
                    {
                        case 1:
                            listCorsi[c4sceltaCorso-1].AggiungiStudente(c4nomeStudente);
                            Console.WriteLine("Studente aggiunto con successo");
                            ContinueAndClear();
                            break;
                        case 2:
                            Console.WriteLine("Studente aggiunto con successo");
                            ContinueAndClear();
                            break;
                        case 3:
                            Console.WriteLine("Studente aggiunto con successo");
                            ContinueAndClear();
                            break;
                        case 0:
                            Console.WriteLine("Sessione terminata.");
                            ContinueAndClear();
                            break;
                    }
                    break;
                case 5:
                    int c5scelta;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Opzioni:\n1. Musica\n2. Pittura\n3. Danza\n4. (Tutto)\n0. (Esci)");
                    } while(!int.TryParse(Console.ReadLine()!, out c5scelta) || c5scelta is < 0 or > 4);
                    
                    Console.Clear();

                    if (c5scelta == 0)
                    {                   
                        Console.WriteLine("Operazione di visualizzazione annullata.");
                    } else if (c5scelta == 4) {
                        foreach (CorsoBase corso in listCorsi) { Console.WriteLine(corso.ToString()); }
                    } else {
                        foreach (CorsoBase corso in listCorsi)
                        {
                            if (c5scelta == 1 && corso is CorsoMusica) Console.WriteLine(corso.ToString());
                            else if (c5scelta == 2 && corso is CorsoPittura) Console.WriteLine(corso.ToString());
                            else if (c5scelta == 3 && corso is CorsoDanza) Console.WriteLine(corso.ToString());
                        }
                    }
                    ContinueAndClear();
                    break;
                case 6:
                    string c6nomeDocente;
                    do
                    {
                        Console.Clear();
                        Console.Write("Inserisci il nome dello studente: ");
                        c6nomeDocente = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c6nomeDocente));

                    List<CorsoBase> listFilteredByDocente = [];
                    foreach(CorsoBase corso in listCorsi)
                    {
                        if (string.Equals(corso.docente, c6nomeDocente, StringComparison.OrdinalIgnoreCase)) listFilteredByDocente.Add(corso);
                    }

                    if (listFilteredByDocente.Count == 0) { Console.WriteLine("Non è stato trovato alcun corso associato a questo docente"); }
                    else
                    {
                        foreach (CorsoBase corso in listFilteredByDocente)
                        {
                            if (corso is CorsoMusica musica) Console.WriteLine(musica.ToString());
                            else if (corso is CorsoPittura pittura) Console.WriteLine(pittura.ToString());
                            else if (corso is CorsoDanza danza) Console.WriteLine(danza.ToString());
                        }
                    }
                    ContinueAndClear();
                    break;
                case 7:
                    if (listCorsi.Count is 0) {
                        Console.Clear();
                        Console.WriteLine("Lista attualmente vuota.");
                        ContinueAndClear();
                        break;
                    }

                    int c7scelta;
                    bool c7isCorsoExist = false;

                    do {
                        Console.Clear();
                        Console.WriteLine("Opzioni:\n1. Musica\n2. Pittura\n3. Danza\n0. (Esci)");
                    } while(!int.TryParse(Console.ReadLine()!, out c7scelta) || c7scelta is < 0 or > 3);

                    if (c7scelta is 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Operazione di selezione annullata.");
                    } else{
                        List<CorsoBase> listCorsiFiltered = [];

                        for(int i = 0; i < listCorsi.Count; i++)
                        {
                            if (c7scelta is 1 && listCorsi[i] is CorsoMusica musica) {
                                c7isCorsoExist = true;
                                listCorsiFiltered.Add(musica);
                            }     
                            if (c7scelta is 2 && listCorsi[i] is CorsoPittura pittura) {
                                c7isCorsoExist = true;
                                listCorsiFiltered.Add(pittura);
                            }
                            if (c7scelta is 3 && listCorsi[i] is CorsoDanza danza) {
                                c7isCorsoExist = true;
                                listCorsiFiltered.Add(danza);
                            }
                        }

                        if (!c7isCorsoExist) {
                            Console.Clear();
                            Console.WriteLine("Attualmente non è attivo alcun corso per tipo selezionato.");
                            ContinueAndClear();
                            break;
                        }
                        
                        Console.Clear();
                        foreach(CorsoBase corso in listCorsiFiltered) corso.MetodoSpeciale();
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
}