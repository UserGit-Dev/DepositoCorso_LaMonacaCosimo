class Pecora : Animale
{
    public Pecora(int id, string nome, int eta) : base(id, nome, eta) {}
    public override void FaiVerso() { Console.WriteLine("La pecora fa il verso."); }
    public override void PrintInfo() { Console.WriteLine($"ID: {Id}\tTipo: Pecora\tNome: {Nome}\tEta: {Eta}"); }
}