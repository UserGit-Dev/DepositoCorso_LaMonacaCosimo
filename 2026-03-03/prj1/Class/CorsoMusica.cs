class CorsoMusica : CorsoBase
{
    public string strumento = string.Empty;
    
    public CorsoMusica(string nomeCorso, int durata, string docente, string strumento) : base(nomeCorso, durata, docente)
    {
        this.strumento = strumento;
    }
    
    public override string ToString() { return $"Tipo: {"Musica", -10}\tCorso: {nomeCorso, -10}\tDurata: {durataOre, -10}\tDocente: {docente, -10}\tStrumento: {strumento, -10}"; }
    public override void MetodoSpeciale() { Console.WriteLine($"Si tiene una prova pratica dello strumento: {strumento}"); }
}