using RPG.Core;

namespace RPG.Tests;

public class HeroeTests
{
    [Fact]
    public void Heroe_Inicia_Con_Vida_Maxima()
    {
        Heroe heroe = CrearHeroe();

        Assert.Equal(heroe.VidaMaxima, heroe.Vida);
    }

    [Fact]
    public void RecibirDanio_Resta_Vida()
    {
        Heroe heroe = CrearHeroe();

        heroe.RecibirDaño(10);

        Assert.Equal(40, heroe.Vida);
    }

    [Fact]
    public void Curar_No_Supera_VidaMaxima()
    {
        Heroe heroe = CrearHeroe();
        heroe.RecibirDaño(10);

        heroe.Curar(999);

        Assert.Equal(heroe.VidaMaxima, heroe.Vida);
    }

    [Fact]
    public void AgregarArma_Nula_Lanza_Excepcion()
    {
        Heroe heroe = CrearHeroe();

        Assert.Throws<ArgumentNullException>(() => heroe.AgregarArma(null!));
    }

    private static Heroe CrearHeroe()
    {
        var atributos = new Atributos(10, 5, 5, 0, 0, 100);
        return new Heroe("TestHero", 50, atributos, TipoElemento.Fuego);
    }
}
