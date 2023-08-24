namespace ReactiveCore.Navigation;

internal static class ItemsResolverHelper
{
    #region Extensions

    public static Assembly GetAssembly(this Application application) =>
        application.GetType().Assembly;

    public static IEnumerable<DependencyTypeInfo> ResolveHosts(
        this Application app) => ResolveHosts(app.GetAssembly());

    public static IEnumerable<TypeInfo> GetDerived<T>(this IEnumerable<Type> types) =>
        types.Select(type => type.GetTypeInfo()).GetDerived<T>();

    public static IEnumerable<TypeInfo> GetDerived<T>(this IEnumerable<TypeInfo> types) =>
        types.Where(type => type.ImplementedInterfaces.Contains(typeof(T)));

    #endregion

    #region Public Methods

    public static IEnumerable<DependencyTypeInfo> ResolveHosts(Assembly assembly)
    {
        var types = assembly.DefinedTypes;
        var derived = types.GetDerived<IReactiveHostView>();

        List<DependencyTypeInfo> result = new();
        foreach (var type in derived)
        {
            var service = type.ImplementedInterfaces
                .GetDerived<IReactiveHostView>()
                .FirstOrDefault();

            if (service == null) continue;

            var attr = type.GetCustomAttribute<ViewContractAttribute>();
            var contract = attr?.Contract;

            result.Add(new(type, service, contract));
        }

        return result;
    }

    #endregion
}

