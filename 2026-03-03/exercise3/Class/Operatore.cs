class Operatore
{
    private string nome = string.Empty;
    private string turno = string.Empty;
    public string Nome { get { return nome; } set {nome = value;} }
    public string Turno { 
        get { return turno; } 
        set { 
            if (value?.ToLower() is "giorno" or "notte")
            {
                turno = value;
            } else 
            {
                Console.WriteLine("Valore non valido per Turno!");
            }
        } 
    }

    public Operatore(string nome, string turno){
        Nome = nome;
        Turno = turno;
    }

    public new virtual string ToString()
    {
        return $"Nome: {nome, -15}\tTurno: {turno, -15}";
    }

    public virtual void EseguiCompito() {
        Console.WriteLine("Operatore generico in servizio.");
    }
}