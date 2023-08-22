namespace ReactiveCore.Navigation;

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

    public ReactiveViewModel(IScreen? hostScreen = null)
    {

    }

    #endregion
}

[DataContract]
public class ReactiveViewModel<T> : ReactiveViewModel, IReactiveViewModel<T> where T : class
{
    #region Auto Properties

    [DataMember]
    public new T? DataContext
    {
        get => _dataContext;
        set => this.RaiseAndSetIfChanged(ref _dataContext, value);
    }

    object? IViewModel.DataContext
    {
        get => this.DataContext;
        set => this.DataContext = (T?)value;
    }

    #endregion

    #region Private Fields

    private T? _dataContext = null;

    #endregion

    #region Constructors

    public ReactiveViewModel() { }

    #endregion
}
