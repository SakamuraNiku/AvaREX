namespace ReactiveCore.Attribution;

/// <summary>
/// Represents attribute that sets HostView`s settings.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ReactiveHostViewAttribute : Attribute
{
    #region Auto Properties

    /// <summary>
    /// Gets indication of whether or not HostView is StartUp view.
    /// </summary>
    public bool IsStartUpView { get; init; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="ReactiveHostViewAttribute"/> class.
    /// </summary>
    public ReactiveHostViewAttribute() { }

    #endregion
}