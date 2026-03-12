class Chef(IPreparazioneStrategia prepStrat) : IPreparazioneStrategia
{
    // Ospita oggetto che rappresenta il tipo di cottura
    private IPreparazioneStrategia _prepStrat = prepStrat;

    // Qualora volessi cambiare il tipo di cottura
    public void SetStrat(IPreparazioneStrategia prepStrat) => _prepStrat = prepStrat;
    // Chiamo il metodo poliformico del tipo di cottura attualmente in uso
    public void PreparaPiatto() => _prepStrat.PreparaPiatto();
}