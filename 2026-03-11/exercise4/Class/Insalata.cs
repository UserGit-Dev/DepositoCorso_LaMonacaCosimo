class Insalata : IPiatto
{
    // Descrivi il tipo di piatto
    public string Descrizione() => "Insalata";
    // Spiega che il piatto è in preparazione
    public string Prepara() => Descrizione() + " in preparazione";
}