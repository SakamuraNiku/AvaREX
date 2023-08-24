namespace ReactiveCore.Navigation;

/// <summary>
/// Represents Host that can display multiple HostViews.
/// </summary>
/// <remarks>Used on mobile platforms or SingleWindow MultipleHostViews desktop apps.</remarks>
public class MasterView : UserControl, IHostFor
{
    #region Auto Properties

    public IReactiveHostView? HostView { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="MasterView"/> class.
    /// </summary>
    public MasterView() { }

    #endregion
}

/// <summary>
/// Represents Host that shows specific HostView.
/// </summary>
/// <typeparam name="T">HostView type.</typeparam>
public class WindowView<T> : Window, IHostFor<T> where T : class, IReactiveHostView
{
    #region Auto Properties

    public IReactiveHostView? HostView { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="WindowView{T}"/> class.
    /// </summary>
    public WindowView() { }

    #endregion
}
