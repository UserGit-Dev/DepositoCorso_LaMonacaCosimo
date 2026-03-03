class Program
{
    public static void Main()
    {
        List<PrenotazioneViaggio> listViaggi =
        [
            new PrenotazioneViaggio("America"),
            new PrenotazioneViaggio("Russia"),
            new PrenotazioneViaggio("Cina"),
        ];

        bool flag = true;
        while(flag) {
            int scelta;
            do {
                Console.Clear();
                Console.WriteLine($"Benvenuto!\n1. Effettua prenotazione\n2. Annulla prenotazione\n3. (Esci)");
            } while(!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 3);

            switch (scelta)
            {
                case 1:
                    bool c1isDestExist = false;
                    int c1idxDest = -1;
                    string c1destinazione; 
                    int c1numPostiAdd;

                    if (listViaggi.Count is 0) {
                        Console.Clear();
                        Console.WriteLine($"Attualmente non è possibile effettuare operazioni di prenotazione.");
                        ContinueAndClear();
                        break;
                    }

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci la destinazione: ");
                        c1destinazione = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c1destinazione));

                    for (int i = 0; i < listViaggi.Count; i++)
                    {
                        if (string.Equals(listViaggi[i].Destinazione, c1destinazione, StringComparison.OrdinalIgnoreCase))
                        {
                            c1isDestExist = true;
                            c1idxDest = i;
                        }
                    }

                    if (!c1isDestExist)
                    {
                        Console.WriteLine($"Destinazione attualmente non disponibile");
                        ContinueAndClear();
                        break;
                    }

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci numero di prenotazioni da effettuare: ");
                    } while(!int.TryParse(Console.ReadLine()!, out c1numPostiAdd));

                    if (listViaggi[c1idxDest].PrenotaPosti(c1numPostiAdd)) {
                        Console.WriteLine($"Prenotazione avvenuta con successo.\nRichiesti: {c1numPostiAdd} => Attuale: {listViaggi[c1idxDest].PostiDisponibili}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    } else {
                        Console.WriteLine($"Il numero di posti disponibili è insufficiente.\nPosti disponibili: {listViaggi[c1idxDest].PostiDisponibili}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    break;
                case 2:
                    int c2numPostiRem;
                    bool c2isDestExist = false;
                    int c2idxDest = -1;
                    string c2destinazione; 

                    if (listViaggi.Count is 0) {
                        Console.Clear();
                        Console.WriteLine($"Attualmente non è possibile effettuare operazioni di prenotazione.");
                        ContinueAndClear();
                        break;
                    }

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci la destinazione: ");
                        c2destinazione = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(c2destinazione));

                    for (int i = 0; i < listViaggi.Count; i++)
                    {
                        if (string.Equals(listViaggi[i].Destinazione, c2destinazione, StringComparison.OrdinalIgnoreCase))
                        {
                            c2isDestExist = true;
                            c2idxDest = i;
                        }
                    }

                    if (!c2isDestExist)
                    {
                        Console.WriteLine($"Destinazione attualmente non disponibile");
                        ContinueAndClear();
                        break;
                    }

                    do {
                        Console.Clear();
                        Console.Write($"Inserisci numero di prenotazioni da annullare: ");
                    } while(!int.TryParse(Console.ReadLine()!, out c2numPostiRem));

                    if (listViaggi[c2idxDest].AnnullaPrenotazione(c2numPostiRem)) {
                        Console.WriteLine($"Annullamento {(c2numPostiRem > 1 ? "delle prenotazioni" : "della prenotazione")} avvenuta con successo.\nPosti disponibili: {listViaggi[c2idxDest].PostiDisponibili}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    } else {
                        Console.WriteLine($"Il numero di prenotazioni da annullare supera il numero di prenotazioni attuali.\nPosti disponibili: {listViaggi[c2idxDest].PostiDisponibili}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    break;
                case 3:
                flag = false;
                Console.Clear();
                Console.WriteLine("Sessione terminata.");
                Console.WriteLine("\nPremere un tasto per terminare...");
                Console.ReadKey(true);
                Console.Clear();
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