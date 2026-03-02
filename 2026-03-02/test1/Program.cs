class Program
{
    public static void Main()
    {
        Persona persona1 = new();
        Persona persona2 = new();
        Console.WriteLine(persona1.ToString());
        Console.WriteLine("Persona 1 e Persona 2 sono la stessa persona? => " + persona1.Equals(persona2));
        Console.ReadKey(true);
    } 
}