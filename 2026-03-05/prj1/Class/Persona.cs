class Persona
{
    private string _nome = string.Empty;
    private string _cognome = string.Empty;
    private string _codiceFiscale = string.Empty;
    private DateOnly _dataNascita;
    private DateTime _createdAt;
    private DateTime _modifiedAt;
    private DateTime _lastLogin;
    private DateTime _lastLogout;
    
    public string Nome { get => _nome; set { _nome = value; ModifiedAtUpdate();} }
    public string Cognome { get => _cognome; set { _cognome = value; ModifiedAtUpdate();} }
    public string CodiceFiscale { get => _codiceFiscale; set { _codiceFiscale = value; ModifiedAtUpdate();} }
    public DateOnly DataNascita { get => _dataNascita; set { _dataNascita = value; ModifiedAtUpdate();} }
    public DateTime CreatedAt { get => _createdAt; private set => _createdAt = value; }
    public DateTime ModifiedAt { get => _modifiedAt; private set => _modifiedAt = value; }
    public DateTime LastLogin { get => _lastLogin; private set => _lastLogin = value; }
    public DateTime LastLogout { get => _lastLogout; private set => _lastLogout = value; }


    public Persona(string nome, string cognome, string codiceFiscale, DateOnly dataNascita) 
    { 
        Nome = nome; Cognome = cognome; CodiceFiscale = codiceFiscale; DataNascita = dataNascita;

        DateTime utcNow = DateTime.UtcNow; // Variabile temporanea
        CreatedAt = utcNow; ModifiedAt = utcNow; // Così avranno la stessa data
    }

    protected void ModifiedAtUpdate() 
    {
        ModifiedAt = DateTime.UtcNow;
    }
    public void LastLoginUpdate() 
    {
        LastLogin = DateTime.UtcNow;
    }
    public void LastLogoutUpdate() 
    {
        LastLogout = DateTime.UtcNow;
    }

    public string ToPrintAnagraficaPersona()
    {
        return $"\nNome: {Nome}\nCognome: {Cognome}\nCodice Fiscale: {CodiceFiscale}\nData di Nascita: {DataNascita}\n" 
        + $"Modificato il: {ModifiedAt}\nCreato il: {CreatedAt}\nUltimo Login: {LastLogin}\nUltimo Logout: {LastLogout}\n";
    }
}