namespace ReactiveCore;

/// <summary>
/// Represents MasterView that can display multiple HostViews.
/// </summary>
public class MasterView : UserControl, IHostFor
{
    public IReactiveHostView HostView { get; } = null!;
}

/// <summary>
/// Represents WindowView that shows specific HostView.
/// </summary>
/// <typeparam name="T">HostView type.</typeparam>
public class WindowView<T> : Window, IHostFor<T> where T : class, IReactiveHostView
{
    public IReactiveHostView HostView { get; } = null!;
}
