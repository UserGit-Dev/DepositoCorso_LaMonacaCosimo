
class Program
{
    public static void Main()
    {
        List<Operatore> listOperatori = [];
        
        bool flag = true;
        while(flag) {
            int scelta;
            do
            {
                Console.Clear();
                Console.WriteLine("Esegui:\n1. Aggiunta operatore\n2. Stampa operatori\n3. Avvia \"EseguiCompito()\"\n0. (Esci)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 3);

            switch(scelta)
            {
                case 1:
                    int c1scelta;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Esegui:\n1. Emergenza\n2. Sicurezza\n3. Logistica\n0. (Esci)");
                    } while (!int.TryParse(Console.ReadLine()!, out c1scelta) || c1scelta is < 0 or > 3);

                    string c1nome;
                    string c1turno;
                    int c1livelloEmergenza;
                    string c1areaSorvegliata;
                    int c1numeroConsegne;
                    
                    if (c1scelta is 0)
                    {
                        Console.WriteLine("Operazione di inserimento annullata.");
                    } else {           
                        do {
                            Console.Clear();
                            Console.Write("Inserisci il nome: ");
                            c1nome = Console.ReadLine()!;
                        } while (string.IsNullOrEmpty(c1nome));
                        
                        do {
                            Console.Clear();
                            Console.Write("Inserisci il turno (Giorno/Notte): ");
                            c1turno = Console.ReadLine()!.ToLower();
                        } while (string.IsNullOrEmpty(c1turno) || c1turno is not ("giorno" or "notte"));
                        
                        if (c1scelta is 1) {
                            do {
                                Console.Clear();
                                Console.Write("Inserisci il livello di emergenza: ");
                            } while (!int.TryParse(Console.ReadLine()!, out c1livelloEmergenza) || c1livelloEmergenza is < 0 or > 5);

                            listOperatori.Add(new OperatoreEmergenza(c1nome, c1turno, c1livelloEmergenza));
                        }
                        else if (c1scelta is 2) {
                            do {
                                Console.Clear();
                                Console.Write("Inserisci l'area sorvegliata: ");
                                c1areaSorvegliata = Console.ReadLine()!;
                            } while (string.IsNullOrEmpty(c1areaSorvegliata));

                            listOperatori.Add(new OperatoreSicurezza(c1nome, c1turno, c1areaSorvegliata));
                        }
                        else if (c1scelta is 3) {
                            do {
                                Console.Clear();
                                Console.Write("Inserisci il numero di consegne: ");
                            } while (!int.TryParse(Console.ReadLine()!, out c1numeroConsegne) || c1numeroConsegne is < 0);

                            listOperatori.Add(new OperatoreLogistica(c1nome, c1turno, c1numeroConsegne));
                        }
                        Console.WriteLine("Operatore aggiunto con successo.");
                    }   
                    ContinueAndClear();
                    break;
                case 2:
                    Console.Clear();
                    if (listOperatori.Count is 0) {
                        Console.WriteLine("Lista operatori attualmente vuota.");
                    } else {
                        foreach(Operatore operatore in listOperatori) Console.WriteLine(operatore.ToString());
                    }
                    ContinueAndClear();
                    break;
                case 3:
                    Console.Clear();
                    if (listOperatori.Count is 0) {
                        Console.WriteLine("Lista operatori attualmente vuota.");
                    } else {
                        foreach(Operatore operatore in listOperatori) operatore.EseguiCompito();
                    }
                    ContinueAndClear();
                    break;
                case 0:
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Operazione annullata.");
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