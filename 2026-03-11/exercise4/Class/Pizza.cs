class Pizza : IPiatto
{
    // Descrivi il tipo di piatto
    public string Descrizione() => "Pizza";
    // Spiega che il piatto è in preparazione
    public string Prepara() => Descrizione() + " in preparazione";
}