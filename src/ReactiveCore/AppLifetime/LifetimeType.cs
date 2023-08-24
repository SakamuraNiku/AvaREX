namespace Avalonia.Controls.ApplicationLifetimes;

/// <summary>
/// Contains list of constants representing ApplicationLifetime types.
/// </summary>
public enum LifetimeType
{
    /// <summary>
    /// LifeTime was not set.
    /// </summary>
    None,

    /// <summary>
    /// IClassicDesktopStyleApplicationLifetime.
    /// </summary>
    Classic,

    /// <summary>
    /// ISingleViewApplicationLifetime.
    /// </summary>
    SingleView,

    /// <summary>
    /// IControlledApplicationLifetime.
    /// </summary>
    Controlled,
}
