class CorsoInPresenza : Corso
{
    private string _aula = string.Empty;
    private int _numeroPosti = string.Empty;

    public string Aula { 
        get => _aula; 
        set {
            if (value is < 1) throw new ArgumentException("Errore di inizializzazione. Aula (Min: 1)");
            else _aula = value; 
        }
    }
    public string NumeroPosti { get => _numeroPosti; set => _numeroPosti = value; }
    
    public CorsoInPresenza(string titolo, int durataOre, string aula, int numeroPosti) : base(titolo, durataOre)
    {
        Aula = aula;
        NumeroPosti = numeroPosti;
    }
}