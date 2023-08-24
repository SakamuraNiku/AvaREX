namespace ReactiveCore.Navigation;

/// <summary>
/// Represents base for all ViewModels.
/// </summary>
/// <remarks>Do not inherit this interface. Use one of the ReactiveViewModels instead.</remarks>
[DataContract]
public class ViewModel : ReactiveObject, IViewModel
{
    #region Auto Properties

    [Reactive]
    [DataMember]
    public string Title { get; set; } = string.Empty;

    [Reactive]
    [DataMember]
    public object? DataContext { get; set; }

    [IgnoreDataMember]
    public Type? DataType => DataContext?.GetType();

    [Reactive]
    [IgnoreDataMember]
    public bool IsBusy { get; protected set; }

    [IgnoreDataMember]
    public ViewModelActivator Activator { get; } = new();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ViewModel"/> class.
    /// </summary>
    public ViewModel() => this.WhenActivated(OnViewModelActivated);

    #endregion

    #region Private Methods

    /// <summary>
    /// Executes ViewModel`s activation tasks.
    /// </summary>
    /// <param name="disposables">Set of disposables.</param>
    protected virtual void OnViewModelActivated(CompositeDisposable disposables) =>
        this.Log().Info("ViewModel is activated");

    #endregion
}

/// <summary>
/// Represents base class for all ViewModels.
/// </summary>
/// <typeparam name="T">ViewModels data type.</typeparam>
/// <remarks>Do not inherit this interface. Use one of the ReactiveViewModels instead.</remarks>
[DataContract]
public class ViewModel<T> : ViewModel, IViewModel<T> where T : class
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
    /// Initializes a new instance of <see cref="ViewModel{T}"/> class.
    /// </summary>
    public ViewModel() { }

    #endregion
}
