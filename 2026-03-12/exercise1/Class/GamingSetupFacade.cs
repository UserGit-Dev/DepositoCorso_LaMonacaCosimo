class GamingSetupFacade
{
    private static Lazy<GamingSetupFacade> _instance = new(() => new GamingSetupFacade());
    private readonly Monitor _monitor = new();
    private readonly Tastiera _tastiera = new();
    private readonly Mouse _mouse = new();
    private readonly SchedaVideo _schedaVideo = new();
    List<Observer> _listOb = [];

    public static GamingSetupFacade Instance => _instance.Value;

    public void AvviaPostazione()
    {
        _monitor.Accendi();
        _tastiera.Collega();
        _mouse.Collega();
        _schedaVideo.Attiva();
    }
    public void SpegniPostazione()
    {
        _monitor.Spegni();
        _tastiera.Scollega();
        _mouse.Scollega();
        _schedaVideo.Disattiva();
    }

    public void Attach(Observer ob) { _listOb.Add(ob); }
    public void Detach(Observer ob) { _listOb.Remove(ob);}
    public void Notify() { foreach (var ob in _listOb) ob.Update(); }
}