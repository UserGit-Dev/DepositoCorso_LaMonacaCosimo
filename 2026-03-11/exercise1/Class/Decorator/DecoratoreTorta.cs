abstract class DecoratoreTorta(ITorta torta) : ITorta
{
    protected readonly ITorta _torta = torta;

    public abstract string Descrizione();
}