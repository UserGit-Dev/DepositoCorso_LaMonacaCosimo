class Camion : Veicolo
{
    public Camion(string targa) : base(targa) {}

    public override void Stampa()
    {
        Console.WriteLine("Controllo sospensioni, freni rinforzati e carico del camion.");
    }
}