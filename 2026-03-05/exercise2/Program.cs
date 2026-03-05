class Program
{
    // O mi avvalgo di abstract (errore di visibilita dei metodi di interfaccio o vice versa). Da completare.
    public static void Main()
    {
        Random random = new();
        List<AnagraficaBase> listPagamento = [];
        listPagamento.Add(new Pagamento("Franco", "Master Card"));
        listPagamento.Add(new PagamentoContanti("Paolo"));
        listPagamento.Add(new PagamentoPayPal("Gino", "esempio@gmail.com"));

        Console.WriteLine(new string('_', 70));
        foreach (AnagraficaBase pagamento in listPagamento)
        {
            pagamento.StampaNome();
            pagamento.EseguiPagamento((decimal)random.Next());
            pagamento.MostraPagamento();
            Console.WriteLine(new string('_', 70));
        }
    }
}