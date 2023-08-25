namespace ReactiveCore.Navigation;

using static ReactiveCore.Navigation.StartUpViewHelper;

public class NavigationException : Exception
{
    public NavigationException() { }

    public NavigationException(string? message) : base(message) { }

    public NavigationException(string? message, Exception inner) : base(message, inner) { }
}

//
// Work in progress
//
public class Navigator
{
    #region Auto Properties

    public static Navigator Current => GetInstance();

    public dynamic StartUpHostFor { get; protected set; } = null!;

    public dynamic StartUpView { get; protected set; } = null!;

    #endregion

    #region Private Fields

    private static Navigator? _instance;
    private static readonly object _lock = new();

    #endregion

    #region Constructors

    private Navigator() { }

    #endregion

    #region Private Methods

    private static Navigator GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock) _instance = new();

            Locator.CurrentMutable.RegisterLazySingleton(
                () => new CoreViewLocator(), typeof(IViewLocator));
        }

        return _instance;
    }

    #endregion

    #region Public Methods

    public static void Initialize()
    {
        _ = GetInstance();
    }

    private List<(object?, (Type, string?))> WindowViews { get; } = new();

    private void RegisterHostsFor(
        IEnumerable<DependencyTypeInfo> hosts,
        IEnumerable<DependencyTypeInfo> fHost)
    {
        foreach(var host in hosts)
        {
            var hostFor = fHost.FirstOrDefault(
                h => h.ServiceType.GenericTypeArguments.Contains(host.ItemType));

            var window = Locator.Current
                .GetService(hostFor.ServiceType, hostFor.Contract);

            var winType = typeof(WindowView<>);
            winType.MakeGenericType(host.ItemType);

            window ??= Activator.CreateInstance(winType);

            if (host.ItemType == StartUpView.GetType())
                StartUpHostFor = window!;

            WindowViews.Add(new(window, new(host.ServiceType, host.Contract)));
        }
    }

    internal IReactiveHostView GetHostViewFor(IHostFor hostFor)
    {
        var str = WindowViews.FirstOrDefault(s => s.Item1 == hostFor);

        return (IReactiveHostView)Locator.Current
            .GetService(str.Item2.Item1, str.Item2.Item2)!;
    }

    public void BootstrapNavigation(Assembly assembly)
    {
        var hosts = ItemsResolverHelper.ResolveHosts(assembly);

        var mHost = GetStartUpViewType(hosts);
                
        var views = ItemsResolverHelper.ResolveViews(assembly);
        var fHost = ItemsResolverHelper.ResolveHostsFor(assembly);

        var comb = hosts.Concat(views.Concat(fHost));

        foreach (var def in comb)
        {
            Locator.CurrentMutable.Register(
                def.Factory, def.ServiceType, def.Contract);
        }

        StartUpView = Locator.Current
            .GetService(mHost.ServiceType, mHost.Contract)!;
        RegisterHostsFor(hosts, fHost);
    }

    #endregion
}