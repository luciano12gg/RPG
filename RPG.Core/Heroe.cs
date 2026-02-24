namespace RPG.Core;

public class Heroe : Personaje
{
    private List<IArma> _inventario;
    public List<IArma> Inventario
    {
        get {return _inventario;}
    }
    
    
    public Heroe(string nombre, int vidaMaxima, Atributos atributos, TipoElemento elemento) : base(nombre, vidaMaxima, atributos, elemento)
    {
        _inventario = new List<IArma>();
    }
    
    public void AgregarArma(IArma arma)
    {
        if (arma == null)throw new ArgumentNullException(nameof(arma), "el arma no existe");
        _inventario.Add(arma);
    }

    public override string ToString() => base.ToString() + $"\nArmas: {_inventario.Count}";
}

