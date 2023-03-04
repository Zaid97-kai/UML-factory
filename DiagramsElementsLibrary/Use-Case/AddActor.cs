using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

namespace DiagramsElementsLibrary.Use_Case;

/// <summary>
/// Class AddActor.
/// Implements the <see cref="DiagramsElementsLibrary.IFigure" />
/// </summary>
/// <seealso cref="DiagramsElementsLibrary.IFigure" />
public class AddActor : IFigure
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
    public double W { get; set; } = 30;

    /// <summary>
    /// Gets or sets the h.
    /// </summary>
    /// <value>The h.</value>
    public double H { get; set; } = 30;

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
    /// Gets or sets the count.
    /// </summary>
    /// <value>The count.</value>
    public static int Count { get; set; }

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
        SizeAdaptation(panel, numberOfElements);

        if (panel.Children.Count == 0)
        {
            if (Canvas != null) panel.Children.Add(Canvas);
        }

        if (Canvas == null) return;

        #region Circle

        var ellipse = new Ellipse()
        {
            Width = W,
            Height = H,
            Stroke = Brushes.Black
        };

        Canvas.Children.Add(ellipse);

        Count = Canvas.Children.Count;
        Canvas.SetLeft(Canvas.Children[Count - 1], panel.ActualWidth / 10);
        
        if (numberOfElements == 0)
        {
            Canvas.SetTop(Canvas.Children[Count - 1], panel.ActualHeight * element.Id);
        }
        else
        {
            Canvas.SetTop(Canvas.Children[Count - 1], panel.ActualHeight * element.Id / numberOfElements);
        }


        #endregion

        #region Triangle

        var triangle = new Polygon
        {
            Points = new PointCollection
            {
                new Point(panel.ActualWidth / 10 - W / 2,
                    panel.ActualHeight * element.Id / numberOfElements + 2 * H),
                new Point(panel.ActualWidth / 10 + W / 2, panel.ActualHeight * element.Id / numberOfElements + H),
                new Point(panel.ActualWidth / 10 + (W * 3) / 2,
                    panel.ActualHeight * element.Id / numberOfElements + 2 * H)
            },
            Stroke = Brushes.Black
        };

        Canvas.Children.Add(triangle);
        element.X = panel.ActualWidth / 10 + ellipse.Width / 2 - (triangle.Points[2].X + triangle.Points[0].X) / 2;
        element.Y = panel.ActualHeight * element.Id / numberOfElements;

        Count = Canvas.Children.Count;
        Canvas.SetLeft(Canvas.Children[Count - 1], element.X);
        Canvas.SetTop(Canvas.Children[Count - 1], 0);

        element.X = triangle.Points[1].X;
        element.Y = triangle.Points[1].Y;

        #endregion

        #region TextBlock

        var textBlock = new TextBlock()
        {
            Name = "textBlock" + element.Id,
            Text = element.Name,
            TextAlignment = TextAlignment.Center,
            Width = W + W / 2,
            Height = H,
            FontSize = ActualFontSize
        };
        Canvas.Children.Add(textBlock);

        Count = Canvas.Children.Count;
        Canvas.SetLeft(Canvas.Children[Count - 1],
            panel.ActualWidth / 10 + ellipse.Width / 2 - textBlock.Width / 2);

        if (numberOfElements == 0)
        {
            Canvas.SetTop(Canvas.Children[Count - 1],
                panel.ActualHeight * element.Id + ellipse.Height * 2.5 - textBlock.Height / 2);
        }
        else
        {
            Canvas.SetTop(Canvas.Children[Count - 1],
                panel.ActualHeight * element.Id / numberOfElements + ellipse.Height * 2.5 - textBlock.Height / 2);
        }

        #endregion
    }

    /// <summary>
    /// Sizes the adaptation.
    /// </summary>
    /// <param name="panel">The panel.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    private void SizeAdaptation(FrameworkElement panel, int numberOfElements)
    {
        while (numberOfElements > (Convert.ToInt32(panel.ActualHeight / H/3)))
        {
            this.W *= 0.75;
            this.H *= 0.75;
            this.ActualFontSize *= 0.75;
            this.ActualOffset *= 0.95;
        }
    }
}