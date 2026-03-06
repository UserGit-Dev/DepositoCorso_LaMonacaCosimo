class Gallina : Animale
{
    public Gallina(int id, string nome, int eta) : base(id, nome, eta) {}
    public override void FaiVerso() { Console.WriteLine("La gallina fa il verso."); }
    public override void PrintInfo() { Console.WriteLine($"ID: {Id}\tTipo: Gallina\tNome: {Nome}\tEta: {Eta}"); }
}