class CorsoDanza : CorsoBase
{
    public string stile = string.Empty;
    
    public CorsoDanza(string nomeCorso, int durataOre, string docente, string stile) : base(nomeCorso, durataOre, docente)
    {
        this.stile = stile;
    }
    
    public override string ToString() { return $"Tipo: {"Danza", -10}\tCorso: {nomeCorso, -10}\tDurata: {durataOre, -10}\tDocente: {docente, -10}\tStile: {stile, -10}"; }
    public override void MetodoSpeciale() { Console.WriteLine($"Esecuzione coreografica nello stile: {stile}"); }
}