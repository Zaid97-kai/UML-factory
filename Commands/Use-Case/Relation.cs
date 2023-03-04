namespace Commands.Use_Case;

/// <summary>
/// Class Relation.
/// Implements the <see cref="Commands.Use_Case.IElement" />
/// </summary>
/// <seealso cref="Commands.Use_Case.IElement" />
public class Relation : IElement
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
    public string TypeElement => typeof(Relation).ToString();

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

    /// <summary>
    /// Gets or sets the actor.
    /// </summary>
    /// <value>The actor.</value>
    public Actor? LinkActor { get; set; }

    /// <summary>
    /// Gets or sets the precedent.
    /// </summary>
    /// <value>The precedent.</value>
    public Precedent? LinkPrecedent { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Relation" /> class.
    /// </summary>
    public Relation()
    {
        Id = Counter.CountRelations - 1;
    }
}
