class Artigliere : Soldato
{
    private string calibro = string.Empty;
    public string Calibro { get { return calibro; } set { calibro = value; } }

    public Artigliere(string nome, string grado, int anniServizio, string calibro) : base(nome, grado, anniServizio)
    {
        Calibro = calibro;
    }

    public override void Descrizione() { Console.WriteLine($"Nome: {Nome, -15}\tGrado: {Grado, -5}\tAnni Servizio: {AnniServizio, -5}\tArma: {calibro, -5}"); }
}