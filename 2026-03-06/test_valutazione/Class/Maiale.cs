class Maiale : Animale
{
    public Maiale(int id, string nome, int eta) : base(id, nome, eta) {}
    public override void FaiVerso() { Console.WriteLine("Il maiale fa il verso."); }
    public override void PrintInfo() { Console.WriteLine($"ID: {Id}\tTipo: Maiale\tNome: {Nome}\tEta: {Eta}"); }
}