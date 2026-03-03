class Soldato
{
    private string nome = string.Empty;
    private string grado = string.Empty;
    private int anniServizio;

    public string Nome { get { return nome; } set { nome = value; } }
    public string Grado { get { return grado; } set { grado = value; }  }
    public int AnniServizio {
        get { return anniServizio; }
        set {
            if (value >= 0) {
                anniServizio = value;
            } else {
                Console.WriteLine("Errore: Gli anni di servizio non possono essere negativi, settato valore default 0.");
                anniServizio = 0; // Default di sicurezza
            }
        }
    }

    public Soldato(string nome, string grado, int anniServizio) { 
        Nome = nome;
        Grado = grado;
        AnniServizio = anniServizio;
    } 
    
    public virtual void Descrizione() { Console.WriteLine($"Nome: {nome, -15}\tGrado: {grado, -5}\tAnni Servizio: {anniServizio, -5}"); }
}