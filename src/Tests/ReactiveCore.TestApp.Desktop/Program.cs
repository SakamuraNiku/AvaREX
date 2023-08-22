using Avalonia;
using Avalonia.ReactiveUI;

namespace ReactiveCore.TestApp.Desktop;

class Program
{
    #region Public Methods

    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<Core.App>()
                  .UsePlatformDetect()
                  .UseReactiveUI()
                  .WithInterFont()
                  .LogToTrace();

    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    #endregion
}
