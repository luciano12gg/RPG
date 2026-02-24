namespace RPG.Core;

public class Combate
{
    private readonly Random? _random;

    public Combate()
    {
        _random = new Random();
    }


    public bool Atacar(Personaje atacante, Personaje defensor, IArma arma, out int danio, out string mensaje)
    {
        // calculamos la probabilidad de que haga un golpe
        int precisionTotal = atacante.Atributos.Precision + arma.Atributos.Precision;
        int evasionTotal = defensor.Atributos.Evasion;
        
        int probabilidadImpacto = precisionTotal -  evasionTotal;

        if (probabilidadImpacto < 0) probabilidadImpacto = 5;
        
        int tirada = _random!.Next(0, 101);
        if (tirada > probabilidadImpacto)
        {
            danio = 0;
            mensaje = $"{atacante.Nombre} ha fallado el golpe";
            return false;
        }
        
        // calculamos del daño que produce el ataque

        int danioTotal = atacante.Atributos.Fuerza + arma.Atributos.Fuerza;

        if (TieneVentaja(arma.Tipo, defensor.TipoElemento))
            danioTotal *= 2;

        int defensaTotal = defensor.Atributos.Defensa;

        danio = danioTotal -  defensaTotal;
        if (danio < 0) danio = 0;

        int criticoTotal = atacante.Atributos.ProbabilidadCritico + arma.Atributos.ProbabilidadCritico;
        bool critico = _random.Next(0, 101) <= criticoTotal;
        if (critico) danio *= 2;

        defensor.RecibirDaño(danio);

        mensaje = $"{atacante.Nombre} ha inflijido {danio} de daño a {defensor.Nombre}";
        return true;
        
    }

    public static bool TieneVentaja(TipoElemento ataque, TipoElemento defiende)
    {
        if (ataque == TipoElemento.Divino && defiende != TipoElemento.Divino) return true;
        if (ataque == defiende) return false;
        if (ataque == TipoElemento.Fuego && defiende == TipoElemento.Planta) return true;
        if (ataque == TipoElemento.Planta && defiende == TipoElemento.Agua) return true;
        if (ataque == TipoElemento.Agua && defiende == TipoElemento.Fuego) return true;
        return false;
    }
}