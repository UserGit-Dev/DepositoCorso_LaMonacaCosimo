class Auto : Veicolo
{
    private int numeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)
    {
        this.numeroPorte = numeroPorte;
    }
    public override void Stampa(){ Console.WriteLine($"Marca: {marca}\tModello: {modello}\tNum. Porte: {numeroPorte}"); }
}