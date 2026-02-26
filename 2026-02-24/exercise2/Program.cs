class Program
{
    public static void Main(string[] args)
    {
        //ExerciseOne();
        ExerciseTwo();
        //ExerciseThree();
    }

    public static void ExerciseOne()
    {
        List<int> listaInt = [];
        
        for (int i = 1; i <= 5; i++)
        {
            int temp;

            do {
                Console.Clear();
                Console.Write($"Inserisci il {i}° numero: ");
            } while(!int.TryParse(Console.ReadLine()!, out temp));

            listaInt.Add(temp);
        }

        while (true)
        {
            Console.Clear();
            Console.Write($"Desideri eliminare un numero? (S/N): ");
            ConsoleKeyInfo userInput = Console.ReadKey()!;

            if (userInput.Key == ConsoleKey.S)
            {
                int numToDelete;
                Console.Clear();
                Console.Write("Inserisci il dato da eliminare: ");

                while (!int.TryParse(Console.ReadLine()!, out numToDelete))
                {
                    Console.Clear();
                    Console.WriteLine("Errore, dato non conforme coi requisiti.\n");
                    Console.WriteLine("Inserisci il dato da eliminare: ");
                }

                if (listaInt.Contains(numToDelete)) {
                    listaInt.Remove(numToDelete);
                    Console.WriteLine("Dato richiesto eliminato con successo.\n");
                    Console.WriteLine("Premi un tasto per continuare...");
                    Console.ReadKey(true);   
                } else {
                    Console.WriteLine("Dato richiesto non trovato.\n"); 
                    Console.WriteLine("Premi un tasto per continuare...");
                    Console.ReadKey(true);
                }
            } else if (userInput.Key == ConsoleKey.N) break;
        }

        Console.Clear();
        Console.Write($"Lista numeri: ");
        Console.WriteLine(string.Join(", ", listaInt));
        Console.WriteLine("\nPremi un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void ExerciseTwo()
    {
        Console.WriteLine("Premi un tasto per generare una lista randomica di 10 numeri.");
        Console.ReadKey(true); 
        Random random = new();
        List<int> listaInt = [];

        for (int i = 0; i < 10; i++)
        {
            listaInt.Add(random.Next(1, 101));
        }

        Console.WriteLine("Lista interi (Completa): " + string.Join(", ", listaInt));
        Console.WriteLine("\nPremi un tasto per continuare...");
        Console.ReadKey(true);
        ConsoleKeyInfo userInput;
        
        while (true)
        {
            do 
            {
                Console.Clear();
                Console.WriteLine("Vuoi trovare un numero? (S/N): ");
                userInput = Console.ReadKey(true)!;
            } while (userInput.Key is not (ConsoleKey.S or ConsoleKey.N));

            if (userInput.Key is ConsoleKey.N) break;
            if (userInput.Key == ConsoleKey.S)
            {
                int numToFind;
            
                do 
                {
                    Console.Clear();
                    Console.Write("Inserisci il numero da trovare: ");
                } while (!int.TryParse(Console.ReadLine()!, out numToFind));

                if (listaInt.Contains(numToFind)) {
                    Console.WriteLine($"Numero trovato all'indice {listaInt.IndexOf(numToFind)}");
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey(true);
                    
                } else {
                    Console.WriteLine("Il numero in questione non è stato trovato.");
                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey(true);
                }
            }
        }

        List<int> numPari = []; 
        foreach (int num in listaInt) 
        {
            if (num % 2 == 0) numPari.Add(num);
        }

        Console.WriteLine("Lista interi (Pari): " + string.Join(", ", numPari));
        Console.WriteLine("\nPremi un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void ExerciseThree()
    {
        Console.WriteLine("Premi un tasto per generare una lista randomica di 15 numeri.");
        Console.ReadKey(true); 
        Random random = new();
        List<int> listaInt = [];

        for (int i = 0; i < 10; i++)
        {
            listaInt.Add(random.Next(1, 21));
        }

        Console.WriteLine("Lista interi (Completa): " + string.Join(", ", listaInt));

        List<int> listaIntFiltrata = [];
        foreach (int num in listaInt)
        {
            if (!listaIntFiltrata.Contains(num))
            {
                listaIntFiltrata.Add(num);
            }
        }

        //listaIntFiltrata.Sort();
        bool swapAvvenuto;
        for (int i = 0; i < listaIntFiltrata.Count - 1; i++)
        {
            swapAvvenuto = false;
            for (int j = 0; j < listaIntFiltrata.Count - 1 - i; j++)
            {
                // Scambio il numero attuale se più grande ndel numero successivo
                if (listaIntFiltrata[j] > listaIntFiltrata[j + 1])
                {
                    // effettuo lo scambio, volevo usare le "Tuple" ma per il momento non è stato ancora trattato.
                    int temp = listaIntFiltrata[j];
                    listaIntFiltrata[j] = listaIntFiltrata[j + 1];
                    listaIntFiltrata[j + 1] = temp;
                    swapAvvenuto = true;
                }
            }

            // Se in j non è avvenuto alcuno swap non ha senso ciclare i
            if (!swapAvvenuto) break;
        }

        Console.WriteLine("Lista interi (Ordinata): " + string.Join(", ", listaIntFiltrata));
        Console.WriteLine("\nPremi un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }
}