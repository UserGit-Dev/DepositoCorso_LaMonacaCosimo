class PagamentoPayPal : AnagraficaBase, IPagamento
{
    private string _emailUtente = string.Empty;
    public string EmailUtente { get => _emailUtente; set => _emailUtente = value; }

    public PagamentoPayPal(string nome, string email) : base(nome) { EmailUtente = email; }

    public void EseguiPagamento(decimal import) { 
        Console.WriteLine($"Pagamento di {import} euro in tramite PayPal da: {EmailUtente}"); 
    }
    public void MostraPagamento(){ Console.WriteLine("Metodo: PayPal"); }
}