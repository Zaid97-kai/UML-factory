namespace Commands.Use_Case;

/// <summary>
/// Class Diagram.
/// </summary>
public class Diagram
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the elements.
    /// </summary>
    /// <value>The elements.</value>
    public List<IElement?>? Elements { get; set; }
}
