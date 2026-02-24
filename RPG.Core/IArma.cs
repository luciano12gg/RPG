namespace RPG.Core;


/// <summary>
/// esto nos servira como plantilla para crear distintos tipos de armas y si queremos aplicarle habilidades especiales
/// </summary>
public interface IArma
{
    string Nombre { get; }
    TipoElemento Tipo { get; }
    Atributos Atributos { get; }
    TipoAccion Accion { get; }
}