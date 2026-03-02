// Classe base
public class Animale
{
    public void FaiVerso()
    {
        
        Console.WriteLine("L'animale fa un verso.");
    }
}

// Classe derivata
public class Cane : Animale
{
    // Metodo specifico della classe derivata
    public void Scodinzola()
    {
        Console.WriteLine("Il cane scodinzola.");
    }
}

// Programma principale
public class Program()
{
    public static void Main()
    {
        Cane mioCane = new Cane(); // Creazione di un oggetto della classe derivata
        mioCane.FaiVerso();        // Metodo ereditato dalla classe base
        mioCane.Scodinzola();      // Metodo definito nella classe derivata
    }
}