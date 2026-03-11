class ConGlassa(ITorta torta) : DecoratoreTorta(torta)
{
    public override string Descrizione() =>  _torta.Descrizione() + ", con glassa";
}