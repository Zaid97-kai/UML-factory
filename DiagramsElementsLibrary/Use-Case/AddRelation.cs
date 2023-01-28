﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

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
    /// Draws this instance.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="panel">The panel.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    /// <returns>StackPanel.</returns>
    public Panel Draw(IElement element, Panel panel, int numberOfElements)
    {
        var canvas = new Canvas();
        panel.Children.Add(canvas);
        #region Line
        var relation = new Line();
        relation.X1 = panel.ActualWidth / 20 + (W * 3) / 2;
        relation.Y1 = 0-(panel.ActualHeight * element.Id / 2 / numberOfElements + 2 * H);
        relation.X2 = panel.ActualWidth / 3;
        relation.Y2 = panel.ActualHeight * element.Id / numberOfElements;
        relation.Stroke = Brushes.Black;
        canvas.Children.Add(relation);
        var count = canvas.Children.Count;
      
        #endregion
        return canvas;
    }
}