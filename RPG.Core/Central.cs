using System.ComponentModel;

namespace RPG.Core;

public static class Central
{
    public static Heroe[] Heroes { get; }
    public static Monstruo[] Monstruos { get; }

    static Central()
    {
        Heroes = CrearHeroes();
        Monstruos = CrearMonstruos();
    }

    public static Heroe[] CrearHeroes()
    {
        var luchador = new Heroe("Luciano",190,new Atributos(50,40,20,50,10,50),TipoElemento.Fuego);
        luchador.AgregarArma(new Arma("Hacha Quebranta-Huesos", TipoElemento.Fuego,new Atributos(30,10,40,40),TipoAccion.Ataque));
        luchador.AgregarArma(new Arma("Espadazo Perforador", TipoElemento.Planta,new Atributos(20,50,60,60),TipoAccion.Ataque));
        luchador.AgregarArma(new Arma("Piel en llamas", TipoElemento.Fuego,new Atributos(20,60),TipoAccion.Defensa));


        var arquero = new Heroe("Jose", 100, new Atributos(60, 10, 70, 70, 50, 50), TipoElemento.Agua);
        arquero.AgregarArma(new Arma("daga helada",TipoElemento.Agua,new Atributos(15,70,60,60),TipoAccion.Ataque));
        arquero.AgregarArma(new Arma("hidro-bomba",TipoElemento.Agua,new Atributos(30,10,40,40),TipoAccion.Ataque));
        arquero.AgregarArma(new Arma("muro de escarcha",TipoElemento.Agua,new Atributos(10,50),TipoAccion.Defensa));

        var druida = new Heroe("Carlos", 130, new Atributos(20, 10, 20, 15, 20, 20), TipoElemento.Planta);
        druida.AgregarArma(new Arma("latigazo de hiedras",TipoElemento.Planta,new Atributos(25,70,40,100),TipoAccion.Ataque));
        druida.AgregarArma(new Arma("palo embrujado",TipoElemento.Planta,new Atributos(30,10,40,40),TipoAccion.Ataque));
        druida.AgregarArma(new Arma("muro de palitos",TipoElemento.Planta,new Atributos(5,80),TipoAccion.Defensa));


        var otto = new Heroe("Otto el grande", 999, new Atributos(999, 999, 999, 100, 100, 100), TipoElemento.Divino);
        otto.AgregarArma(new Arma("bucle infinito",TipoElemento.Divino,new Atributos(999,999,100,100),TipoAccion.Ataque));
        otto.AgregarArma((new Arma("un millon de lineas",TipoElemento.Divino,new Atributos(999,100),TipoAccion.Defensa)));
        otto.AgregarArma(new Arma("destructor de codigos",TipoElemento.Divino,new Atributos(999,999,100,100),TipoAccion.Ataque));
        
        return new Heroe[] { luchador, arquero, druida, otto};
    }

    public static Monstruo[] CrearMonstruos()
    {
        
        var perro = new Monstruo("sabueso infernal",190,new Atributos(50,40,20,50,10,30),TipoElemento.Fuego);
        perro.AgregarAtaque(new Arma("mordisco de laba", TipoElemento.Fuego,new Atributos(30,10,40,40),TipoAccion.Ataque));
        perro.AgregarAtaque(new Arma("escupitajo en llamas", TipoElemento.Fuego,new Atributos(20,50,60,60),TipoAccion.Ataque));
        perro.AgregarAtaque(new Arma("piel mutante", TipoElemento.Fuego,new Atributos(5,60),TipoAccion.Defensa));


        var leviatan = new Monstruo("serpiente de las profundidades", 100, new Atributos(60, 10, 70, 70, 50, 50), TipoElemento.Agua);
        leviatan.AgregarAtaque(new Arma("honda de agua",TipoElemento.Agua,new Atributos(15,70,60,60),TipoAccion.Ataque));
        leviatan.AgregarAtaque(new Arma("mordisco de hielo",TipoElemento.Agua,new Atributos(30,10,40,40),TipoAccion.Ataque));
        leviatan.AgregarAtaque(new Arma("escamas congeladas",TipoElemento.Agua,new Atributos(10,50),TipoAccion.Defensa));

        var arbol = new Monstruo("Arbol maldito", 130, new Atributos(20, 10, 20, 15, 20, 20), TipoElemento.Planta);
        arbol.AgregarAtaque(new Arma("tronco demoledor",TipoElemento.Planta,new Atributos(25,70,40,100),TipoAccion.Ataque));
        arbol.AgregarAtaque(new Arma("hojas asesinas",TipoElemento.Planta,new Atributos(30,10,40,40),TipoAccion.Ataque));
        arbol.AgregarAtaque(new Arma("madera ancestral",TipoElemento.Planta,new Atributos(5,80),TipoAccion.Defensa));


        var jefe = new Monstruo("Luzbel el arcangel caido", 999, new Atributos(80, 50, 1, 70, 10, 50), TipoElemento.Fuego);
        jefe.AgregarAtaque(new Arma("rugido de las profundidades",TipoElemento.Fuego,new Atributos(40,10,20,10),TipoAccion.Ataque));
        jefe.AgregarAtaque((new Arma("alma del mas alla",TipoElemento.Fuego,new Atributos(20,100),TipoAccion.Defensa)));
        jefe.AgregarAtaque(new Arma("devorador de almas",TipoElemento.Fuego,new Atributos(90,10,40,40),TipoAccion.Ataque));
        
        return new Monstruo[] {perro, leviatan, arbol, jefe};
    }
}