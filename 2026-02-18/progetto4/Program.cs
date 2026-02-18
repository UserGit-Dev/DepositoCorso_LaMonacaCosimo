string nomeRegistrato = "";
string passwordRegistrata = "";
bool registrato = false;
bool continua = true;

while (continua)
{
    Console.WriteLine("Benvenuto!");
    Console.WriteLine("1. Registrati");
    Console.WriteLine("2. Accedi (Login)");
    Console.WriteLine("3. Esci");
    Console.Write("Scegli un'opzione: ");
    
    string scelta = Console.ReadLine()!;

    switch (scelta) {
        case "1":
            Console.Clear();
            Console.WriteLine("Registrazione");
            Console.Write("Inserisci nome utente: ");
            nomeRegistrato = Console.ReadLine()!;
            Console.Write("Inserisci password: ");
            passwordRegistrata = Console.ReadLine()!;
            registrato = true;
            Console.Clear();
            Console.WriteLine("Registrazione completata con successo!");
            Console.WriteLine();
            break;
        case "2":
            if (!registrato) {
                Console.Clear();
                Console.WriteLine("Errore: Nessun utente registrato. Registrati prima!");
                Console.WriteLine();
            } else {
                Console.Clear();
                Console.WriteLine("Login");
                Console.Write("Inserisci nome: ");
                string loginNome = Console.ReadLine()!;
                Console.Write("Inserisci password: ");
                string loginPass = Console.ReadLine()!;
                if (loginNome == nomeRegistrato && loginPass == passwordRegistrata) {
                    Console.Clear();
                    Console.WriteLine("Accesso eseguito! Benvenuto.");
                    Console.Write("Inserisci i secondi per il conto alla rovescia: ");
                    int secondi = int.Parse(Console.ReadLine()!);
                    for (int i = secondi; i >= 0; i--)
                    {
                        Console.WriteLine($"Mancano: {i}...");
                    }
                    Console.WriteLine("Tempo scaduto.");
                    Console.WriteLine();
                } else {
                    Console.WriteLine("Credenziali errate. Riprova.");
                    Console.WriteLine();
                }
            }
            break;
        case "3":
            continua = false;
            Console.Clear();
            Console.WriteLine("Sessione conclusa, arrivederci!");
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opzione non valida.");
            Console.WriteLine();
            break;
    }
}