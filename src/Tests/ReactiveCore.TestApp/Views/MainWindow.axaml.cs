namespace ReactiveCore.TestApp.Views;

[HostFor]
[HostViewContract(ByName = true)]
public partial class MainWindow : WindowView<MainView>
{
    public MainWindow() => AvaloniaXamlLoader.Load(this);
}
