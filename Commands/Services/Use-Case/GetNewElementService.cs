using Commands.Use_Case;
using Commands.Use_Case.Elements;

namespace Commands.Services.Use_Case;

/// <summary>
/// Class GetNewElement.
/// </summary>
public class GetNewElementService
{
    /// <summary>
    /// The new element action
    /// </summary>
    private static IElement? _newElementAction;

    /// <summary>
    /// Поиск элемента.
    /// </summary>
    /// <param name="pair">Пара значений из команды.</param>
    /// <returns>Найденный элемент.</returns>
    public static IElement? GetNewElementAction(string[]? pair)
    {
        switch (pair?[0])
        {
            case "Прецедент":
                Counter.CountPrecedents++;
                break;
            case "Актор":
                Counter.CountActors++;
                break;
            default:
                break;
        }

        _newElementAction = (pair?[0] == "Актор" ? new Actor() { Name = pair[1] } :
            pair?[0] == "Прецедент" ? new Precedent() { Name = pair[1] } : null);

        return _newElementAction;
    }
}