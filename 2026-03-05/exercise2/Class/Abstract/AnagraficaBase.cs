public abstract class AnagraficaBase
{
    private string _nome = string.Empty;
    public string Nome { get => _nome; set => _nome = value; }

    public AnagraficaBase(string nome) { Nome = nome; }

    public void StampaNome() { Console.WriteLine("Nome: " + Nome); }
}