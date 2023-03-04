using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

namespace DiagramsElementsLibrary.Use_Case;

/// <summary>
/// Class AddSystemBoundary.
/// Implements the <see cref="DiagramsElementsLibrary.IFigure" />
/// </summary>
/// <seealso cref="DiagramsElementsLibrary.IFigure" />
public class AddSystemBoundary : IFigure
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
    /// Draws this instance.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="panel">The panel.</param>
    /// <param name="diagram">The diagram.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    /// <returns>StackPanel.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Draw(IElement element, Panel panel, Diagram diagram, int numberOfElements)
    {
        element.Offset = 20;
        
        #region Precedents

        foreach (var precedent in element.Precedents.Where(precedent => diagram.Elements != null))
        {
            (new AddPrecedent()).Draw(precedent, panel, diagram,
                diagram.Elements!.Count - Counter.CountActors - Counter.CountRelations -
                Counter.CountSystemBoundary);
        }

        #endregion

        #region SystemBoundary

        var canvas = new Canvas();
        panel.Children.Add(canvas);

        var rectangle = new Rectangle()
        {
            Height = element.Precedents[0].H * element.Precedents.Count + element.Precedents[0].Offset,
            Width = element.Precedents[0].W,
            Stroke = Brushes.Black
        };

        canvas.Children.Add(rectangle);

        Canvas.SetLeft(canvas.Children[0], element.Precedents[0].X);
        Canvas.SetTop(canvas.Children[0], element.Precedents[0].Y - element.Precedents[0].H / 2);

        #endregion
    }
}