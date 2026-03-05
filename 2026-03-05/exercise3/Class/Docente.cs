class Docente
{
    private string _nome = string.Empty;
    private string _materia = string.Empty;

    public string Nome { get => _nome; set => _nome = value; }
    public string Materia { get => _materia; set => _materia = value; }

    public Docente(string nome, string materia) { Nome = nome; Materia = materia; }
}