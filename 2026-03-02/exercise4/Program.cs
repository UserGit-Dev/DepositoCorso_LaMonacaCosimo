class Program
{
    public static void Main()
    {
        List<Veicolo> listVeicoli = [];

        bool flag = true;
        while (flag)
        {
            int scelta;
            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto!\nCosa scegliere:\n1. Inserire veicolo\n2. Inserire moto\n3. Visualizzare tutti i veicoli nel garage\n4. (Uscire)");
            } while(!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 1 or > 4);

            switch (scelta)
            {
                case 1:
                    string marca;
                    string modello;
                    int numeroPorte;
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la marca: ");
                        marca = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(marca));

                    do {
                        Console.Clear();
                        Console.Write("Inserisci il modello: ");
                        modello = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(modello));

                    do {
                        Console.Clear();
                        Console.Write("Inserisci numero porte: ");
                        
                    } while (!int.TryParse(Console.ReadLine()!, out numeroPorte) || numeroPorte is < 2 or > 6);

                    listVeicoli.Add(new Auto(marca, modello, numeroPorte));
                    Console.Clear();
                    Console.WriteLine("Veicolo aggiunto alla lista.");
                    Console.WriteLine("\nPremere un tasto per continuare...");
                    Console.ReadKey(true);
                    break;
                case 2:
                    string marcaMoto;
                    string modelloMoto;
                    string tipoManubrio;
                    
                    do {
                        Console.Clear();
                        Console.Write("Inserisci la marca: ");
                        marcaMoto = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(marcaMoto));

                    do {
                        Console.Clear();
                        Console.Write("Inserisci il modello: ");
                        modelloMoto = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(modelloMoto));

                    do {
                        Console.Clear();
                        Console.Write("Inserisci tipologia manubrio: ");
                        tipoManubrio = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(tipoManubrio));

                    listVeicoli.Add(new Moto(marcaMoto, modelloMoto, tipoManubrio));
                    Console.Clear();
                    Console.WriteLine("Veicolo aggiunto alla lista.");
                    Console.WriteLine("\nPremere un tasto per continuare...");
                    Console.ReadKey(true);
                    break;
                case 3:
                    Console.Clear();
                    if (listVeicoli.Count is 0) { Console.WriteLine("Lista veicolo attualmente vuoto"); }
                    else {
                        foreach (Veicolo veicolo in listVeicoli)
                        {
                            veicolo.Stampa();
                        }
                    }
                    Console.WriteLine("\nPremere un tasto per continuare...");
                    Console.ReadKey(true);
                    break;
                case 4: 
                    flag = false;
                    Console.WriteLine("Sessione terminata.");
                    Console.WriteLine("\nPremere un tasto per terminare...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }
    }
}