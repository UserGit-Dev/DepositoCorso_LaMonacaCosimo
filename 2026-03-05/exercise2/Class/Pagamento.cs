public class Pagamento : AnagraficaBase, IPagamento
{
    private string _circuito = string.Empty;
    public string Circuito { get => _circuito; set => _circuito = value; }

    public Pagamento(string nome, string circuito) : base(nome) { Circuito = circuito; }
    
    public void EseguiPagamento(decimal import) { 
        Console.WriteLine($"Pagamento di {import} euro con carta (Circuito: {Circuito})"); 
    }
    public void MostraPagamento(){ Console.WriteLine("Metodo: Carta di credito"); }
}