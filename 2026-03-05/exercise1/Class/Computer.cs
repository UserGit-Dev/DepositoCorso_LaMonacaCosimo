public class Computer : DispositivoElettronicoBase
{
    public override void Accendi(){ Console.WriteLine("Il computer si avvia..."); }
    public override void Spegni(){ Console.WriteLine("Il computer si spegne..."); }

    public Computer(string modello) : base(modello) {}
}