class Veicolo
{
    public string Targa { get; set; } = string.Empty;

    public Veicolo(string targa) { Targa = targa; }
    
    public virtual void Stampa()
    {
        Console.WriteLine("Il veicolo viene controllato.");
    } 
}