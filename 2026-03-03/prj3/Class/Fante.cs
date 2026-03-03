class Fante : Soldato
{
    private string arma = string.Empty;
    public string Arma { get { return arma; } set { arma = value; } }

    public Fante(string nome, string grado, int anniServizio, string arma) : base(nome, grado, anniServizio)
    {
        Arma = arma;
    }

    public override void Descrizione() { Console.WriteLine($"Nome: {Nome, -15}\tGrado: {Grado, -5}\tAnni Servizio: {AnniServizio, -5}\tArma: {arma, -5}"); }
}