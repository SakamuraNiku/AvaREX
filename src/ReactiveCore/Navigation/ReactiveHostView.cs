namespace ReactiveCore.Navigation;

public class ReactiveHostView<T> : ReactiveUserControl<T>, IReactiveHostView<T>
    where T : class, IReactiveHostViewModel
{
    #region Constructors

    public ReactiveHostView()
    {

        this.WhenActivated(OnHostActivated);
    }

    #endregion

    #region Private Methods

    protected virtual void OnHostActivated(CompositeDisposable disposables) =>
        this.Log().Info("HostView is activated");

    #endregion
}