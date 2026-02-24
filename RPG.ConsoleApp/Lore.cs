using RPG.Core;

namespace RPG.ConsoleApp;

public class Lore
{
    public static void ContarRonda(int ronda, Heroe heroe)
    {
        Console.Clear();
        var velocidad = 25;
        string[] partes = ObtenerLore(ronda, heroe);

        foreach (string frase in partes)
        {
            EscribirLento(frase, velocidad);
            Console.WriteLine(); 
            Thread.Sleep(500); 
        }
    }

    private static string[] ObtenerLore(int ronda, Heroe heroe)
    {
        return ronda switch
        {
            1 => new[]
            {
                $"El crepúsculo cae como una manta pesada sobre el valle. {heroe.Nombre} avanza sin hacer ruido.\n",
                "El aire huele a ceniza vieja, como si alguien hubiese quemado algo sagrado hace mucho tiempo.\n",
                "Entre los árboles se escuchan crujidos… no de ramas, sino de pasos que intentan imitar los tuyos.\n"
            },
            2 => new[]
            {
                "Las ruinas aparecen de golpe, rotas y cubiertas de musgo. Las piedras están marcadas con símbolos antiguos.\n",
                "Hay sangre seca en el suelo. No es reciente, pero tampoco es de hace años.\n",
                "En el centro, un círculo de roca parece un altar… y el silencio ahí dentro es antinatural.\n"
            },
            3 => new[]
            {
                "Un pasillo subterráneo te traga. La antorcha parpadea como si no quisiera iluminar lo que hay delante.\n",
                "Al fondo, un sello tallado con runas late lentamente, como un corazón dormido.\n",
                "Sientes que, si lo rompes, algo cambiará para siempre… y no estás seguro de que sea buena idea.\n"
            },
            4 => new[]
            {
                "La niebla se vuelve espesa. Cada respiración pesa. La sensación de estar solo desaparece.\n",
                "Algo enorme se mueve cerca. No lo ves… pero lo oyes.\n",
                "La tierra vibra bajo tus pies. Este lugar está despertando.\n"
            },
            5 => new[]
            {
                "El camino se estrecha y el cielo se vuelve gris. No es una nube: es una sombra.\n",
                "Notas un calor extraño, como si el aire se estuviera quebrando.\n",
                "Sabes que hay un final esperando… y que no será justo.\n"
            },
            6 => new[]
            {
                "El mundo parece detenerse. No hay pájaros. No hay viento. No hay nada… excepto esa presencia.\n",
                "La oscuridad se abre como una puerta y el jefe final se manifiesta ante ti.\n",
                "Tu cuerpo reacciona antes que tu mente: este combate no es por gloria… es por sobrevivir.\n"
            },
            _ => new[] { "El destino avanza.\n" }
        };
    }
    static void EscribirLento(string texto, int velocidad)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(velocidad);
        }
    }
}