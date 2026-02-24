namespace RPG.Core;
/// <summary>
/// esta sera la clase que afecte al combate con las distintas caracteristicas
/// </summary>
public sealed class Atributos
{
    private int _fuerza;
    private int _defensa;
    private int _velocidad;
    private int _probabilidadCritico;
    private int _evasion;
    private int _precision;

    /// <summary>
    /// la fuerza aumentara el daño producido al atacar
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">lanza excepcion si esta fuera de rango</exception>
    public int Fuerza
    {
        get { return _fuerza; }
        set
        {
            if(value < 0)throw new  ArgumentOutOfRangeException(nameof(value), "La fuerza no puede ser negativa.");
            _fuerza = value;
        }
    }
    
    /// <summary>
    /// la defensa sera la encargada de bajar el daño recivido
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">lanza excepcion si esta fuera de rango</exception>
    public int Defensa
    {
        get { return _defensa; }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "La defensa no puede ser negativo.");
            _defensa = value;
        }
    }

    /// <summary>
    /// la velocidaad es la encargada de decidir quien ataca primero
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">lanza excepcion si esta fuera de rango</exception>
    public int Velocidad
    {
        get { return _velocidad; }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "la velocidad no puede ser negativo." );
            _velocidad = value;
        }
    }

    /// <summary>
    /// la probabilidad de dar un golpe critico, el cual causara mas daño
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">lanza excepcion si esta fuera de rango</exception>
    public int ProbabilidadCritico
    {
        get {return _probabilidadCritico;}
        set
        {
            if (value < 0 || value > 100)throw new ArgumentOutOfRangeException(nameof(value), "El critico no puede ser menos a 0% o superior a 100%");
            _probabilidadCritico = value;
        }
    }

    /// <summary>
    /// la evasion es la probabilidad de esquivar un ataque, esta es la contraparte de precision
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">lanza excepcion si esta fuera de rango</exception>
    public int Evasion
    {
        get { return _evasion; }
        set
        {
            if (value < 0 || value > 100)throw new ArgumentOutOfRangeException(nameof(value), "la evasion no puede ser menos a 0% o superior a 100%");
            _evasion = value;
        }
    }
    
    /// <summary>
    /// la precision es la encargada de aumentar la probabilidad de acierto, se estara a la evasion
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">lanza excepcion si esta fuera de rango</exception>
    public int Precision
    {
        get { return _precision; }
        set
        {
            if (value < 0 || value > 100)throw new ArgumentOutOfRangeException(nameof(value), "la precision no puede ser menos a 0% o superior a 100%");
            _precision = value;
        }
    }

    
    public Atributos(int fuerza, int defensa, int velocidad, int probabilidad,int evasion, int precision)
    {
        Fuerza = fuerza;
        Defensa = defensa;
        Velocidad = velocidad;
        ProbabilidadCritico = probabilidad;
        Evasion = evasion;
        Precision = precision;
    }

    public Atributos(int fuerza, int velocidad, int probabilidad, int precision)
    {
        Fuerza = fuerza;
        Velocidad = velocidad;
        ProbabilidadCritico = probabilidad;
        Precision = precision;
    }
    public Atributos(int defensa, int precision)
    {
        Defensa = defensa;
        Precision = precision;
    }
    
    public override string ToString() => $"Fuerza [{_fuerza}] \n Defensa [{_defensa}] \n Velocidad [{_velocidad}] \n Probabilidad de critico [{_probabilidadCritico}] \n Evasion [{_evasion}]\n Evasion [{_evasion}]";
}