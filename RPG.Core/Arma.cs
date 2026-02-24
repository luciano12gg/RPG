namespace RPG.Core;

public class Arma : IArma
{
    public string Nombre { get; }
    public TipoElemento Tipo { get; }
    public Atributos Atributos { get; }

    public TipoAccion Accion { get; }
    
    
    public Arma(string nombre, TipoElemento elemento, Atributos atributos, TipoAccion accion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        
        Nombre = nombre;
        Tipo = elemento;
        Atributos = atributos;
        Accion = accion;
    }

    public override string ToString() => $"Nombre [{Nombre}]/ Tipo [{Tipo}]/ Atributos [{Atributos}]";
}