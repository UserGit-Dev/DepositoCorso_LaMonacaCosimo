class Dipendente : Persona
{
    private long _id;
    private string _badge = string.Empty;
    private string _turno = string.Empty;
    private decimal _salario;
    private bool _isPresent = false;

    public long Id { get => _id; set => _id = value; }
    public string Badge { get => _badge; set => _badge = value; }
    public string Turno { get => _turno; set => _turno = value; }
    public decimal Salario { get => _salario; set => _salario = value; }
    public bool IsPresent { get => _isPresent; set => _isPresent = value; }

    public Dipendente(string nome, string cognome, string codiceFiscale, DateOnly dataNascita, 
        long id, string badge, string turno, decimal salario) : base(nome, cognome, codiceFiscale, dataNascita)
    {
        Id = id; Badge = badge; Turno = turno; Salario = salario;
    }

    public string PrintAnagraficaDipendente()
    {
        return $"Id: {Id}{TxtSpacing()}Badge: {Badge}{TxtSpacing()}" 
        + $"Turno: {Turno}{TxtSpacing()}Salario: {Salario}{TxtSpacing()}Presente?: {IsPresent}";
    }
    public string PrintAnagraficaCompleta()
    {
        return $"Nome: {Nome}{TxtSpacing()}Cognome: {Cognome}{TxtSpacing()}Codice Fiscale: {CodiceFiscale}{TxtSpacing()}" 
        + $"DataNascita: {DataNascita}{TxtSpacing()}ID: {DataNascita}{TxtSpacing()}DataNascita: {DataNascita}{TxtSpacing()}"
        + $"Id: {Id}{TxtSpacing()}Badge: {Badge}{TxtSpacing()}Turno: {Turno}{TxtSpacing()}Salario: {Salario}{TxtSpacing()}" 
        + $"Presente?: {IsPresent}";
    }
}