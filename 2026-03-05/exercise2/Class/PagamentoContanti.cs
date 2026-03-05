class PagamentoContanti : AnagraficaBase, IPagamento
{
    public PagamentoContanti(string nome) : base(nome) {}

    public void EseguiPagamento(decimal import) { 
        Console.WriteLine($"Pagamento di {import} euro in contanti)"); 
    }
    public void MostraPagamento(){ Console.WriteLine("Metodo: Contanti"); }
}