using Commands.Use_Case;
using System.Xml.XPath;

namespace Commands.Services.Use_Case;

/// <summary>
/// Class GetNewElement.
/// </summary>
public class GetNewElementService
{
    /// <summary>
    /// Поиск элемента.
    /// </summary>
    /// <param name="pair">Пара значений из команды.</param>
    /// <returns>Найденный элемент.</returns>
    public static IElement? GetNewElementAction(string[]? pair, Diagram diagram = null)
    {
        switch (pair?[0])
        {
            case "Прецедент":
                Precedent.Count++;
                break;
            case "Актор":
                Actor.Count++;
                break;
            case "Граница":

            default:
                break;

        }

        IElement? newElementAction = (pair?[0] == "Актор" ? new Actor() { Name = pair[1] } :
            pair?[0] == "Прецедент" ? new Precedent() {Id = 0, Name = pair[1] } : pair[0]=="Граница" ? new SystemBoundary() 
            { Id=0, Name = pair[1], X = (diagram.Elements.Find(e => e.Name == pair[2])).X, Y = 0, H = 720, W = (diagram.Elements.Find(e => e.Name == pair[3]) as Precedent).W  } : null);

        return newElementAction;
    }
}