namespace ReactiveCore.Navigation;

/// <summary>
/// Represents HostView`s ViewModel.
/// </summary>
[DataContract]
public class ReactiveHostViewModel : ViewModel, IReactiveHostViewModel
{
    #region Auto Properties

    [Reactive]
    [DataMember]
    public RoutingState Router { get; set; } = new();

    [IgnoreDataMember]
    public string? UrlPathSegment => this.GetUrlSegment();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ReactiveHostViewModel"/> class.
    /// </summary>
    public ReactiveHostViewModel() { }

    #endregion
}

/// <summary>
/// Represents HostView`s ViewModel.
/// </summary>
/// <typeparam name="T">ViewModel`s data type.</typeparam>
[DataContract]
public class ReactiveHostViewModel<T> : ReactiveHostViewModel, IReactiveHostViewModel<T> where T : class
{
    #region Auto Properties

    [Reactive]
    [DataMember]
    public new T? DataContext { get; set; }

    object? IViewModel.DataContext
    {
        get => this.DataContext;
        set => this.DataContext = (T?)value;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ReactiveHostViewModel{T}"/> class.
    /// </summary>
    public ReactiveHostViewModel() { }

    #endregion
}
