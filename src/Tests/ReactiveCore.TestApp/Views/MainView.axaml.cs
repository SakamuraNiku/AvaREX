namespace ReactiveCore.TestApp.Views;

[ViewContract("MainView")]
[ReactiveHostView(IsStartUpView = true)]
public partial class MainView : ReactiveHostView<AppViewModel>
{
    public MainView()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = new AppViewModel();
    }
}
