using RPG.Core;

namespace RPG.ConsoleApp;

public class SelectorHeroe
{
    private readonly bool _ocultoDesbloqueado;
    private readonly int _indiceOculto;

    public SelectorHeroe(bool ocultoDesbloqueado, int indiceOculto)
    {
        _ocultoDesbloqueado = ocultoDesbloqueado;
        _indiceOculto = indiceOculto;
    }

    public Heroe? ElegirHeroe()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Selección de héroe ===\n");

            for (int i = 0; i < Central.Heroes.Length; i++)
            {
                bool esOculto = (i == _indiceOculto);

                if (esOculto && !_ocultoDesbloqueado)
                    Console.WriteLine($"{i + 1}) ??? (bloqueado)");
                else
                    Console.WriteLine($"{i + 1}) {Central.Heroes[i].Nombre}|| Vida [{Central.Heroes[i].VidaMaxima}] ({Central.Heroes[i].TipoElemento})\n atributos:   DMG: [{Central.Heroes[i].Atributos.Fuerza}] DEF: [{Central.Heroes[i].Atributos.Defensa}]      VEL: [{Central.Heroes[i].Atributos.Velocidad}]   P.CRIT: [{Central.Heroes[i].Atributos.ProbabilidadCritico}]    EVA: [{Central.Heroes[i].Atributos.Evasion}]  PREC: [{Central.Heroes[i].Atributos.Precision}]");
            }

            Console.WriteLine("\n0) Volver");
            opcion = EntradaTeclado.LeerOpcion("Opcion: ",0, Central.Heroes.Length);

            if (opcion == 0) return null;

            int indicador = opcion - 1;

            if (indicador == _indiceOculto && !_ocultoDesbloqueado)
            {
                Console.WriteLine("\nEse héroe está bloqueado. Se desbloquea tras la ronda 3.");
                EntradaTeclado.Pausa("Presione una tecla para continuar");
            }
            else
            {
                return Central.Heroes[indicador];
            }

        } while (true);
    }
}