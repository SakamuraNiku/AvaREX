namespace ReactiveCore.Navigation;

internal static class ItemsResolverHelper
{
    #region Extensions

    public static IEnumerable<TypeInfo> GetDerived<T>(this IEnumerable<Type> types) =>
        types.Select(type => type.GetTypeInfo()).GetDerived<T>();

    public static IEnumerable<TypeInfo> GetDerived<T>(this IEnumerable<TypeInfo> types) =>
        types.Where(type => type.ImplementedInterfaces.Contains(typeof(T)));

    #endregion

    #region Private Methods

    private static IEnumerable<DependencyTypeInfo> ResolveAnyView<T>(Assembly assembly)
    {
        var types = assembly.DefinedTypes;

        List<DependencyTypeInfo> result = new();
        foreach (var type in types.GetDerived<T>()
                                  .Where(type => !type.IsAbstract))
        {
            var service = type.ImplementedInterfaces
                .GetDerived<T>().FirstOrDefault();

            if (service == null) continue;

            var attr = type.GetCustomAttribute<ViewContractAttribute>();
            var contract = attr?.Contract;

            result.Add(new(type, service, contract));
        }

        return result;
    }

    #endregion

    #region Public Methods

    public static IEnumerable<DependencyTypeInfo> ResolveHosts(Assembly assembly) =>
        ResolveAnyView<IReactiveHostView>(assembly);

    public static IEnumerable<DependencyTypeInfo> ResolveViews(Assembly assembly) =>
        ResolveAnyView<IReactiveView>(assembly);

    public static IEnumerable<DependencyTypeInfo> ResolveHostsFor(Assembly assembly) =>
        ResolveAnyView<IHostFor>(assembly);

    public static DependencyTypeInfo? ResolveMaster(Assembly assembly)
    {
        var types = assembly.DefinedTypes;
        var def = types.SingleOrDefault(type => type.BaseType == typeof(MasterView));

        if (def == null) return null;

        return new(def.AsType(), typeof(MasterView));
    }

    #endregion
}

internal static class StartUpViewHelper
{
    private static bool IsStartUpView(Type hostType) =>
        hostType.TryGetAttribute<ReactiveHostViewAttribute>(out var attr) && attr.IsStartUpView;

    public static DependencyTypeInfo GetStartUpViewType(IEnumerable<DependencyTypeInfo> types)
    {
        DependencyTypeInfo host;
        try
        {
            host = types.SingleOrDefault(t => IsStartUpView(t.ItemType));
        }
        catch (Exception ex)
        {
            throw new NavigationException(
                "Only one start up view is allowed.", ex);
        }

        if (host.IsNulL())
            throw new NavigationException(
                "No start up view was found");

        return host;
    }
}
