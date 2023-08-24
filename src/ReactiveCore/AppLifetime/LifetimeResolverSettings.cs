namespace Avalonia.Controls.ApplicationLifetimes;

/// <summary>
/// Represents set of Lifetime resolver settings.
/// </summary>
public class LifetimeResolverSettings
{
    #region Auto Properties

    /// <summary>
    /// Gets indication of whether or not resolver should throw an exception if no Application was found.
    /// </summary>
    public bool ThrowIfAppIsNull { get; init; } = true;

    /// <summary>
    /// Gets indication of whether or not resolver should throw an exception if no Lifetime was found.
    /// </summary>
    public bool ThrowIfLifetimeIsNull { get; init; } = true;

    /// <summary>
    /// Gets default Lifetime resolver settings.
    /// </summary>
    public static LifetimeResolverSettings Default => new();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="LifetimeResolverSettings"/> class.
    /// </summary>
    public LifetimeResolverSettings() { }

    #endregion
}
