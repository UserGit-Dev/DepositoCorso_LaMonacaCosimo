class Persona {
    public string nome = "Marco";
    public string cognome = "Polo";
    public Persona(){}

    public override string ToString()
    {
        return $"Nome e Cognome: {nome} {cognome}";
    }

    public override bool Equals(object? obj) {
        if (obj is Persona persona2) {
            return this.nome.ToLower() == persona2.nome.ToLower() 
            && this.cognome.ToLower() == persona2.cognome.ToLower();
        } else return false;
    }
}