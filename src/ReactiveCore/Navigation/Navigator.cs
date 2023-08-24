namespace ReactiveCore.Navigation;

//
// Work in progress
//
public class Navigator
{
    #region Auto Properties

    public static Navigator Current => GetInstance();

    public IHostFor MainContainer { get; }

    public IReactiveHostView MainView { get; }

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
            Locator.CurrentMutable.RegisterConstant(_instance, typeof(Navigator));
        }

        return _instance;
    }

    #endregion

    #region Public Methods

    public static void Initialize()
    {
        _ = GetInstance();
    }

    public void BootstrapNavigation(Assembly assembly)
    {
        var types = Application.Current!.ResolveHosts();

        foreach (var type in types)
        {
            Locator.CurrentMutable.Register(type.Factory, type.ServiceType, type.Contract);
        }
    }

    #endregion
}