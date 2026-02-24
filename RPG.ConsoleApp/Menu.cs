using RPG.Core;

namespace RPG.ConsoleApp;

public class Menu
{
    private bool _ocultoDesbloqueado;

    public Menu()
    {
        _ocultoDesbloqueado = false;
    }

    public void Usar()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=== RPG ===\n");
            Console.WriteLine("1) Jugar");
            Console.WriteLine("2) Salir");

            opcion = EntradaTeclado.LeerOpcion("Opcion: ",1, 2);

            switch (opcion)
            {
                case 1:
                {
                   
                    int indiceOculto = Central.Heroes.Length - 1;

                 
                    var selector = new SelectorHeroe(_ocultoDesbloqueado, indiceOculto);
                    Heroe? heroe = selector.ElegirHeroe();

                    
                    if (heroe == null)
                        break;

                   
                    var rondas = new GestorRondas(_ocultoDesbloqueado);
                    rondas.EjecutarRun(heroe);

                  
                    _ocultoDesbloqueado = rondas.OcultoDesbloqueado;

                    Console.Clear();
                    Console.WriteLine("Has vuelto al menú principal.");
                    EntradaTeclado.Pausa("");
                    break;
                }

                case 2:
                    Console.WriteLine("\nSaliendo...");
                    return;
            }

        } while (true);
    }
}