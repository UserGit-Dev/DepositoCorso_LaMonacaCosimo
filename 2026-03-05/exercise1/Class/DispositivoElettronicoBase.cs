public abstract class DispositivoElettronicoBase
{
    public string Modello { get; set; }

    public abstract void Accendi();
    public abstract void Spegni();
    public virtual void MostraInfo() { Console.WriteLine("Modello: " + Modello); }

    public DispositivoElettronicoBase(string modello) { Modello = modello; }
}