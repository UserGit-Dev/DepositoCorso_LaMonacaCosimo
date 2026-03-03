class Program
{
    public static void Main()
    {
        List<Veicolo> listVeicolo = 
        [
            new Auto("12345"),
            new Moto("ABCDE"),
            new Camion("!£$%&"),
        ];

        foreach(Veicolo veicolo in listVeicolo) { veicolo.Stampa(); }
    }
}