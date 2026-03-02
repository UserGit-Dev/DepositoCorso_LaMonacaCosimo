public class Studente
{
    public string nome = string.Empty;
    public int matricola;
    public double mediaVoti;

    public Studente(string nome, int matricola, double mediaVoti)
    {
        this.nome = nome;
        this.matricola = matricola;
        this.mediaVoti = mediaVoti;
    }
}