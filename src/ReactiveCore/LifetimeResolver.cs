namespace ReactiveCore;

public enum LifetimeType
{
    None,
    Classic,
    SingleView,
    Controlled,
}

public class LifetimeResolverSettings
{
    public bool ShouldThrowOnNullApp { get; init; } = true;
    public bool ShouldThrowOnNullLifetime { get; init; } = true;

    public static LifetimeResolverSettings Default => new();
}

public class LifetimeResolver
{
    #region Auto Properties

    public LifetimeResolverSettings Settings { get; }

    public Application Application { get; }

    public LifetimeType LifetimeType { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="LifetimeResolver"/> class with default settings.
    /// </summary>
    /// <exception cref="ApplicationException"></exception>
    public LifetimeResolver() : this(LifetimeResolverSettings.Default) { }

    /// <summary>
    /// Initializes a new instance of <see cref="LifetimeResolver"/> class with given settings.
    /// </summary>
    /// <param name="settings">LifetimeResolver settings.</param>
    /// <exception cref="ApplicationException"></exception>
    public LifetimeResolver(LifetimeResolverSettings settings)
    {
        Settings = settings;

        var app = Application.Current;
        if (settings.ShouldThrowOnNullApp && app == null)
            throw new ApplicationException(
                "There was no Application");

        Application  = app!;
        LifetimeType = GetLifetimeType();
    }

    #endregion

    #region Private Methods

    private LifetimeType GetLifetimeType()
    {
        var lifetime = Application.ApplicationLifetime;

        if (lifetime is IClassicDesktopStyleApplicationLifetime)
            return LifetimeType.Classic;

        if (lifetime is IControlledApplicationLifetime)
            return LifetimeType.Controlled;

        if (lifetime is ISingleViewApplicationLifetime)
            return LifetimeType.SingleView;

        if (Settings.ShouldThrowOnNullLifetime)
            throw new ApplicationException("There was no lifetime");

        return LifetimeType.None;
    }

    #endregion
}