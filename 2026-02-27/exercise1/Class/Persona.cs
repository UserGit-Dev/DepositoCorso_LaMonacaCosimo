public class Persona
{
    public string nome = string.Empty;
    public string cognome = string.Empty;
    public int annoNascita;

    public Persona(string nome, string cognome, int annoNascita)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.annoNascita = annoNascita;
    }
}