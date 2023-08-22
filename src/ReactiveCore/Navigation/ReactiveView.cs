namespace ReactiveCore.Navigation;

public class ReactiveView<T> : ReactiveUserControl<T>, IReactiveView<T>
    where T : class, IReactiveViewModel
{
    #region Constructors

    public ReactiveView()
    {

        this.WhenActivated(OnViewActivated);
    }

    #endregion

    #region Private Methods

    protected virtual void OnViewActivated(CompositeDisposable disposables) =>
        this.Log().Info("View is activated");

    #endregion
}
