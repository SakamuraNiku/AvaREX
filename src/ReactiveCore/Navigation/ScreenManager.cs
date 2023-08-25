namespace ReactiveCore.Navigation;

public static class ScreenManager
{
    public static void ShowHost<T>(string? contract = null)
        where T : class, IReactiveHostView
    {
        var host = Locator.Current.GetService<T>(contract) ??
            throw new InvalidOperationException("Host was not found");

        if (Locator.Current
            .GetService<IHostFor<T>>(contract) is not WindowView<T> view) return;

        view.Content = host;
        view.Show();
    }
}