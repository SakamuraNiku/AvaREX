namespace ReactiveCore.Navigation;

/// <summary>
/// Represents View that supports Routing and Binding.
/// </summary>
/// <typeparam name="T">View`s ViewModel type.</typeparam>
public class ReactiveView<T> : ReactiveUserControl<T>, IReactiveView<T>
    where T : class, IReactiveViewModel
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ReactiveView{T}"/> class.
    /// </summary>
    public ReactiveView()
    {
        // TODO: find ViewModel

        this.WhenActivated(OnViewActivated);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Executes View`s activation tasks.
    /// </summary>
    /// <param name="disposables">Set of disposables.</param>
    protected virtual void OnViewActivated(CompositeDisposable disposables) =>
        this.Log().Info("View is activated");

    #endregion
}
