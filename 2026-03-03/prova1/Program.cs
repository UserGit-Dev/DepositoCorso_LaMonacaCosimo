public class ContoBancario
{
    // Campo privato (non accessibile direttamente dall'esterno)
    private double saldo;

    // Proprietà per accedere al saldo in modo controllato
    public double Saldo
    {
        get { return saldo; } // permette la lettura del saldo
        set
        {
            if (value >= 0)    // solo valori validi
                saldo = value;
        }
    }
}

public class Programma
{
    public static void Main()
    {
        ContoBancario conto = new ContoBancario();

        conto.Saldo = 1000.50;           // imposta il saldo tramite la proprietà
        Console.WriteLine(conto.Saldo);  // legge il saldo tramite la proprietà

        conto.Saldo = -500;              // non modifica il saldo che è negativo
        Console.WriteLine(conto.Saldo);  // rimane 1000.50
    }
}