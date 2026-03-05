class CorsoOnline : Corso
{
    private string _piattaforma = string.Empty;
    private int _linkAccesso = string.Empty;

    public string Piattaforma { get => _piattaforma; set => _piattaforma = value; }
    public string LinkAccesso { get => _linkAccesso; set => _linkAccesso = value; }
    
    public CorsoOnline(string titolo, int durataOre, string piattaforma, int linkAccesso) : base(titolo, durataOre)
    {
        Piattaforma = piattaforma;
        LinkAccesso = linkAccesso;
    }
}