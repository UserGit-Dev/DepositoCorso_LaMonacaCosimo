class Operazioni()
{
    public int Somma(int a, int b) { return a + b; }
    public int Moltiplica(int a, int b) { return a * b; }

    public void StampaRisultato(string operazione, int risultato) {
        Console.WriteLine($"Operazione: {operazione} => {risultato}");
    }
}