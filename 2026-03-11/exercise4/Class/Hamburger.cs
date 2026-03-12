class Hamburger : IPiatto
{
    // Descrivi il tipo di piatto
    public string Descrizione() => "Hamburger";
    // Spiega che il piatto è in preparazione
    public string Prepara() => Descrizione() + " in preparazione";
}