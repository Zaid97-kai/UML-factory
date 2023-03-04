using Commands.Use_Case;
using Commands.Use_Case.Elements;

namespace Commands.Services.Use_Case;

public class AddSystemBoundaryService
{
    public static IElement? AddSystemBoundaryAction(string[] pair, Diagram diagram)
    {
        var subPair = pair[1].Split('(');

        var systemBoundaryName = subPair[0];

        subPair[1] = subPair[1].Remove(subPair[1].Length - 1);
        var subSubPair = subPair[1].Split(',');

        var newSystemBoundary = new SystemBoundary()
        {
            Id = 0,
            Name = subPair[0],
            Precedents = new()
        };

        foreach (var t in subSubPair)
        {
            newSystemBoundary.Precedents.Add(diagram.Elements?.Find(f => f?.Name == t) as Precedent);
        }
        
        Counter.CountSystemBoundary++;

        return newSystemBoundary;
    }
}