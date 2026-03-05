class Program
{
    public static void Main()
    {
        List<Corso> listCorso = [];
        bool flag = true;
        while (flag)
        { 
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleziona:\n1. Crea corso in presenza\n2. Crea corso online\n" 
                    + "3. Stampa i corsi\n4. (Esci)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 4);

            switch (scelta)
            {
                case 1:
                    string c1nomeDocente;
                    string c1materia;
                    string c1titolo;
                    int c1durataOre;
                    string c1aula;
                    int c1numeroPosti;

                    Console.Clear();
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il nome del docente: ");
                        c1nomeDocente = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c1nomeDocente));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la materia: ");
                        c1materia = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c1materia));

                    do {
                        Console.Clear();
                        Console.Write("Inserisci titolo: ");
                        c1titolo = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c1titolo));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci durata ore: ");
                    } while (!int.TryParse(Console.ReadLine()!, out c1durataOre) || c1durataOre < 0);

                    do {
                        Console.Clear();
                        Console.Write("Inserisci aula: ");
                        c1aula = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c1aula));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci numero posti: ");
                    } while (!int.TryParse(Console.ReadLine()!, out c1numeroPosti) || c1numeroPosti < 1);

                    listCorso.Add(new CorsoInPresenza(c1nomeDocente, c1materia, c1titolo, c1durataOre, c1aula, c1numeroPosti));
                    Console.WriteLine("Corso in presenza aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 2:
                    string c2nomeDocente;
                    string c2materia;
                    string c2titolo;
                    int c2durataOre;
                    string c2piattaforma;
                    string c2linkAccesso;

                    Console.Clear();
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il nome del docente: ");
                        c2nomeDocente = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c2nomeDocente));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la materia: ");
                        c2materia = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c2materia));

                    do {
                        Console.Clear();
                        Console.Write("Inserisci titolo: ");
                        c2titolo = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c2titolo));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci durata ore: ");
                    } while (!int.TryParse(Console.ReadLine()!, out c2durataOre) || c2durataOre < 0);
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci piattaforma: ");
                        c2piattaforma = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c2piattaforma));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci numero posti: ");
                        c2linkAccesso = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(c2linkAccesso));

                    listCorso.Add(new CorsoOnline(c2nomeDocente, c2materia, c2titolo, c2durataOre, c2piattaforma, c2linkAccesso));
                    Console.WriteLine("Corso online aggiunto con successo.");
                    ContinueAndClear();
                    break;
                case 3:
                    Console.Clear();
                    if (listCorso.Count is 0) { 
                        Console.Clear();
                        Console.WriteLine("Lista corsi attualmente vuota."); 
                        ContinueAndClear(); 
                    } else {
                        Console.WriteLine(new string('-', 50));
                        foreach(Corso corso in listCorso) {                         
                            corso.ErogaCorso();
                            Console.WriteLine();
                            corso.StampaDettagli(); 
                            Console.WriteLine(new string('-', 50));
                        }
                    }
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

    public static void ContinueAndClear()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);
        Console.Write("\x1b[3j");
        Console.Clear();
    }
}