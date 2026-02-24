using RPG.Core;

namespace RPG.Tests;

public class CombateTests
{
    [Fact]
    public void TieneVentaja_Fuego_Contra_Planta_Es_True()
    {
        bool ventaja = Combate.TieneVentaja(TipoElemento.Fuego, TipoElemento.Planta);

        Assert.True(ventaja);
    }

    [Fact]
    public void TieneVentaja_MismoElemento_Es_False()
    {
        bool ventaja = Combate.TieneVentaja(TipoElemento.Agua, TipoElemento.Agua);

        Assert.False(ventaja);
    }

    [Fact]
    public void Atacar_Con_Precision_Alta_Aplica_Danio()
    {
        var combate = new Combate();
        Heroe atacante = CrearHeroeAtacante();
        Monstruo defensor = CrearMonstruoDefensor();
        IArma arma = new Arma("Golpe", TipoElemento.Fuego, new Atributos(5, 0, 0, 0), TipoAccion.Ataque);

        bool acierto = combate.Atacar(atacante, defensor, arma, out int danio, out _);

        Assert.True(acierto);
        Assert.InRange(danio, 15, 30);
        Assert.Equal(defensor.VidaMaxima - danio, defensor.Vida);
    }

    private static Heroe CrearHeroeAtacante()
    {
        var atributos = new Atributos(10, 0, 0, 0, 0, 100);
        return new Heroe("Hero", 100, atributos, TipoElemento.Fuego);
    }

    private static Monstruo CrearMonstruoDefensor()
    {
        var atributos = new Atributos(0, 0, 0, 0, 0, 0);
        return new Monstruo("Enemy", 100, atributos, TipoElemento.Planta);
    }
}
