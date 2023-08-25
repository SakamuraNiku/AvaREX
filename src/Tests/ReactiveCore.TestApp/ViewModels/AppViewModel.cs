namespace ReactiveCore.TestApp.ViewModels;

[HostViewContract(Contract = "MainView")]
public class AppViewModel : ReactiveHostViewModel<string>
{
    #region Overrides

    protected override void OnViewModelActivated(CompositeDisposable disposables)
    {
        DataContext = "Welcome to Avalonia";

        base.OnViewModelActivated(disposables);
    }

    #endregion
}
