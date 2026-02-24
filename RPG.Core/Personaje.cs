namespace RPG.Core;

public abstract class Personaje
{
    private int _vida;
    public string? Nombre { get; }
    public int VidaMaxima{get; }
    
    public int DefensaTemporal { get; private set; }
    
    public TipoElemento TipoElemento { get; }
    
    public int Vida
    {
        get  { return _vida; }
        private set
        {
            if (value < 0) _vida = 0;
            else if (value > VidaMaxima) _vida = VidaMaxima;
            else _vida = value;
        }
    }
    public Atributos Atributos { get; protected set; }


    protected Personaje(string nombre, int vidaMaxima, Atributos atributos, TipoElemento tipoElemento)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));

        if (vidaMaxima <= 0)
            throw new ArgumentOutOfRangeException(nameof(vidaMaxima), "La vida máxima tiene que ser mayor que 0.");

        Atributos = atributos;
        TipoElemento = tipoElemento;

        Nombre = nombre;
        VidaMaxima = vidaMaxima;
        Vida = vidaMaxima;
    }

    public bool Vivo => Vida > 0;

    public void RecibirDaño(int cantidad)
    {
        if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad),"El daño no puede ser menor que 0");
        Vida -= cantidad;
    }

    public void Curar(int cantidad)
    {
        if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad),"El daño no puede ser menor que 0");
        Vida += cantidad;
    }
    
    public void ActivarDefensaTemporal(int bonus)
    {
        if (bonus < 0) bonus = 0;
        DefensaTemporal = bonus;
    }

    public void ResetDefensaTemporal()
    {
        DefensaTemporal = 0;
    }

    public override string ToString() => $"Nombre [{Nombre}] \nVida [{Vida}/{VidaMaxima}] \n{Atributos}";
}