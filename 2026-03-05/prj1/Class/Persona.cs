class Persona : IFormatSpacing
{
    private string _nome = string.Empty;
    private string _cognome = string.Empty;
    private string _codiceFiscale = string.Empty;
    private DateOnly _dataNascita;
    
    public string Nome { get => _nome; set => _nome = value; }
    public string Cognome { get => _cognome; set => _cognome = value; }
    public string CodiceFiscale { get => _codiceFiscale; set => _codiceFiscale = value; }
    public DateOnly DataNascita { get => _dataNascita; set => _dataNascita = value; }

    public Persona(string nome, string cognome, string codiceFiscale, DateOnly dataNascita) 
    { 
        Nome = nome; Cognome = cognome; CodiceFiscale = codiceFiscale; DataNascita = dataNascita;
    }

    public string PrintAnagraficaPersona()
    {
        return $"Nome: {Nome}{TxtSpacing()}Cognome: {Cognome}{TxtSpacing()}" 
        + $"Codice Fiscale: {CodiceFiscale}{TxtSpacing()}DataNascita: {DataNascita}{TxtSpacing()}";
    }

    // Altro
    protected static string TxtSpacing()
    {
        byte leftPad = 5;
        byte rightPad = 5;
        char separator = '|';
        return $"{new string(' ', leftPad)}{separator}{new string(' ', rightPad)}";
    }
}