namespace ReactiveCore.Navigation;

[DataContract]
public class ReactiveHostViewModel : ViewModel, IReactiveHostViewModel
{
    #region Auto Properties

    [DataMember]
    public RoutingState Router
    {
        get => _routerState;
        set => this.RaiseAndSetIfChanged(ref _routerState, value);
    }

    #endregion

    #region Private Fields

    private RoutingState _routerState = new();

    #endregion

    #region Constructors

    public ReactiveHostViewModel() { }

    #endregion
}

[DataContract]
public class ReactiveHostViewModel<T> : ReactiveHostViewModel, IReactiveHostViewModel<T> where T : class
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

    public ReactiveHostViewModel() { }

    #endregion
}
