class Veicolo(string marca, string modello) {
    protected string marca = marca;
    protected string modello = modello;

    public virtual void Stampa(){ Console.WriteLine($"Marca: {marca}\tModello: {modello}"); }
}