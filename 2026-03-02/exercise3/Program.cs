class Program()
{
    public static void Main()
    {
        List<Film> listFilms = [];

        for (int i = 0; i < 3; i++)
        {
            string titolo;
            string regista;
            int anno;
            string genere;

            do {
                Console.Clear();
                Console.WriteLine($"{i+1}° Film ({i+1}/3)");
                Console.Write("Inserisci il titolo del film: ");
                titolo = Console.ReadLine()!;
            } while(string.IsNullOrEmpty(titolo));

            do {
                Console.Clear();
                Console.WriteLine($"{i+1}° Film ({i+1}/3)");
                Console.Write("Inserisci il nome del regista: ");
                regista = Console.ReadLine()!;
            } while(string.IsNullOrEmpty(regista));

            do {
                Console.Clear();
                Console.WriteLine($"{i+1}° Film ({i+1}/3)");
                Console.Write("Inserisci l'anno del film: ");
            } while(!int.TryParse(Console.ReadLine()!, out anno));

            do {
                Console.Clear();
                Console.WriteLine($"{i+1}° Film ({i+1}/3)");
                Console.Write("Inserisci il genere del film: ");
                genere = Console.ReadLine()!;
            } while(string.IsNullOrEmpty(genere));

            listFilms.Add(new Film(titolo, regista, anno, genere));
        }

        Console.Clear();
        foreach (Film film in listFilms) Console.WriteLine(film.ToString());

        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.ReadKey(true);

        ConsoleKeyInfo scelta;
        do {
            Console.Clear();
            Console.Write("Vuoi cercare un film? (S/N): ");
            scelta = Console.ReadKey();
        } while(scelta.Key is not (ConsoleKey.S or ConsoleKey.N));

        if (scelta.Key == ConsoleKey.N)
        {
            Console.Clear();
            Console.WriteLine("Sessione terminata.");
            Console.WriteLine("\nPremere un tasto per terminare...");
            Console.ReadKey(true);
            return;
        } 
        
        string titoloDaCercare;
        bool isFilmPresente = false;

        do {
            Console.Clear();
            Console.Write("Inserisci il titolo del film: ");
            titoloDaCercare = Console.ReadLine()!;
        } while(string.IsNullOrEmpty(titoloDaCercare));

        foreach (Film film in listFilms)
        {
            if(string.Equals(titoloDaCercare, film.titolo, StringComparison.OrdinalIgnoreCase))
            {
                isFilmPresente = true;
            }
        }

        Console.Clear();
        if (isFilmPresente) {
            Console.WriteLine("Il film è presente nella lista");
        } else Console.WriteLine("Il film non è presente nella lista");

        Console.WriteLine("\nPremere un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }
}
