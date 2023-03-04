namespace Commands.Use_Case;

/// <summary>
/// Class Counter.
/// </summary>
public static class Counter
{
    /// <summary>
    /// The count actors
    /// </summary>
    public static int CountActors = 0;

    /// <summary>
    /// The count precedents
    /// </summary>
    public static int CountPrecedents = 0;

    /// <summary>
    /// The count relations
    /// </summary>
    public static int CountRelations = 0;

    /// <summary>
    /// The count system boundary
    /// </summary>
    public static int CountSystemBoundary = 0;

    /// <summary>
    /// Resets this instance.
    /// </summary>
    public static void Reset()
    {
        CountActors = 0;
        CountPrecedents = 0;
        CountRelations = 0;
        CountSystemBoundary = 0;
    }
}