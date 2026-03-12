class Program
{
    static void Main()
    {
        // Attach e notifica di un observer
        Console.WriteLine("\nNotifica all'operatore...");
        GamingSetupFacade.Instance.Attach(new Observer("Aldo"));
        GamingSetupFacade.Instance.Notify();

        Console.WriteLine("\nAvvio della postazione...");
        GamingSetupFacade.Instance.AvviaPostazione();

        Console.WriteLine("\nSpegnimento...");
        GamingSetupFacade.Instance.SpegniPostazione();

        Console.WriteLine("\nPremere un tasto per terminare...");
        Console.ReadKey(true);
        Console.Clear();
    }
}