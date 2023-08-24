namespace ReactiveCore.Navigation;

/// <summary>
/// Represents ViewModel that can be navigated to.
/// </summary>
[DataContract]
public class ReactiveViewModel : ViewModel, IReactiveViewModel
{
    #region Auto Properties

    [IgnoreDataMember]
    public string? UrlPathSegment => this.GetUrlSegment();

    [IgnoreDataMember]
    public IScreen HostScreen { get; } = null!;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ReactiveViewModel"/> class.
    /// </summary>
    public ReactiveViewModel()
    {
        // TODO: find HostScreen.
    }

    #endregion
}

/// <summary>
/// Represents ViewModel that can be navigated to.
/// </summary>
/// <typeparam name="T">ViewModel`s data type.</typeparam>
[DataContract]
public class ReactiveViewModel<T> : ReactiveViewModel, IReactiveViewModel<T> where T : class
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
    /// Initializes a new instance of <see cref="ReactiveViewModel{T}"/> class.
    /// </summary>
    public ReactiveViewModel() { }

    #endregion
}
