abstract class Animale : IdentifierBase
{
    private string _nome = string.Empty; // Per quietare il compilatore (essendo non nullable)
    private int _eta;

    public string Nome { get => _nome; set => _nome = value; }
    public int Eta { get => _eta; set => _eta = value; }

    public Animale(int id, string nome, int eta) : base(id)
    {
        Nome = nome; Eta = eta;
    }

    public abstract void FaiVerso();
    public abstract void PrintInfo();
}