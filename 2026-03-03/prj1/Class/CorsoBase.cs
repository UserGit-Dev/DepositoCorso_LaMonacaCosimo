class CorsoBase
{
    public string nomeCorso = string.Empty;
    public int durataOre;
    public string docente = string.Empty;
    public List<string> studenti = new();

    public CorsoBase(string nomeCorso, int durataOre, string docente)
    {
        this.nomeCorso = nomeCorso;
        this.durataOre = durataOre;
        this.docente = docente;
    }

    public void AggiungiStudente(string nomeStudente) { studenti.Add(nomeStudente); }
    public new virtual string ToString(){ return $""; }
    public virtual void MetodoSpeciale(){}
}