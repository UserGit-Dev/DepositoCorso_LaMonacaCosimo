class TortaFactory
{
    private static Lazy<TortaFactory> _instance = new (() => new TortaFactory());

    public static TortaFactory Instance => _instance.Value;

    public ITorta? CreaTorta(string tipo)
    {
        switch (tipo)
        {
            case "Cioccolato":
                return new TortaCioccolato();
            case "Vaniglia":
                return new TortaVaniglia();
            case "Frutta":
                return new TortaFrutta();
            default:
                return null;
        }
    }
}