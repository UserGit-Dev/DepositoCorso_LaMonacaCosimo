class PrenotazioneViaggio
{
    public const int maxPosti = 20;
    private int postiPrenotati;
    public string Destinazione { get; set; } = string.Empty;
    public int PostiDisponibili { get { return maxPosti - postiPrenotati; } }
    public int PostiPrenotati { get { return postiPrenotati; } }

    public PrenotazioneViaggio(string destinazione)
    {
        Destinazione = destinazione;
    }

    public bool PrenotaPosti(int numeroPosti)
    {
        if(numeroPosti > PostiDisponibili) { return false; }
        else { 
            postiPrenotati = numeroPosti;
            return true; 
        }
    }
    public bool AnnullaPrenotazione(int numeroPosti)
    {
        if(numeroPosti > postiPrenotati) { return false; } 
        else { 
            postiPrenotati -= numeroPosti;
            return true; 
        }
    }
}