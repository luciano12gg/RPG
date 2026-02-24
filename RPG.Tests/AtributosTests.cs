using RPG.Core;

namespace RPG.Tests;

public class AtributosTests
{
    [Fact]
    public void Constructor_Asigna_Valores_Correctos()
    {
        var atributos = new Atributos(10, 5, 7, 25, 15, 80);

        Assert.Equal(10, atributos.Fuerza);
        Assert.Equal(5, atributos.Defensa);
        Assert.Equal(7, atributos.Velocidad);
        Assert.Equal(25, atributos.ProbabilidadCritico);
        Assert.Equal(15, atributos.Evasion);
        Assert.Equal(80, atributos.Precision);
    }

    [Fact]
    public void Fuerza_Negativa_Lanza_Excepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Atributos(-1, 0, 0, 0, 0, 0));
    }

    [Fact]
    public void ProbabilidadCritico_MayorA100_Lanza_Excepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Atributos(1, 1, 1, 101, 0, 0));
    }
}
