namespace RPG.ConsoleApp;

public static class EntradaTeclado
{
    private static void SalirPorEntradaNoInteractiva()
    {
        Console.Error.WriteLine("X Error: No hay entrada interactiva (EOF). Ejecuta el contenedor con -it.");
        Environment.Exit(0);
        throw new InvalidOperationException("Salida por EOF.");
    }

    public static int? LeerEntero(string mensaje, bool ok)
    {
        int numero = 0;
        do
        {
            Console.Write(mensaje);
            string? texto = Console.ReadLine();

            if (texto is null)
            {
                SalirPorEntradaNoInteractiva();
            }
            else if (string.IsNullOrWhiteSpace(texto))
            {
                Error("no se puede dejar vacio");
                ok = false;
            }
            else
            {
                if (int.TryParse(texto, out numero))
                {
                    if (numero < 0)
                    {
                        Error("el numero no puede ser menos a cero");
                        ok = false;
                    }
                    else
                    {
                        ok = true;
                    }
                }
                else
                {
                    Error("no es un numero");
                    ok = false;
                }
            }
        } while (!ok);
        return numero;
    }
    
    public static int LeerOpcion(string mensaje, int min, int max)
    {
        int numero = 0;
        bool ok = false;

        do
        {
            Console.Write(mensaje);
            string? texto = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(texto))
            {
                Error("No se puede dejar vacío.");
                ok = false;
            }
            else if (!int.TryParse(texto, out numero))
            {
                Error("No es un número válido.");
                ok = false;
            }
            else if (numero < min || numero > max)
            {
                Error($"El número debe estar entre {min} y {max}.");
                ok = false;
            }
            else
            {
                ok = true;
            }

        } while (!ok);

        return numero;
    }
    
    
    public static void Pausa(string mensaje)
    {
        if (Console.IsInputRedirected)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine(mensaje);
        Console.ReadKey(true);
    }
    
    public static void Error(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine("X Error: " + mensaje);
        Console.ResetColor();
    }
}
