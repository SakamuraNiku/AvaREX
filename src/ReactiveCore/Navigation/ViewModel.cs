namespace ReactiveCore.Navigation;

[DataContract]
public class ViewModel : ReactiveObject, IViewModel
{
    #region Auto Properties

    [DataMember]
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    [DataMember]
    public object? DataContext
    {
        get => _dataContext;
        set => this.RaiseAndSetIfChanged(ref _dataContext, value);
    }

    [IgnoreDataMember]
    public Type? DataType => DataContext?.GetType();

    [IgnoreDataMember]
    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    [IgnoreDataMember]
    public ViewModelActivator Activator { get; } = new();

    #endregion

    #region Private Fields

    private string _title = string.Empty;
    private object? _dataContext = null;
    private bool _isBusy = false;

    #endregion

    #region Constructors

    public ViewModel() =>
        this.WhenActivated(OnViewModelActivated);

    #endregion

    #region Private Methods

    protected virtual void OnViewModelActivated(CompositeDisposable disposables) =>
        this.Log().Info("ViewModel is activated");

    #endregion
}

[DataContract]
public class ViewModel<T> : ViewModel, IViewModel<T> where T : class
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

    public ViewModel() { }

    #endregion
}
