using Commands.Use_Case;

namespace Commands.Services.Use_Case;

/// <summary>
/// Class AddCommand.
/// </summary>
public class AddCommandService
{
    /// <summary>
    /// Добавление команды (прецедента или актора).
    /// </summary>
    /// <param name="command">Строка команды.</param>
    /// <returns>Найденная команда.</returns>
    public static IElement? AddCommandAction(string command, Diagram diagram = null)
    {
        var pair = command.Split(' ');
        return GetNewElementService.GetNewElementAction(pair, diagram);
    }
}