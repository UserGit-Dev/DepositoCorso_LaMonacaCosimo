class Program
{
    public static void Main()
    {
        bool flag = true;
        while (true)
        { 
            List<Corso> listCorso = [];
            int scelta;

            do
            {
                Console.Clear();
                Console.WriteLine("\nSeleziona:\n1. Crea corso in presenza\n2. Crea corso online\n3. (Esci)");

            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 3);

            switch (scelta)
            {
                case 1:
                    string nomeDocente;
                    string materia;
                    string aula;
                    int numeroPosti;

                    Console.Clear();
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il nome del docente: ");
                        nomeDocente = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(nomeDocente));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la materia: ");
                        materia = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(materia));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci aula: ");
                        aula = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(aula));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci numero posti: ");
                    } while (!int.TryParse(Console.ReadLine()!, out numeroPosti) || numeroPosti < 1);

                    listCorso.Add(nomeDocente, materia, aula, numeroPosti);
                    Console.WriteLine("Corso in presenza aggiunto con successo.");
                case 2:
                    string nomeDocente;
                    string materia;
                    string piattaforma;
                    string linkAccesso;

                    Console.Clear();
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il nome del docente: ");
                        nomeDocente = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(nomeDocente));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la materia: ");
                        materia = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(materia));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci piattaforma: ");
                        piattaforma = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(piattaforma));
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci numero posti: ");
                        linkAccesso = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(linkAccesso));

                    listCorso.Add(nomeDocente, materia, piattaforma, linkAccesso);
                    Console.WriteLine("Corso online aggiunto con successo.");
                case 3:
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    Console.WriteLine("\nPremere un tasto per uscire...");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}