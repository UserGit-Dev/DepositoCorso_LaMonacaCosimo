
class Program
{
    public static void Main(string[] args)
    {
        //ExerciseOne();
        //ExerciseTwo();
        //ExerciseThree();
    }

    public static void ExerciseOne()
    {
        Dictionary<string, string> recapiti = [];

        // Aggiunta di 3 recapiti
        for (int i = 0; i < 3; i++)
        {
            while (true) {
                Console.Clear();
                string nome;
                string numero;

                do {
                    Console.Clear();
                    Console.Write($"Inserisci nome del recapito {i + 1}: ");
                    nome = Console.ReadLine()!;
                } while(string.IsNullOrEmpty(nome));

                do {
                    Console.Clear();
                    Console.Write($"Inserisci numero del recapito {i + 1}: ");
                    numero = Console.ReadLine()!;
                } while(string.IsNullOrEmpty(numero));

                if (recapiti.ContainsKey(nome)) {
                    Console.WriteLine("Nome inserito già presente."); 
                    Console.WriteLine("\nPremi un tasto per riprocedere...");
                    Console.ReadKey(true);
                    Console.Clear();
                } else { 
                    recapiti.Add(nome, numero);
                    break; 
                }
            }

            Console.Clear();
        }

        foreach(var contatto in recapiti)
        {
            Console.WriteLine($"Nome: {contatto.Key} => Num: {contatto.Value}");
        }

        Console.WriteLine("\nPremi un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void ExerciseTwo()
    {
        string frase;

        do {
            Console.Clear();   
            Console.Write("Inserisci una frase: ");
            frase = Console.ReadLine()!;
        } while(string.IsNullOrEmpty(frase));

        Dictionary<char, int> qntCaratteri = [];

        foreach (char c in frase)
        {
            // Se il carattere è nuovo lo aggiungo con quantità 1, altrimenti incremento il valore esistente.
            if (!qntCaratteri.TryAdd(c, 1)) qntCaratteri[c]++;
        }

        Console.Clear();
        foreach (var coppia in qntCaratteri) Console.WriteLine($"Carattere: {coppia.Key} => Qnt: {coppia.Value}");

        Console.WriteLine("\nPremi un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void ExerciseThree()
    {
        Console.Clear();
        Dictionary<string, int> inventario = [];

        bool flag = true;
        while (flag)
        {
            int userInput;

            do
            {
                Console.Clear();
                Console.WriteLine("--- Terminale Operativo Magazzino ---\nSelezionare un'operazione per procedere: \n" 
                + "1. Aggiungere\n2. Rimuovere\n3. Cercare\n4. Stampare\n5. Uscire");
                userInput = int.TryParse(Console.ReadLine()!, out int r) ? r : -1;
            } while(userInput is < 1 or > 5);

            switch (userInput)
            {
                case 1: // Inserimento  
                    string productToInsert;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Inserisci un prodotto da aggiungere o aumentare (se presente): ");
                        productToInsert = Console.ReadLine()!.ToLower(); 
                    } while(string.IsNullOrEmpty(productToInsert));

                    if (inventario.ContainsKey(productToInsert)) { 
                        inventario[productToInsert]++;
                        Console.WriteLine("Prodotto già presente. Aumentato di 1 unità.");
                    } else { 
                        inventario.Add(productToInsert, 1); 
                        Console.WriteLine("Prodotto inserito. Settato a 1 unità.");
                    }
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 2: // Rimozione
                    string productToRemove;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Inserisci un prodotto da rimuovere: ");
                        productToRemove = Console.ReadLine()!.ToLower(); 
                    } while(string.IsNullOrEmpty(productToRemove));

                    if (inventario.ContainsKey(productToRemove)) { 
                        inventario.Remove(productToRemove);
                        Console.WriteLine("Prodotto rimosso con successo.");
                    } else { 
                        Console.WriteLine("Prodotto inesistente.");
                    }
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 3: // Ricerca
                    string prodToFind;

                    do
                    {
                        Console.Clear();
                        Console.Write("Inserisci il prodotto da cercare: ");
                        prodToFind = Console.ReadLine()!.ToLower(); 
                    } while(string.IsNullOrEmpty(prodToFind));
                    
                    if (inventario.ContainsKey(prodToFind)) {
                        Console.Clear(); 
                        Console.WriteLine($"Prodotto: {prodToFind} => Qnt: {inventario[prodToFind]}");
                    } else {
                        Console.WriteLine("Nessun prodotto corrispondente trovato.");
                    }
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 4: // Stampa (Console)
                    Console.Clear();
                    if (inventario.Count == 0) { Console.WriteLine("Non è presente alcun prodotto."); }
                    else {
                        foreach (var prodotto in inventario) 
                        Console.WriteLine($"Prodotto: {prodotto.Key} => Qnt: {prodotto.Value}");
                    }
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 5: // Terminazione
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Sessione terminata.");
                    Console.WriteLine("\nPremi un tasto per terminare...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }
    }
}