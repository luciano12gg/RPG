using RPG.Core;

namespace RPG.ConsoleApp;

public class GestorRondas
{
    private bool _ocultoDesbloqueado;

    public GestorRondas(bool ocultoDesbloqueado)
    {
        _ocultoDesbloqueado = ocultoDesbloqueado;
    }

    public bool OcultoDesbloqueado => _ocultoDesbloqueado;

    public void EjecutarRun(Heroe heroe)
    {
        var combate = new Combate();
        var tal = new CombateMenu();

        int ronda = 1;

        do
        {
            Lore.ContarRonda(ronda, heroe);

            Monstruo enemigo = ElegirEnemigo(ronda);

            Console.WriteLine($"Ronda {ronda}: aparece {enemigo.Nombre}");
            EntradaTeclado.Pausa("Pulsa una tecla para empezar el combate...");

            ResultadoCombate resultado;
            do
            {
                resultado = tal.JugarCombate(heroe, enemigo, combate);

                if (resultado == ResultadoCombate.Derrota)
                {
                    Console.WriteLine("\nHas muerto. Fin de la run.");
                    EntradaTeclado.Pausa("");
                    return;
                }

                if (resultado == ResultadoCombate.Huida)
                {
                    Console.Clear();
                    Console.WriteLine("Has escapado del combate.\n");
                    Console.WriteLine("1) Volver al combate");
                    Console.WriteLine("2) Volver al inicio");

                    int opcionHuida = EntradaTeclado.LeerOpcion("Opcion: ", 1, 2);
                    if (opcionHuida == 2)
                        return;
                }
            } while (resultado == ResultadoCombate.Huida);

            if (ronda == 3 && !_ocultoDesbloqueado)
            {
                Console.Clear();
                Console.WriteLine("Has encontrado una sala sellada.\n");
                Console.WriteLine("1) Seguir peleando");
                Console.WriteLine("2) Romper el sello y desbloquear al héroe oculto");

                int op = EntradaTeclado.LeerOpcion("Opcion: ",1, 2);

                switch (op)
                {
                    case 1:
                        break;

                    case 2:
                        _ocultoDesbloqueado = true;
                        Console.WriteLine("\nEl sello se rompe. Un nuevo héroe aparece en la selección.");
                        EntradaTeclado.Pausa("Pulsa una tecla para volver a la selección...");
                        return;
                }
            }

            if (ronda == 6)
            {
                Console.Clear();
                Console.WriteLine("¡Has derrotado al JEFE FINAL! Fin de la aventura.");
                EntradaTeclado.Pausa("");
                return;
            }

            ronda++;

        } while (ronda <= 6);
    }

    private Monstruo ElegirEnemigo(int ronda)
    {
        if (ronda == 6)
            return Central.Monstruos[Central.Monstruos.Length - 1]; 

        int max = Central.Monstruos.Length - 1; 
        int idx = Random.Shared.Next(0, max);
        return Central.Monstruos[idx];
    }
}
