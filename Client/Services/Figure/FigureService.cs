using System;
using Commands.Use_Case;
using DiagramsElementsLibrary.Use_Case;
using System.Windows.Controls;
using Commands.Use_Case.Elements;

namespace Client.Services.Figure;

/// <summary>
/// Interface IFigureService
/// </summary>
public interface IFigureService
{
    /// <summary>
    /// Draws the shapes.
    /// </summary>
    /// <param name="diagram">The diagram.</param>
    /// <param name="imgDiagram">The img diagram.</param>
    void DrawShapes(Diagram? diagram, Panel imgDiagram);
}

/// <summary>
/// Class FigureService.
/// </summary>
public class FigureService : IFigureService
{
    /// <summary>
    /// Draws the shapes.
    /// </summary>
    /// <param name="diagram">The diagram.</param>
    /// <param name="imgDiagram">The img diagram.</param>
    public void DrawShapes(Diagram? diagram, Panel imgDiagram)
    {
        if (diagram?.Elements == null) 
            return;

        foreach (var element in diagram.Elements)
        {
            if (element != null)
            {
                if (element?.GetType() == typeof(Precedent))
                {
                    (new AddPrecedent()).Draw(element, imgDiagram, diagram, diagram.Elements.Count, new SystemBoundary());
                }
                else if (element?.GetType() == typeof(Actor))
                {
                    (new AddActor()).Draw(element, imgDiagram, diagram, 0);
                }
                else if (element?.GetType() == typeof(Relation))
                {
                    (new AddRelation()).Draw(element, imgDiagram, diagram, 0);
                }
            }
            else if(element == null)
            {
                continue;
            }
        }
    }
}