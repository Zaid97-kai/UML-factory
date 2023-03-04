using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;
using Commands.Use_Case.Elements;

namespace DiagramsElementsLibrary.Use_Case;

/// <summary>
/// Class AddRelation.
/// Implements the <see cref="DiagramsElementsLibrary.IFigure" />
/// </summary>
/// <seealso cref="DiagramsElementsLibrary.IFigure" />
public class AddRelation : IFigure
{
    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    /// <value>The x.</value>
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    /// <value>The y.</value>
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    /// <value>The w.</value>
    public double W { get; set; }

    /// <summary>
    /// Gets or sets the h.
    /// </summary>
    /// <value>The h.</value>
    public double H { get; set; }

    /// <summary>
    /// Gets or sets the actual size of the font.
    /// </summary>
    /// <value>The actual size of the font.</value>
    public double ActualFontSize { get; set; } = 12;

    /// <summary>
    /// Gets or sets the actual offset.
    /// </summary>
    /// <value>The actual offset.</value>
    public double ActualOffset { get; set; } = 20;

    /// <summary>
    /// The canvas
    /// </summary>
    public static Canvas? Canvas = new();

    /// <summary>
    /// Draws this instance.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="panel">The panel.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    /// <returns>StackPanel.</returns>
    public void Draw(IElement element, Panel panel, Diagram diagram, int numberOfElements)
    {
        var line = new Line()
        {
            X1 = ((element as Relation)!).LinkActor!.X,
            X2 = ((element as Relation)!).LinkPrecedent!.X,
            Y1 = ((element as Relation)!).LinkActor!.Y,
            Y2 = ((element as Relation)!).LinkPrecedent!.Y,
            Stroke = Brushes.Black
        };

        AddActor.Canvas?.Children.Add(line);
    }
}