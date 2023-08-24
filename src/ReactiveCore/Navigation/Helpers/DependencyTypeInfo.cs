namespace ReactiveCore.Navigation;

/// <summary>
/// Represents dependency registration intermediate object.
/// </summary>
internal readonly struct DependencyTypeInfo
{
    #region Auto Properties

    /// <summary>
    /// Gets Dependency type.
    /// </summary>
    public Type ItemType { get; }

    /// <summary>
    /// Gets Dependency service type.
    /// </summary>
    public Type ServiceType { get; }

    /// <summary>
    /// Gets Dependency contract string.
    /// </summary>
    public string? Contract { get; }

    /// <summary>
    /// Gets Dependency`s factory.
    /// </summary>
    public Func<object> Factory =>
        FactoryHelper.CreateFactory(ItemType);

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="DependencyTypeInfo"/> struct.
    /// </summary>
    /// <param name="itemType">Dependency item`s type.</param>
    /// <param name="serviceType">Dependency item`s service type.</param>
    /// <param name="contract">Dependency`s contract string.</param>
    public DependencyTypeInfo(Type itemType, Type serviceType, string? contract = null) =>
        (ItemType, ServiceType, Contract) = (itemType, serviceType, contract);

    #endregion
}