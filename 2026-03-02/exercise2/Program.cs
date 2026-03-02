class Program()
{
    public static void Main()
    {
        //Random random = new();
        Utente utente = new();
        Macchina macchina = new();

        do
        {
            Console.Clear();
            Console.Write("Benvenuto!\nInserisci il tuo nome: ");
            utente.Nome = Console.ReadLine()!;
        } while(string.IsNullOrEmpty(utente.Nome));

        //utente.Credito = random.Next(1, 11);

        bool flag = true;
        while (flag)
        {
            int scelta;
            do {
                Console.Clear();
                Console.WriteLine("Cosa vuoi fare?:\n1. Cambiare motore\n2. Aumentare velocità\n3. Aumentare le sospensioni\n4. (Uscire)");
            } while(!int.TryParse(Console.ReadLine()!, out scelta) && scelta is not < 1 and > 4);

            switch (scelta)
            {
                case 1: 
                    do {
                        Console.Clear();
                        Console.Write("Inserisci il nome del motore: ");
                        macchina.Motore = Console.ReadLine()!;
                    } while(string.IsNullOrEmpty(macchina.Motore));
                    Console.WriteLine("Inserimento avvenuto con successo.");
                    Console.WriteLine("\nPremere un tasto per continuare...");
                    Console.ReadKey(true);
                    break;
                case 2:
                    if (string.IsNullOrEmpty(macchina.Motore)) {
                        Console.Clear();
                        Console.WriteLine("Azione non consentita, inserisci prima il motore.");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                    } else if (utente.Credito == 0) {
                        Console.Clear();
                        Console.WriteLine("Azione non consentita, credito insufficiente.");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                    } else {
                        int puntiVelocita;
                        do
                        {
                            Console.Clear();
                            Console.Write($"Credito attuale: {utente.Credito}\nDi quanti punti vuoi aumentare la velocità?: ");
                        } while(!int.TryParse(Console.ReadLine()!, out puntiVelocita) || puntiVelocita > utente.Credito || puntiVelocita < 0);
                        utente.Credito -= puntiVelocita;
                        macchina.Velocita += puntiVelocita;
                        macchina.NrModifiche++;
                        Console.Clear();
                        Console.WriteLine($"Velocità aumentata di {puntiVelocita} punti.\nCredito residuo: {utente.Credito}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                    }
                    break;
                case 3:
                    Console.Clear();
                    if (string.IsNullOrEmpty(macchina.Motore)) {
                        Console.WriteLine("Azione non consentita, inserisci prima il motore.");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                    } else if (utente.Credito == 0) {
                        Console.WriteLine("Azione non consentita, credito insufficiente.");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                    } else { 
                        utente.Credito--;
                        macchina.SospensioneMax++;
                        macchina.NrModifiche++;
                        Console.Clear();
                        Console.WriteLine($"Sospensioni aumentate di 1 unità\nCredito residuo: {utente.Credito}");
                        Console.WriteLine("\nPremere un tasto per continuare...");
                        Console.ReadKey(true);
                    }
                    break;
                case 4:
                    flag = false;
                    Console.Clear();
                    if (string.IsNullOrEmpty(macchina.Motore)) {
                        Console.WriteLine(new string('*', 3) + " Sessione terminata " + new string('*', 3));
                        Console.WriteLine("Nessuna informazione da stampare.");
                    } else {
                        Console.WriteLine(new string('*', 3) + " Sessione terminata " + new string('*', 3));
                        Console.WriteLine(new string('=', 20) + "\nUtente\n" + new string('-', 20));
                        Console.WriteLine($"Nome: {utente.Nome}\nCrediti: {utente.Credito}\n" + new string('=', 20));
                        Console.WriteLine("Veicolo\n" + new string('-', 20));
                        Console.WriteLine($"Motore: {macchina.Motore}\nVelocità: {macchina.Velocita}\n" 
                            + $"Sospensione: {macchina.SospensioneMax}\nNum. Modifiche: {macchina.NrModifiche}\n" + new string('=', 20) + "\n");
                    }
                    Console.WriteLine("\nPremere un tasto per continuare...");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}
