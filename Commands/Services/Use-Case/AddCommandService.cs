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
    /// <param name="diagram">Диаграмма.</param>
    /// <returns>Найденная команда.</returns>
    public static IElement? AddCommandAction(string command, Diagram diagram)
    {
        var pair = command.Split(' ');

        if(pair.FirstOrDefault() == "Граница")
            AddSystemBoundaryService.AddSystemBoundaryAction(pair, diagram);

        return GetNewElementService.GetNewElementAction(pair);
    }
}