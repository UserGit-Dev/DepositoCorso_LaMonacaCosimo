class Program
{
    public static void Main()
    {
        VoloAereo voloAereo = new();

        bool flag = true;
        while(flag) {
            int scelta;
            do {
                Console.Clear();
                Console.WriteLine($"Benvenuto!\n1. Prenota\n2. Annulla\n3. (Esci)");
            } while(!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 3);

            switch (scelta)
            {
                case 1:
                    int numPostiAdd;
                    do {
                        Console.Clear();
                        Console.Write($"Inserisci numero di prenotazioni da effettuare: ");
                    } while(!int.TryParse(Console.ReadLine()!, out numPostiAdd));

                    if (voloAereo.EffettuaPrenotazione(numPostiAdd)) {
                        Console.WriteLine($"Prenotazione avvenuta con successo.\nRichiesti: {numPostiAdd} => Attuale: {voloAereo.PostiLiberi}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    } else {
                        Console.WriteLine($"Il numero di posti disponibili è insufficiente.\nPosti disponibili: {voloAereo.PostiLiberi}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    break;
                case 2:
                    int numPostiRem;
                    do {
                        Console.Clear();
                        Console.Write($"Inserisci numero di prenotazioni da annullare: ");
                    } while(!int.TryParse(Console.ReadLine()!, out numPostiRem));

                    if (voloAereo.AnnullaPrenotazione(numPostiRem)) {
                        Console.WriteLine($"Annullamento {(numPostiRem > 1 ? "delle prenotazioni" : "della prenotazione")} avvenuta con successo.\nPosti disponibili: {voloAereo.PostiLiberi}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                        Console.Clear();
                    } else {
                        Console.WriteLine($"Il numero di prenotazioni da annullare supera il numero di prenotazioni attuali.\nPosti disponibili: {voloAereo.PostiLiberi}");
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
}