namespace ReactiveCore.Navigation;

public class Navigator
{
    #region Auto Properties

    public static Navigator Current => GetCurrent();

    #endregion

    #region Private Fields

    private static Navigator? _instance;
    private static readonly object _lock = new();

    #endregion

    #region Constructors

    private Navigator()
    {
        
    }

    #endregion

    #region Private Methods

    private static Navigator GetCurrent()
    {
        if (_instance == null)
        {
            lock (_lock) _instance = new();
        }

        return _instance;
    }

    #endregion

    #region Public Methods

    public void RegisterHosts()
    {

    }

    #endregion
}