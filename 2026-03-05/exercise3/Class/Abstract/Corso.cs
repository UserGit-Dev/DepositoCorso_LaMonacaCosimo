abstract class Corso : Docente {
    private string _titolo = string.Empty;
    private int _durataOre;

    public string Titolo { get => _titolo; set => _titolo = value; }
    public int DurataOre { 
        get => _durataOre; 
        set
        {
            if (value is < 0) throw new ArgumentException("Errore di inizializzazione. Durata ore (Valori non negativi)");
            else _durataOre = value;
        }
    }

    public Corso(string nomeDocente, string materia, string titolo, int durataOre) : base(nomeDocente, materia) 
    { Titolo = titolo; DurataOre = durataOre; }

    public abstract void ErogaCorso();
    public abstract void StampaDettagli();
}