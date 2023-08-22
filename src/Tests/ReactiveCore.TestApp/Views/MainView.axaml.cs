namespace ReactiveCore.TestApp.Views;

[ViewContract("MainView")]
[HostView(IsStartUpView = true)]
public partial class MainView : ReactiveHostView<AppViewModel>
{
    public MainView() => AvaloniaXamlLoader.Load(this);
}
