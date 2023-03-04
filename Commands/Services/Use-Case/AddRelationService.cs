using Commands.Use_Case;
using Commands.Use_Case.Elements;

namespace Commands.Services.Use_Case;

/// <summary>
/// Class AddRelation.
/// </summary>
public class AddRelationService
{
    /// <summary>
    /// Добавление связи.
    /// </summary>
    /// <param name="command">Текст команды.</param>
    /// <param name="diagram">Диаграмма.</param>
    /// <returns>Relation.</returns>
    public static Relation AddRelationAction(string command, Diagram? diagram)
    {
        var pair = command.Split('+');
        var newElement = new Relation()
        {
            Id = 0,
            Name = (diagram?.Elements?.Find(e => e?.Name == pair[0]) as Actor)?.Name + "+" + (diagram?.Elements?.Find(e => e?.Name == pair[1]) as Precedent)?.Name,
            LinkActor = diagram?.Elements?.Find(e => e?.Name == pair[0]) as Actor,
            LinkPrecedent = diagram?.Elements?.Find(e => e?.Name == pair[1]) as Precedent
        };

        Counter.CountRelations++;

        return newElement;
    }
}