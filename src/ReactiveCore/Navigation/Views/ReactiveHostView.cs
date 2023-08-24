namespace ReactiveCore.Navigation;

/// <summary>
/// Represents HostView that shows navigation results.
/// </summary>
/// <typeparam name="T">HostView`s ViewModel type.</typeparam>
public class ReactiveHostView<T> : ReactiveUserControl<T>, IReactiveHostView<T>
    where T : class, IReactiveHostViewModel
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ReactiveHostView{T}"/> class.
    /// </summary>
    public ReactiveHostView()
    {
        // TODO: find ViewModel.

        this.WhenActivated(OnHostActivated);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Executes HostView`s activation tasks.
    /// </summary>
    /// <param name="disposables">Set of disposables.</param>
    protected virtual void OnHostActivated(CompositeDisposable disposables) =>
        this.Log().Info("HostView is activated");

    #endregion
}