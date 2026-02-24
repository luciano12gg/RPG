using RPG.Core;
using System.Text;

namespace RPG.ConsoleApp;

public class CombateMenu
{
    private const int SegundosInactividadParaCura = 10;
    private const double PorcentajeCuracionInactividad = 0.10;

    public ResultadoCombate JugarCombate(Heroe heroe, Monstruo monstruo, Combate combate)
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine($"Heroe: {heroe.Nombre}  Vida {heroe.Vida}/{heroe.VidaMaxima}");
            Console.WriteLine($"Enemigo: {monstruo.Nombre}  Vida {monstruo.Vida}/{monstruo.VidaMaxima}\n");

            Console.WriteLine("1) Atacar");
            Console.WriteLine("2) Defender");
            Console.WriteLine("3) Huir");


            opcion = EntradaTeclado.LeerOpcion("Opcion: ", 1, 3);
            
            switch (opcion)
            {
                case 1:
                {
                    IArma armaAtaque = ElegirArmaPorAccion(heroe, TipoAccion.Ataque);

                    combate.Atacar(heroe, monstruo, armaAtaque, out _, out string mensaje);
                    Console.WriteLine("\n" + mensaje);
                    EntradaTeclado.Pausa("");
                    break;
                }

                case 2:
                {
                    IArma armaDefensa = ElegirArmaPorAccion(heroe, TipoAccion.Defensa);

                    int bonusDef = armaDefensa.Atributos.Defensa;
                    heroe.ActivarDefensaTemporal(bonusDef);

                    Console.WriteLine($"\n{heroe.Nombre} usa {armaDefensa.Nombre} y gana +{bonusDef} DEF este turno.");
                    EntradaTeclado.Pausa("");
                    break;
                }

                case 3:
                {
                    Console.WriteLine($"\n{heroe.Nombre} intenta huir...");
                    EntradaTeclado.Pausa("");

                    var ataque = monstruo.Ataque[Random.Shared.Next(0, monstruo.Ataque.Count)];
                    combate.Atacar(monstruo, heroe, ataque, out _, out string msg);
                    Console.WriteLine("\n" + msg);
                    EntradaTeclado.Pausa("");

                    return heroe.Vida > 0 ? ResultadoCombate.Huida : ResultadoCombate.Derrota;
                }
            }

            if (monstruo.Vida > 0)
            {
                var ataque = monstruo.Ataque[Random.Shared.Next(0, monstruo.Ataque.Count)];
                combate.Atacar(monstruo, heroe, ataque, out _, out string msg);
                Console.WriteLine("\n" + msg);
                EntradaTeclado.Pausa("");
            }

            heroe.ResetDefensaTemporal();

        } while (heroe.Vida > 0 && monstruo.Vida > 0);

        return heroe.Vida > 0 ? ResultadoCombate.Victoria : ResultadoCombate.Derrota;
    }

   

    private IArma ElegirArmaPorAccion(Heroe heroe, TipoAccion accion)
    {
        int cantidad = 0;
        for (int i = 0; i < heroe.Inventario.Count; i++)
        {
            if (heroe.Inventario[i].Accion == accion)
                cantidad++;
        }

        if (cantidad == 0)
        {
            Console.WriteLine("\nNo tienes habilidades de ese tipo.");
            EntradaTeclado.Pausa("");
            return heroe.Inventario[0];
        }

        int[] indicesReales = new int[cantidad];
        int pos = 0;

        Console.WriteLine();
        Console.WriteLine(accion == TipoAccion.Ataque
            ? "Elige habilidad de ATAQUE:"
            : "Elige habilidad de DEFENSA:");

        for (int i = 0; i < heroe.Inventario.Count; i++)
        {
            IArma arma = heroe.Inventario[i];
            if (arma.Accion == accion)
            {
                indicesReales[pos] = i;

                if (accion == TipoAccion.Ataque)
                    Console.WriteLine($"{pos + 1}) {arma.Nombre} ({arma.Tipo})  DMG:[{arma.Atributos.Fuerza}]   velocidad:[{arma.Atributos.Velocidad}]   P.CRT: [{arma.Atributos.ProbabilidadCritico}]   PREC: [{arma.Atributos.Precision}]");
                else
                    Console.WriteLine($"{pos + 1}) {arma.Nombre} ({arma.Tipo})  DEF:+{arma.Atributos.Defensa}   PREC: [{arma.Atributos.Precision}]");

                pos++;
            }
        }

        int opcion = EntradaTeclado.LeerOpcion("Opcion: ", 1, cantidad);
        int idxReal = indicesReales[opcion - 1];
        return heroe.Inventario[idxReal];
    }
}
