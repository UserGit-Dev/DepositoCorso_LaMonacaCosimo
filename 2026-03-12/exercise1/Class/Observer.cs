class Observer(string nome)
{
    private string _nome = nome;

    public void Update() => Console.WriteLine("Attenzione, un cliente sta interagendo con una postazione.");
}