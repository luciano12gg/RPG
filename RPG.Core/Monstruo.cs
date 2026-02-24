namespace RPG.Core;

public class Monstruo : Personaje
{
    private List<IArma> _ataque;

    public List<IArma> Ataque
    {
        get { return _ataque; }
    }
    
    
    public Monstruo(string nombre, int vidaMaxima, Atributos atributos, TipoElemento elemento) : base(nombre, vidaMaxima, atributos,elemento)
    {
        _ataque = new List<IArma>();
    }

    public void AgregarAtaque(IArma ataque)
    {
        if (ataque == null)throw new ArgumentNullException(nameof(ataque), "No existe ningun ataque");
        _ataque.Add(ataque);
    }
    public override string ToString() => base.ToString() + $"\nAtaques: {_ataque.Count}";
}