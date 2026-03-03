class CorsoPittura : CorsoBase
{
    public string tecnica = string.Empty;
    
    public CorsoPittura(string nomeCorso, int durata, string docente, string tecnica) : base(nomeCorso, durata, docente)
    {
        this.tecnica = tecnica;
    
    }
    public override string ToString() { return $"Tipo: {"Pittura", -10}\tCorso: {nomeCorso, -10}\tDurata: {durataOre, -10}\tDocente: {docente, -10}\tTecnica: {tecnica, -10}"; }
    public override void MetodoSpeciale() { Console.WriteLine($"Si lavora su tela con tecnica: {tecnica}"); }
}