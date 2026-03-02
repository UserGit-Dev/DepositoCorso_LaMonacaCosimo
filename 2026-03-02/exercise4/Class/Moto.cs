class Moto : Veicolo
{
    private string tipoManubrio = string.Empty;

    public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)
    {
        this.tipoManubrio = tipoManubrio;
    }
    public override void Stampa(){ Console.WriteLine($"Marca: {marca}\tModello: {modello}\tTipo manubrio: {tipoManubrio}"); }
}