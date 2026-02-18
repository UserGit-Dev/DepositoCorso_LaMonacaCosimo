int scelta;
string nomeRegistrazione = "";
string passRegistrazione = "";
bool registrato = false;
string loginNome;
string loginPass;
int secondi;
bool continua = true;

while (continua)
{
    Console.WriteLine("Benvenuto!");
    Console.WriteLine("1. Registrati");
    Console.WriteLine("2. Accedi (Login)");
    Console.WriteLine("3. Esci");
    Console.Write("Scegli un'opzione: ");
    
    scelta = int.Parse(Console.ReadLine()!);

    switch (scelta) {
        case 1:
            Console.Clear();
            Console.WriteLine("Registrazione");
            Console.Write("Inserisci nome utente: ");
            nomeRegistrazione = Console.ReadLine()!;
            Console.Write("Inserisci password: ");
            passRegistrazione = Console.ReadLine()!;
            registrato = true;
            Console.Clear();
            Console.WriteLine("Registrazione completata con successo!");
            Console.WriteLine();
            break;
        case 2:
            if (!registrato) {
                Console.Clear();
                Console.WriteLine("Errore: Nessun utente registrato. Registrati prima!");
                Console.WriteLine();
            } else {
                Console.Clear();
                Console.WriteLine("Login");
                Console.Write("Inserisci nome: ");
                loginNome = Console.ReadLine()!;
                Console.Write("Inserisci password: ");
                loginPass = Console.ReadLine()!;
                if (loginNome == nomeRegistrazione && loginPass == passRegistrazione) { 
                    Console.Clear();
                    Console.WriteLine("Accesso eseguito! Benvenuto.");
                    Console.Write("Inserisci i secondi per il conto alla rovescia: ");
                    secondi = int.Parse(Console.ReadLine()!);
                    bool flag1 = true;
                    while (flag1) {                       
                        for (int i = secondi; i >= 0; i--) {
                            Console.WriteLine($"Mancano: {i}...");
                        }
                        Console.Write("Tempo scaduto. Inserire, se si desidera, altri secondi (0: Esci):");
                        secondi = int.Parse(Console.ReadLine()!);
                        if (secondi == 0) {
                            flag1 = false;
                            Console.Clear();
                        }
                    }                   
                    Console.WriteLine("Tempo scaduto.");
                    Console.WriteLine();
                } else {
                    Console.WriteLine("Credenziali errate. Riprova.");
                    Console.WriteLine();
                }
            }
            break;
        case 3:
            continua = false;
            Console.Clear();
            Console.WriteLine("Sessione conclusa, arrivederci!");
            break;
        default:
            Console.Clear();
            Console.WriteLine("Scelta non valida.");
            Console.WriteLine();
            break;
    }
}