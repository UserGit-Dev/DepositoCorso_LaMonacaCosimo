class OperatoreLogistica : Operatore
{
    private int numeroConsegne;
    public int NumeroConsegne { 
        get { return numeroConsegne; } 
        set
        {
            if (value is >= 0) {
                numeroConsegne = value;
            }
        } 
    }

    public OperatoreLogistica(string nome, string turno, int numeroConsegne) : base(nome, turno)
    {
        NumeroConsegne = numeroConsegne;
    }

    public override string ToString()
    {
        return $"Nome: {Nome, -15}\tTurno: {Turno, -15}\tNumero Consegne: {numeroConsegne, -15}";
    }

    public override void EseguiCompito() {
        Console.WriteLine($"Coordinamento di {numeroConsegne} consegne");
    }
}