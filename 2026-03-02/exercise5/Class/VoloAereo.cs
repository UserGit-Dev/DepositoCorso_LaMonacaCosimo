class VoloAereo
{
    private int postiOccupati;
    public const int maxPosti = 150;
    public string CodiceVolo { get; set; } = string.Empty;
    public int PostiOccupati { get { return postiOccupati; } }
    public int PostiLiberi { get { return maxPosti - postiOccupati; } }

    public bool EffettuaPrenotazione(int numeroPosti)
    {
        if(numeroPosti > PostiLiberi) { return false; }
        else { 
            postiOccupati = numeroPosti;
            return true; 
        }
    }
    public bool AnnullaPrenotazione(int numeroPosti)
    {
        if(numeroPosti > postiOccupati) { return false; } 
        else { 
            postiOccupati -= numeroPosti;
            return true; 
        }
    }
}