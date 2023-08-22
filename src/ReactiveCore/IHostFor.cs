namespace ReactiveCore;

/// <summary>
/// Represents the base definition of Host that displays HostViews.
/// </summary>
public interface IHostFor
{
    /// <summary>
    /// Gets Currently displayed HostView.
    /// </summary>
    IReactiveHostView HostView { get; }
}

/// <summary>
/// Represents the base definition of Host that displays HostView.
/// </summary>
/// <typeparam name="T">HostView type.</typeparam>
public interface IHostFor<T> : IHostFor where T : class, IReactiveHostView { }
