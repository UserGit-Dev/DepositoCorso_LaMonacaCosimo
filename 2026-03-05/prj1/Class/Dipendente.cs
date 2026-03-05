class Dipendente : Persona
{
    private long _id;
    private string _badgeCode = string.Empty;
    private string _password = string.Empty;
    private string _turno = string.Empty;
    private decimal _salario;
    private bool _isPresent = false;

    public long Id { get => _id; set => _id = value; }
    public string BadgeCode { get => _badgeCode; set => _badgeCode = value; }
    public string Password { get => _password; set => _password = value; }
    public string Turno { get => _turno; set => _turno = value; }
    public decimal Salario { get => _salario; set => _salario = value; }
    public bool IsPresent { get => _isPresent; set => _isPresent = value; }

    public Dipendente(string nome, string cognome, string codiceFiscale, DateOnly dataNascita, 
        long id, string badgeCode, string password, string turno, decimal salario) : base(nome, cognome, codiceFiscale, dataNascita)
    {
        Id = id; BadgeCode = badgeCode; Password = password; Turno = turno; Salario = salario;
    }

    public string PrintAnagraficaDipendente()
    {
        return $"Id: {Id}{TxtSpacing()}BadgeCode: {BadgeCode}{TxtSpacing()}" 
        + $"Turno: {Turno}{TxtSpacing()}Salario: {Salario}{TxtSpacing()}Presente?: {IsPresent}";
    }
    public string PrintAnagraficaCompleta()
    {
        return $"Nome: {Nome}{TxtSpacing()}Cognome: {Cognome}{TxtSpacing()}Codice Fiscale: {CodiceFiscale}{TxtSpacing()}" 
        + $"DataNascita: {DataNascita}{TxtSpacing()}ID: {DataNascita}{TxtSpacing()}DataNascita: {DataNascita}{TxtSpacing()}"
        + $"Id: {Id}{TxtSpacing()}BadgeCode: {BadgeCode}{TxtSpacing()}Password: {Password}{TxtSpacing()}Turno: {Turno}{TxtSpacing()}" 
        + $"Salario: {Salario}{TxtSpacing()}Presente?: {IsPresent}";
    }
}