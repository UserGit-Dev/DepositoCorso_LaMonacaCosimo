public class Stampante : DispositivoElettronicoBase
{
    public override void Accendi(){ Console.WriteLine("Il stampante si accende..."); }
    public override void Spegni(){ Console.WriteLine("Il stampante va in standby..."); }

    public Stampante(string modello) : base(modello) {}
}