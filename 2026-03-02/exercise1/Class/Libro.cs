class Libro
{
    public string Titolo = "Titolo X";
    public string Autore = "Autore X";
    public int AnnoPubblicazione = 2026;

    public override string ToString()
    {
        return $"{Titolo} di {Autore}, anno {AnnoPubblicazione}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Libro libro2)
        {
            return this.Titolo == libro2.Titolo && this.Autore == libro2.Autore;    
        } else return false;
        
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore);
    }

    public Libro Clone() {
        return (Libro)this.MemberwiseClone();
    }
}