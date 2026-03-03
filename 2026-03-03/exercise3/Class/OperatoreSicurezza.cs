class OperatoreSicurezza : Operatore
{
    private string areaSorvegliata = string.Empty;
    public string AreaSorvegliata { 
        get { return areaSorvegliata; } 
        set { areaSorvegliata = value; } 
    }

    public OperatoreSicurezza(string nome, string turno, string areaSorvegliata) : base(nome, turno)
    {
        AreaSorvegliata = areaSorvegliata;
    }

    public override string ToString()
    {
        return $"Nome: {Nome, -15}\tTurno: {Turno, -15}\tArea sorvegliata: {areaSorvegliata, -15}";
    }

    public override void EseguiCompito() {
        Console.WriteLine($"Sorveglianza dell'area {areaSorvegliata}");
    }
}