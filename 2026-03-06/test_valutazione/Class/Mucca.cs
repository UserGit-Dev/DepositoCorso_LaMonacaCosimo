class Mucca : Animale
{
    public Mucca(int id, string nome, int eta) : base(id, nome, eta) {}
    public override void FaiVerso() { Console.WriteLine("La mucca fa il verso."); }
    public override void PrintInfo() { Console.WriteLine($"ID: {Id}\tTipo: Mucca\tNome: {Nome}\tEta: {Eta}"); }
}