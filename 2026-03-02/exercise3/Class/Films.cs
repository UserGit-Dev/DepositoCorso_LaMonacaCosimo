class Film(string titolo, string regista, int anno, string genere)
{
    public string titolo = titolo;
    public string regista = regista;
    public int anno = anno;
    public string genere = genere;

    public override string ToString()
    {
        return $"Titolo: {titolo}\tRegista: {regista}\tAnno: {anno}\tGenere: {genere}";
    }
}