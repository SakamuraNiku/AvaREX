namespace ReactiveCore.TestApp.Core;

public partial class App : Application
{
    #region Overrides

    public override void Initialize() =>
        AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        Navigator.Current.BootstrapNavigation(GetType().Assembly);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = Navigator.Current.StartUpHostFor;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new AppViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    #endregion
}
