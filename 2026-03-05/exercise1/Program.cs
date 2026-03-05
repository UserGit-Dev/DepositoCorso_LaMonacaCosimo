class Program
{
    public static void Main()
    {
        List<DispositivoElettronicoBase> listDispositivi = [];
        listDispositivi.Add(new Computer("Apple "));
        listDispositivi.Add(new Stampante("LG"));
        
        Console.WriteLine(new string('-', 30));
        foreach(DispositivoElettronicoBase dispositivo in listDispositivi)
        {
            dispositivo.MostraInfo();
            dispositivo.Accendi();
            dispositivo.Spegni();
            Console.WriteLine(new string('-', 30));
        }
    }
}