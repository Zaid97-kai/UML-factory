namespace Commands.Use_Case.Elements;

/// <summary>
/// Class LinkActor.
/// Implements the <see cref="Commands.Use_Case.IElement" />
/// </summary>
public class Actor : IElement
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string TypeElement => typeof(Actor).ToString();

    public List<Precedent> Precedents { get; set; }

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

    public double Offset { get; set; }

    /// <summary>
    /// Gets or sets the link actor.
    /// </summary>
    /// <value>The link actor.</value>
    public Actor LinkActor { get; set; }

    /// <summary>
    /// Gets or sets the link precedent.
    /// </summary>
    /// <value>The link precedent.</value>
    public Precedent LinkPrecedent { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Commands.Use_Case.LinkActor" /> class.
    /// </summary>
    public Actor()
    {
        Id = Counter.CountActors - 1;
    }
}
