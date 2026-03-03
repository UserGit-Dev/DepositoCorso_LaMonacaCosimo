class Auto : Veicolo
{
    public Auto(string targa) : base(targa) {}
    public string test = "!!!";

    public override void Stampa()
    {
        Console.WriteLine($"{test} - Controllo olio, freni e motore dell'auto.");
    }
}