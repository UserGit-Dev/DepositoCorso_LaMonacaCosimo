class Moto : Veicolo
{
    public Moto(string targa) : base(targa) {}

    public override void Stampa()
    {
        Console.WriteLine("Controllo catena, freni e gomme della moto.");
    }
}