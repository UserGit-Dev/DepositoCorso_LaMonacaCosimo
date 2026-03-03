class OperatoreEmergenza : Operatore
{
    private int livelloUrgenza;
    public int LivelloUrgenza { 
        get { return livelloUrgenza; } 
        set
        {
            if (value is > 0 and <= 5) {
                livelloUrgenza = value;
            }
        } 
    }

    public OperatoreEmergenza(string nome, string turno, int livelloUrgenza) : base(nome, turno)
    {
        LivelloUrgenza = livelloUrgenza;
    }

    public override string ToString()
    {
        return $"Nome: {Nome, -15}\tTurno: {Turno, -15}\tLivello urgenza: {livelloUrgenza, -15}";
    }

    public override void EseguiCompito() {
        Console.WriteLine($"Gestione emergenza di livello {livelloUrgenza}");
    }
}