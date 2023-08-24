namespace Avalonia.Controls.ApplicationLifetimes;

/// <summary>
/// Represents AvaloniaUI application Lifetime resolver.
/// </summary>
public class LifetimeResolver
{
    #region Public Methods

    public static LifetimeType ResolveLifetime(bool throwIfNone = true)
    {
        var app = Application.Current ?? 
            throw new ApplicationException(
                "There was no Application");

        var lifetime = app.ApplicationLifetime;

        if (lifetime is IClassicDesktopStyleApplicationLifetime)
            return LifetimeType.Classic;

        if (lifetime is IControlledApplicationLifetime)
            return LifetimeType.Controlled;

        if (lifetime is ISingleViewApplicationLifetime)
            return LifetimeType.SingleView;

        return throwIfNone ?
            throw new ApplicationException("There was no lifetime") : LifetimeType.None;
    }

    #endregion
}
