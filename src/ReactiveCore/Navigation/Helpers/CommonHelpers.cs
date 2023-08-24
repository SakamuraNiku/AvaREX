//using System.Linq.Expressions;

namespace ReactiveCore.Navigation;

/// <summary>
/// Represents set of helper methods that are producing factories.
/// </summary>
internal static class FactoryHelper
{
    #region Extensions

    private static int ParameterCount(this ConstructorInfo info) =>
        info.GetParameters().Length;

    private static ConstructorInfo? GetConstructor(this TypeInfo info) =>
        info.DeclaredConstructors.FirstOrDefault(
            t => t.IsPublic && t.ParameterCount() == 0);

    #endregion

    #region Public Methods

    /// <summary>
    /// Finds parameterless constructor and produces factory function.
    /// </summary>
    /// <param name="type">Type to create factory for.</param>
    /// <returns>Created factory.</returns>
    public static Func<object> CreateFactory(Type type) =>
        CreateFactory(type.GetTypeInfo());

    /// <summary>
    /// Finds parameterless constructor and produces factory function.
    /// </summary>
    /// <param name="typeInfo">Info object of type to create factory for.</param>
    /// <returns>Created factory.</returns>
    public static Func<object> CreateFactory(TypeInfo typeInfo)
    {
        var ctor = typeInfo.GetConstructor() ??
            throw new NotImplementedException(
                "Factory creation on non-parameterless constructors will be added... May be...");
        
        return () => ctor.Invoke(null); // Need testing
        //return Expression.Lambda<Func<object>>(Expression.New(ctor)).Compile();
    }

    #endregion
}
