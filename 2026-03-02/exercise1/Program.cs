class Program()
{
    public static void Main()
    {
        Libro libro1 = new();
        Libro libro2 = new();
        Libro libro3 = libro1.Clone();
        Libro libro4 = libro1;
        Console.WriteLine("Libro 1: " + libro1);
        Console.WriteLine("Libro 2: " + libro2);
        Console.WriteLine("Libro 3: " + libro3);
        Console.WriteLine("Libro 4: " + libro4);
        Console.WriteLine("Libro 1, 2, 3, 4 sono lo stesso libro (Equals)? => " + ((libro1.Equals(libro2) && libro3.Equals(libro4)) ? "Si" : "No"));
        Console.WriteLine("Libro1 (Hash Code): " + libro1.GetHashCode());
        Console.WriteLine("Libro2 (Hash Code): " + libro2.GetHashCode());
        Console.WriteLine("Libro3 (Hash Code): " + libro3.GetHashCode());
        Console.WriteLine("Libro4 (Hash Code): " + libro4.GetHashCode());
        Console.WriteLine("Libro 1 e libro 2 sono la stessa istanza => " + (object.ReferenceEquals(libro1, libro2) ? "Si" : "No"));
        Console.WriteLine("Libro 1 e libro 3 sono la stessa istanza => " + (object.ReferenceEquals(libro1, libro3) ? "Si" : "No"));
        Console.WriteLine("Libro 1 e libro 4 sono la stessa istanza => " + (object.ReferenceEquals(libro1, libro4) ? "Si" : "No"));
    }
}